using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApiAssign1Link.Models;
using System.Collections.Specialized;
using System.Text;

namespace WebApiAssign1Link.Controllers
{
    public class StudentNewController : Controller
    {
        // GET: SupplierNew
        public ActionResult Index()
        {
            IEnumerable<Stud> studata = null;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:62219/api/";

                var json = webClient.DownloadString("Students");
                var list = JsonConvert.DeserializeObject<List<Stud>>(json);
                studata = list.ToList();
                return View(studata);
            }
        }

        // GET: SupplierNew/Details/5
        public ActionResult Details(int id)
        {
            Stud studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:62219/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<Stud>(json);
            }
            return View(studata);
        }

        // GET: SupplierNew/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierNew/Create
        [HttpPost]
        public ActionResult Create(Stud model)
        {
            try
            {
                //TODO: Add insert logic here
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "http://localhost:62219/api/";
                    var url = "Students/POST";
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);
                    var response = webClient.UploadString(url, data);
                    JsonConvert.DeserializeObject<Stud>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        //GET: SupplierNew/Edit/5
        public ActionResult Edit(int id)
        {
            Stud studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:62219/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<Stud>(json);
            }
            return View(studata);

        }

        //POST:  SupplierNew/Edit/5
        [HttpPost]

        public ActionResult Edit(int id, Stud model)
        {

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.BaseAddress = "http://localhost:62219/api/Students/"+  id;
                    //var url = "Values/Put/" + id;
                    //webClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                    webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
                    string data = JsonConvert.SerializeObject(model);

                    var response = webClient.UploadString(webClient.BaseAddress, "PUT", data);

                    Stud modeldata = JsonConvert.DeserializeObject<Stud>(response);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        //GET: SupplierNew/Delete/5
        public ActionResult Delete(int id)
        {
            Stud studata;
            using (WebClient webClient = new WebClient())
            {
                webClient.BaseAddress = "http://localhost:62219/api/";

                var json = webClient.DownloadString("Students/" + id);
                //  var list = emp 
                studata = JsonConvert.DeserializeObject<Stud>(json);
            }
            return View(studata);
        }
        //POST: SupplierNew/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Stud model)
        {

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    NameValueCollection nv = new NameValueCollection();
                    string url = "http://localhost:62219/api/Students/" + id;
                    var response = Encoding.ASCII.GetString(webClient.UploadValues(url, "DELETE", nv));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
}
    }

