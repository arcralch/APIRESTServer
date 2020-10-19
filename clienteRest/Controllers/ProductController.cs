using clienteRest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace clienteRest.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<mvcProductModel> prolist;
            HttpResponseMessage respuesta = VariablesGlobales.webClient.GetAsync("productoes").Result;
            prolist = respuesta.Content.ReadAsAsync<IEnumerable<mvcProductModel>>().Result;
            return View(prolist);
        }
        public ActionResult AddOrEdit(int id =0)
        {
            if (id == 0)
                return View(new mvcProductModel());
            else
            {
                HttpResponseMessage respuesta = VariablesGlobales.webClient.GetAsync("productoes/" + id.ToString()).Result;
                return View(respuesta.Content.ReadAsAsync<mvcProductModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcProductModel prod)
        {
            HttpResponseMessage respuesta = VariablesGlobales.webClient.PostAsJsonAsync("productoes", prod).Result;
            return RedirectToAction("Index");
        }
 
        public ActionResult Delete(int id)
        {
            HttpResponseMessage respuesta = VariablesGlobales.webClient.DeleteAsync("productoes/" + id.ToString()).Result;
            return RedirectToAction("Index");
        }

    }
}