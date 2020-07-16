using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k8s;
using KubernetesApi.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubernetesApi.Web.Controllers
{
    public class PodController : Controller
    {

        private IKubernetes _k8s;
        public PodController(IKubernetes k8s)
        {
            this._k8s = k8s;
        }

        public IActionResult Index([FromQuery] string ns = "default")
        {
            var podList = this._k8s.ListNamespacedPod(ns);
            return View(podList.Items.Select(podItem => new PodViewModel()
            {
                Name = podItem.Metadata.Name,
                Namespace = podItem.Metadata.NamespaceProperty,
                Containers = podItem.Spec.Containers.Count,
                Status = podItem.Status.Phase
            }));
        }
    }
}