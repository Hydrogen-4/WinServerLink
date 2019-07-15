using Microsoft.Management.Infrastructure;
using Microsoft.Management.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;


//Add-Type -Path .\WinServerLink.dll
//$Link = New-Object WinServerLink.ServerLink("ftwaitopsba01.lfwc.us.lmco.com","User Name","Pass Word");
//if($Link.Connect()){
//    $Service = $Link.GetService("Tomcat8");
//    if (-Not($Service -eq $null)){
//        If($Service.Properties.State -eq "Running") {
//           $ItWorks = $Link.RebootService([ref] $Service);
//}
//Elseif($Service.Properties.State -eq "Stopped") {
//           $ItWorks = $Link.StartService([ref] $Service);
//}
//    }
//}
//$Link.Close();


namespace WinServerLink {
    public class ServerLink : IDisposable {

        private string Domain;
        private string ComputerName;
        private string UserName;
        private SecureString SecurePassWord;
        private string Namespace = @"root\cimv2";
        private CimSession Session;



        public ServerLink(string computerName, string userName, string passWord, string domain = "") {
            this.Domain = domain;
            this.ComputerName = computerName;
            this.UserName = userName;
            SetSecurePassWord(passWord);

  


        }

        public string ErrorMessage;
        public bool Connect() {
            bool result = true;
            try {
                WSManSessionOptions SessionOptions = new WSManSessionOptions();
                SessionOptions.AddDestinationCredentials(GetCredentials());
                this.Session = CimSession.Create(this.ComputerName, SessionOptions);
            } catch (Exception ex) {
                ErrorMessage = ex.Message;
                result = false;
            }
            return result;
        }


        private void SetSecurePassWord(string PassWord) {
            SecureString securepassword = new SecureString();
            foreach (char c in PassWord) {
                securepassword.AppendChar(c);
            }
            this.SecurePassWord = securepassword;
        }

        private CimCredential GetCredentials() {
            CimCredential Credentials = new CimCredential(PasswordAuthenticationMechanism.Default,
                                                         this.Domain,
                                                         this.UserName,
                                                         this.SecurePassWord);
            return Credentials;
        }


        public ServiceInstance GetService(string name) {
            var lst = GetServices();
            return lst.FirstOrDefault(x => x.Properties.Name == name);
        }


        public List<ServiceInstance> GetServices() {
            string OSQuery = "SELECT * FROM Win32_Service";
            var Services = new List<ServiceInstance>();
            IEnumerable<CimInstance> allServices = Session.QueryInstances(Namespace, "WQL", OSQuery);
            foreach (var cimInstance in allServices) {
                Services.Add(new ServiceInstance(cimInstance));
            }

            return Services;
        }


        public List<ProcessInstance> GetProcesses() {
            string OSQuery = "SELECT * FROM Win32_Process";
            var Processes = new List<ProcessInstance>();
            IEnumerable<CimInstance> allProcesses = Session.QueryInstances(Namespace, "WQL", OSQuery);
            foreach (var cimInstance in allProcesses) {
                Processes.Add(new ProcessInstance(cimInstance));
            }
            return Processes;
        }

        public bool UpdateInstance(ref ServiceInstance instance) {
            bool operationResult = false;
            string OSQuery = $"SELECT * FROM Win32_Service WHERE Name = '{instance.Properties.Name}'";
            var x = Session.QueryInstances(Namespace, "WQL", OSQuery);
            operationResult = x != null;
            if (operationResult) {
                instance = new ServiceInstance(x.First());
            }

            return operationResult;
        }


        public bool UpdateServiceCredentials(ref ServiceInstance sInstance, string StartName, string PassWord) {


            CimMethodParametersCollection cmpcBiosService = new CimMethodParametersCollection();
            cmpcBiosService.Add(CimMethodParameter.Create("StartName", StartName, Microsoft.Management.Infrastructure.CimType.String, CimFlags.In));
            cmpcBiosService.Add(CimMethodParameter.Create("StartPassword", PassWord, Microsoft.Management.Infrastructure.CimType.String, CimFlags.In));

            CimMethodResult OperationResult = Session.InvokeMethod(sInstance.cimInstance, "Change", cmpcBiosService);

            UpdateInstance(ref sInstance);
            return (UInt32)OperationResult.ReturnValue.Value == 0; ;
        }


        public bool StopService(ref ServiceInstance sInstance) {
            CimMethodResult OperationResult = Session.InvokeMethod(sInstance.cimInstance, "StopService", null);
            UpdateInstance(ref sInstance);
            return (UInt32)OperationResult.ReturnValue.Value == 0;
        }

        public bool StartService(ref ServiceInstance sInstance) {
            CimMethodResult OperationResult = Session.InvokeMethod(sInstance.cimInstance, "StartService", null);
            UpdateInstance(ref sInstance);
            return (UInt32)OperationResult.ReturnValue.Value == 0;
        }


        public bool RebootService(ref ServiceInstance sInstance) {
            bool result = false;
            if (ForceStopService(ref sInstance)) {
                result = StartService(ref sInstance);
            }
            return result;
        }

        public bool ForceStopService(ref ServiceInstance sInstance) {

            var processes = GetProcesses();
            ServiceInstance ins = sInstance;
            var p = processes.FirstOrDefault(x => x.Properties.ProcessId == ins.Properties.ProcessId);
            CimMethodResult OperationResult = null;
            if (p != null) {
                OperationResult = Session.InvokeMethod(p.cimInstance, "Terminate", null);
            }
            UpdateInstance(ref sInstance);
            return (UInt32)OperationResult.ReturnValue.Value == 0;
        }

        public void Close() {
            if (Session != null) {
                Session.Close();
                Session.Dispose();
                Session = null;
            }
        }

        public void Dispose() {
            Close();
        }
    }
}
