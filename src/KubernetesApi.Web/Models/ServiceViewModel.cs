using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KubernetesApi.Web.Models
{
    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
    }
}
