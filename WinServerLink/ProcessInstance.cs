using Microsoft.Management.Infrastructure;

namespace WinServerLink {
    public class ProcessInstance {

        public CimInstance cimInstance;

        public ProcessProperties Properties;

        public ProcessInstance(CimInstance ci) {
            this.cimInstance = ci;
            this.Properties = new ProcessProperties(ci);
        }
    }
}
