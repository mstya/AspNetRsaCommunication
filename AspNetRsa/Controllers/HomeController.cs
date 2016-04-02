using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using AspNetRsa.Managers;
using AspNetRsa.Models;

namespace AspNetRsa.Controllers
{
    public class HomeController : Controller
    {
        private const string PRIVATE_KEY = "privateKey";

        private readonly RsaManager rsaManager;

        public HomeController()
        {
            this.rsaManager = new RsaManager();
        }

        public ActionResult Index()
        {
            KeyModel keys = rsaManager.GetKeys();
            this.Session[PRIVATE_KEY] = keys.PrivateKeyXml;
            return View(keys);
        }

        [HttpPost]
        public ActionResult SaveData(string data)
        {
            string privateKeyXml = this.Session[PRIVATE_KEY].ToString();
            string decryptedData = rsaManager.Decrypt(data, privateKeyXml);
            return Json(decryptedData);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}