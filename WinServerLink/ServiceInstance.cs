using Microsoft.Management.Infrastructure;

namespace WinServerLink {
    public class ServiceInstance {

        public CimInstance cimInstance;

        public ServiceProperties Properties;

        public ServiceInstance(CimInstance ci) {
            this.cimInstance = ci;
            this.Properties = new ServiceProperties(ci);        
        }
    }
}
