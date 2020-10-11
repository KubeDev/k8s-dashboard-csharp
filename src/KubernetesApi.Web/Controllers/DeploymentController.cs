using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using KubernetesApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesApi.Web.Controllers
{
    public class DeploymentController : Controller
    {

        private IKubernetes _k8s;
        public DeploymentController(IKubernetes k8s)
        {
            this._k8s = k8s;
        }

        public IActionResult Index([FromQuery] string ns = "default")
        {
            var deploymentList = this._k8s.ListNamespacedDeployment(ns);
            return View(deploymentList.Items.Select(podItem => new DeploymentViewModel()
            {
                Name = podItem.Metadata.Name,
                Namespace = podItem.Metadata.NamespaceProperty,
            }));
        }
    }
}
