using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using KubernetesApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesApi.Web.Controllers
{
    public class ServiceController : Controller
    {

        private IKubernetes _k8s;
        public ServiceController(IKubernetes k8s)
        {
            this._k8s = k8s;
        }

        public IActionResult Index([FromQuery] string ns = "default")
        {
            var serviceList = this._k8s.ListNamespacedService(ns);
            return View(serviceList.Items.Select(podItem => new ServiceViewModel()
            {
                Name = podItem.Metadata.Name,
                Namespace = podItem.Metadata.NamespaceProperty,
            }));
        }
    }
}
