using Microsoft.Management.Infrastructure;

namespace WinServerLink {
    public class ProcessProperties {
        //Caption : System Idle Process
        //Description : System Idle Process
        //InstallDate : 
        //Name : System Idle Process
        public string Name { get; set; }
        //Status : 
        //CreationClassName : Win32_Process
        //CreationDate : 5/21/2019 6:21:28 PM
        //CSCreationClassName : Win32_ComputerSystem
        //CSName : FTWAITOPSBA01
        //ExecutionState : 
        //Handle : 0
        //KernelModeTime : 116014790781250
        //OSCreationClassName : Win32_OperatingSystem
        //OSName : Microsoft Windows Server 2016 Standard|C:\WINDOWS|\Device\Harddisk0\Partition1
        //Priority : 0
        //TerminationDate : 
        //UserModeTime : 0
        //WorkingSetSize : 4096
        //CommandLine : 
        //ExecutablePath : 
        //HandleCount : 0
        //MaximumWorkingSetSize : 
        //MinimumWorkingSetSize : 
        //OtherOperationCount : 0
        //OtherTransferCount : 0
        //PageFaults : 2
        //PageFileUsage : 0
        //ParentProcessId : 0
        //PeakPageFileUsage : 0
        //PeakVirtualSize : 65536
        //PeakWorkingSetSize : 4
        //PrivatePageCount : 0
        //ProcessId : 0
        public System.UInt32 ProcessId { get; set; }
        //QuotaNonPagedPoolUsage : 0
        //QuotaPagedPoolUsage : 0
        //QuotaPeakNonPagedPoolUsage : 0
        //QuotaPeakPagedPoolUsage : 0
        //ReadOperationCount : 0
        //ReadTransferCount : 0
        //SessionId : 0
        //ThreadCount : 4
        //VirtualSize : 65536
        //WindowsVersion : 10.0.14393
        //WriteOperationCount : 0
        //WriteTransferCount : 0

        public ProcessProperties(CimInstance ci) {
            Name = (string)ci.CimInstanceProperties["Name"].Value;

            ProcessId = (System.UInt32)ci.CimInstanceProperties["ProcessId"].Value;
        }

    }
}
