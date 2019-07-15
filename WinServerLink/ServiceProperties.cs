using Microsoft.Management.Infrastructure;

namespace WinServerLink {
    public class ServiceProperties {

        //Caption : Apache Tomcat 8.5 Tomcat8
        public string Caption { get; set; }
        //Description : Apache Tomcat 8.5.5 Server - http://tomcat.apache.org/
        public string Description { get; set; }
        //InstallDate :
        public string InstallDate { get; set; }
        //Name : Tomcat8
        public string Name { get; set; }
        //Status : OK
        public string Status { get; set; }
        //CreationClassName : Win32_Service
        public string CreationClassName { get; set; }
        //Started : True
        public bool Started { get; set; }
        //StartMode : Auto
        public string StartMode { get; set; }
        //SystemCreationClassName : Win32_ComputerSystem
        public string SystemCreationClassName { get; set; }
        //SystemName : FTWAITPZPA01
        public string SystemName { get; set; }
        //AcceptPause : False
        public bool AcceptPause { get; set; }
        //AcceptStop : True
        public bool AcceptStop { get; set; }
        //DesktopInteract : False
        public bool DesktopInteract { get; set; }
        //DisplayName : Apache Tomcat 8.5 Tomcat8
        public string DisplayName { get; set; }
        //ErrorControl : Normal
        public string ErrorControl { get; set; }
        //ExitCode : 0
        public System.UInt32 ExitCode { get; set; }
        //PathName : D:\etrack\tomcat\apache-tomcat-8.5.5\bin\tomcat8.exe //RS//Tomcat8
        public string PathName { get; set; }
        //ServiceSpecificExitCode : 0
        public System.UInt32 ServiceSpecificExitCode { get; set; }
        //ServiceType : Own Process
        public string ServiceType { get; set; }
        //StartName : lfwc\aitarfid
        public string StartName { get; set; }
        //State : Running
        public string State { get; set; }
        //TagId : 0
        public System.UInt32 TagId { get; set; }
        //CheckPoint : 0
        public System.UInt32 CheckPoint { get; set; }
        //DelayedAutoStart : False
        public bool DelayedAutoStart { get; set; }
        //ProcessId : 4640
        public System.UInt32 ProcessId { get; set; }
        //WaitHint : 0
        public System.UInt32 WaitHint { get; set; }

        public ServiceProperties(CimInstance ci) {
            Caption = (string)ci.CimInstanceProperties["Caption"].Value;
            Description = (string)ci.CimInstanceProperties["Description"].Value;
            InstallDate = (string)ci.CimInstanceProperties["InstallDate"].Value;
            Name = (string)ci.CimInstanceProperties["Name"].Value;
            Status = (string)ci.CimInstanceProperties["Status"].Value;
            CreationClassName = (string)ci.CimInstanceProperties["CreationClassName"].Value;
            Started = (bool)ci.CimInstanceProperties["Started"].Value;
            StartMode = (string)ci.CimInstanceProperties["StartMode"].Value;
            SystemCreationClassName = (string)ci.CimInstanceProperties["SystemCreationClassName"].Value;
            SystemName = (string)ci.CimInstanceProperties["SystemName"].Value;
            AcceptPause = (bool)ci.CimInstanceProperties["AcceptPause"].Value;
            AcceptStop = (bool)ci.CimInstanceProperties["AcceptStop"].Value;
            DesktopInteract = (bool)ci.CimInstanceProperties["DesktopInteract"].Value;
            DisplayName = (string)ci.CimInstanceProperties["DisplayName"].Value;
            ErrorControl = (string)ci.CimInstanceProperties["ErrorControl"].Value;
            ExitCode = (System.UInt32)ci.CimInstanceProperties["ExitCode"].Value;
            PathName = (string)ci.CimInstanceProperties["PathName"].Value;
            ServiceSpecificExitCode = (System.UInt32)ci.CimInstanceProperties["ServiceSpecificExitCode"].Value;
            ServiceType = (string)ci.CimInstanceProperties["ServiceType"].Value;
            StartName = (string)ci.CimInstanceProperties["StartName"].Value;
            State = (string)ci.CimInstanceProperties["State"].Value;
            TagId = (System.UInt32)ci.CimInstanceProperties["TagId"].Value;
            CheckPoint = (System.UInt32)ci.CimInstanceProperties["CheckPoint"].Value;
            DelayedAutoStart = (bool)ci.CimInstanceProperties["DelayedAutoStart"].Value;
            ProcessId = (System.UInt32)ci.CimInstanceProperties["ProcessId"].Value;
            WaitHint = (System.UInt32)ci.CimInstanceProperties["WaitHint"].Value;
        }



    }
}
