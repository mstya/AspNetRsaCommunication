using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using RSA2.Models;

namespace AspNetRsa.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            KeyModel model = new KeyModel();

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);

            model.PrivateKey = csp.ExportParameters(true);
            model.PublicKey = csp.ExportParameters(false);

            byte[] encrypted = csp.Encrypt(Encoding.Default.GetBytes("plain text"), false);
            byte[] decr = csp.Decrypt(encrypted, false);

            string res = Encoding.ASCII.GetString(decr);

            model.PublicKeyXml = csp.ToXmlString(false);

            this.Session["PrivateKeyXml"] = csp.ToXmlString(true);

            ////how to get the private key
            //model.PrivateKeyXml = KeyToXml(csp.ExportParameters(true));

            //////and the public key ...
            //model.PublicKeyXml = KeyToXml(csp.ExportParameters(false));

            int a = 1;
            return View(model);
        }

        [HttpPost]
        public ActionResult SaveData(string data)
        {
            byte[] encryptedBytes = data.Split(',').Select(Byte.Parse).ToArray();

            string privateKeyXml = this.Session["PrivateKeyXml"].ToString();

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);
            csp.FromXmlString(privateKeyXml);
          //  byte[] encryptedBytes = Encoding.ASCII.GetBytes(data);
            byte[] decrypted = csp.Decrypt(encryptedBytes, false);
            string dataStr = Encoding.ASCII.GetString(decrypted);
            //string privateKey = HttpContext.Session.GetPrivateKey();
            //// RSAParameters privateKey = rsaManager.XmlStringToKey(HttpContext.Session.GetPrivateKey());
            //rsaManager.Decrypt(privateKey, data);
            return Json(data);
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