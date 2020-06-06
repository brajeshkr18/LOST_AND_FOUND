using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Shopping.Model;
using Shopping.Business;
using System.Threading;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Web.UI;
using System.Configuration;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Shopping.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var session = Session["UserInfo"];
            if (Request.IsAuthenticated)
            {
                if (Session["UserInfo"] == null)
                    return RedirectToAction("Logout");
            }
            clsListFoundedPeople objfoundedppl = new clsListFoundedPeople();
            objfoundedppl.lstFoundedPeople = (new HomeBLL().GetFoundedPeople(1));
            return View(objfoundedppl);
           
        }
        public ActionResult Logout()
        {
            KillUser();
            return RedirectToAction("Index", "Home");
        }
        private void KillUser()
        {
            FormsAuthentication.SetAuthCookie("username", false);
            FormsAuthentication.SignOut();
            Session.Abandon();
        }
        public ActionResult FoundedPeople()
        {
            clsListFoundedPeople objfoundedppl = new clsListFoundedPeople();
            objfoundedppl.lstFoundedPeople = (new HomeBLL().GetFoundedPeople(1));
            return View(objfoundedppl);
        }
        //public ActionResult QuestionAnswer()
        //{
        //    ClsListQuesTionAnswer objfoundedppl = new ClsListQuesTionAnswer();
        //    objfoundedppl.lstclsQuestionAnswer = (new HomeBLL().GetQuestionAnswer());
        //    return View(objfoundedppl);
        //}
        public ActionResult LostPeople()
        {
            clsListFoundedPeople objfoundedppl = new clsListFoundedPeople();
            objfoundedppl.lstFoundedPeople = (new HomeBLL().GetFoundedPeople(1));
            return View(objfoundedppl);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddFoundedPeople()
        {
            clsFoundedPeople objfoundedppl = new clsFoundedPeople();
           
            return View(objfoundedppl);
           // return View();
        }
        public ActionResult AddLostPeople()
        {
            clsFoundedPeople objLostppl = new clsFoundedPeople();

            return View(objLostppl);
            // return View();
        }
        public ActionResult BestDeals()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Event()
        {
            string address = calcularRota(Convert.ToString(24.7955), Convert.ToString(84.9994));
            char[] commaSeparator = new char[] { ',' };
            char[] spacrSeparator = new char[] { ' ' };
            string[] addressArray = address.Split(commaSeparator, StringSplitOptions.None);

            string[] statepincode = addressArray[3].Split(spacrSeparator, StringSplitOptions.None);
            string State = statepincode[1];
            string PinCode = statepincode[2];
            string City = addressArray[2];
            string Country = addressArray[4];
            string FullAddress = address;
            string Address = address.Split(',').Take(2).Aggregate((s1, s2) => s1 + "," + s2).Substring(0);
            //objfoundedppl.Address = Address;
            //objfoundedppl.City = City;
            //objfoundedppl.State = State;
            //objfoundedppl.Country = Country;
            //objfoundedppl.Pincode = PinCode;
            //objfoundedppl.FullAddress = FullAddress;

            return View();
        }
        [HttpPost]
        public ActionResult Event(clsFoundedPeople objfoundppl)
        {

            string address = calcularRota(Convert.ToString(objfoundppl.Latitude), Convert.ToString(objfoundppl.Longitude));
            char[] commaSeparator = new char[] { ',' };

            string[] authors = address.Split(commaSeparator, StringSplitOptions.None);
            //string Country = authors[5];
            //string State = authors[4];
            //string City = authors[3];
            //string fullAddress = address;
            var offset = address.IndexOf(',');
            offset = address.IndexOf(':', offset + 1);
            var result = address.IndexOf(':', offset + 1);
           
            foreach (string author in authors)

            {

                Console.WriteLine(author);

            }

            return View();
        }
        
        public string calcularRota(string latitude, string longitude)
        {
            string address = "";
            try
            {
                //URL do distancematrix - adicionando endereco de origem e destino
                string url = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false", latitude, longitude);
                XElement xml = XElement.Load(url);

                // verifica se o status é ok
                if (xml.Element("status").Value == "OK")
                {
                    //Formatar a resposta
                    address = string.Format(xml.Element("result").Element("formatted_address").Value);
                    return address;
                    //Pegar endereço de destino                    
                }
                else
                {
                    address = String.Concat("Ocorreu o seguinte erro: ", xml.Element("status").Value);
                    return address;
                }
            }
            catch (Exception ex)
            {
                return address;
            }
        }

        [HttpPost]
        public ActionResult SaveFoundPeolpeDetail(clsFoundedPeople objfoundedppl)
        {
            if (objfoundedppl.Latitude != null && objfoundedppl.Longitude != null)
            {
                //{
                //    RootObject rootObject = getAddress(23.5270797, 77.2548046);
                //    Console.WriteLine("Full Address " + rootObject.display_name);
                  
                //}
                string address = calcularRota(Convert.ToString(objfoundedppl.Latitude), Convert.ToString(objfoundedppl.Longitude));
                if (!string.IsNullOrEmpty(address) && !address.Contains("DENIED"))
                {
                    char[] commaSeparator = new char[] { ',' };
                    char[] spacrSeparator = new char[] { ' ' };
                    string[] addressArray = address.Split(commaSeparator, StringSplitOptions.None);
                    var length = addressArray.Length;
                    string[] statepincode = addressArray[length - 2].Split(spacrSeparator, StringSplitOptions.None);
                    var length1 = statepincode.Length;
                    string State = statepincode[length1 - 2];
                    string PinCode = statepincode[length1 - 1];
                    string City = addressArray[length - 3];
                    string Country = addressArray[length - 1];
                    string FullAddress = address;
                    string Address = address.Split(',').Take(length - 3).Aggregate((s1, s2) => s1 + "," + s2).Substring(0);
                    objfoundedppl.Address = Address;
                    objfoundedppl.City = City;
                    objfoundedppl.State = State;
                    objfoundedppl.Country = Country;
                    objfoundedppl.Pincode = PinCode;
                    objfoundedppl.FullAddress = FullAddress;
                }
                else
                {
                    //RootObject rootObject = getAddress(23.5270797, 77.2548046);
                    //Console.WriteLine("Full Address " + rootObject.display_name);
                }
              
            }
            var Savruser_Result = (new HomeBLL()).SaveFoundPeolpeDetail(objfoundedppl);
            if (Savruser_Result != null)
            {
                if (Savruser_Result == 1)
                    return Json(new { Status = "Success", Message = "Congrats! User details saved successfully" });
                else if (Savruser_Result == 2)
                    return Json(new { Status = "Success", Message = "Congrats! User details saved successfully" });
                else
                    return Json(new { Status = "Failure", Message = "Username you have entered is already in use for another account. Tryout with different username." });
            }
            return Json(new { Status = "Failure", Message = "Oops! Something went wrong while processing your request. Please try again later." });
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile()
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    Fileexists();
                    var file = Request.Files[0];
                    var fileName = Path.GetFileName(file.FileName);
                    fileName = CreateFileName(fileName);
                    var Fullpath = HttpContext.Request.Url.GetLeftPart(UriPartial.Authority) + ConfigurationManager.AppSettings["ImagePath"].ToString().Replace("~", "") + fileName;
                    var rootfilepath = ConfigurationManager.AppSettings["ImagePath"].ToString() + fileName;
                    var path = Path.Combine(Server.MapPath(ConfigurationManager.AppSettings["ImagePath"].ToString()), fileName);
                    file.SaveAs(path);
                    return Json(new { Status = "Success", Message = "File uploaded Successfully.", path = Fullpath });
                }
                return Json(new { Status = "Failure", Message = "Please select a file to upload." });
            }
            catch (Exception Ex)
            {
                return Json(new { Status = "Failure", Message = Ex.Message });

            }
        }

        private void Fileexists()
        {
            string subPath = ConfigurationManager.AppSettings["ImagePath"].ToString(); // your code goes here
            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
        }
        private string CreateFileName(string filename)
        {
            if (!string.IsNullOrEmpty(filename))
            {
                var Fname = filename.Split('.')[0];
                var Fext = filename.Split('.')[1];

                return (Fname + "_" + DateTime.Now.ToString("yyyyMMddmmss")) + "." + Fext;
            }

            return "";

        }
        public ActionResult Quiz()
        {
            ClsListQuesTionAnswer objfoundedppl = new ClsListQuesTionAnswer();
            objfoundedppl.lstclsQuestionAnswer = (new HomeBLL().GetQuestionAnswer());
            return View(objfoundedppl);
            //return View();
        }

        public static RootObject getAddress(double lat, double lon)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agentozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            webClient.Headers.Add("Refererhhttp://www.microsoft.com");
            var jsonData = webClient.DownloadData("http://nominatim.openstreetmap.org/reverse?format=json&lat=" + lat + "&lon=" + lon);
            RootObject rootObject = new RootObject();
            //JsonSerializer ser = new DataContractJsonSerializer(typeof(RootObject));
            //RootObject rootObject = (RootObject)ser.ReadObject(new MemoryStream(jsonData));
            //JsonConvert.DeserializeObject<RootObject>(jsonData);
            return rootObject;

        }
    }
    
    
}