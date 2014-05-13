using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections;
using SmartFile;
using System.IO;

namespace FilesDIRECT3.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(int? chunk,int? chunks, string name)
        {
            try
            {
                BasicClient smartFileClientApi = new BasicClient("n0ovmBWo0o4d4KPsQdxp0OottMmedK", "3QVqLTXR46zJEFho0GibrIxgQiK794");

                Hashtable hashFileInfo = new Hashtable();
                HttpPostedFileBase PostedFile = Request.Files[0];

                string uploadPath = "~/App_Data/Uploads";

                chunk = chunk ?? 0;
                chunks = chunks ?? 0;
                var path = Path.Combine(Server.MapPath(uploadPath), PostedFile.FileName);

                //Upload file
                using (var fs = new FileStream(path, chunk == 0 ? FileMode.Create : FileMode.Append))
                {
                    var buffer = new byte[PostedFile.InputStream.Length];
                    PostedFile.InputStream.Read(buffer, 0, buffer.Length);
                    fs.Write(buffer, 0, buffer.Length);
                }

                

                if (chunks == 0 || chunk == chunks - 1) {
                    
                    FileInfo fileInfo = new FileInfo(path);

                    hashFileInfo.Add(name, fileInfo);

                    //Move to SmartFile client desire location
                    smartFileClientApi.Post("path/data", null, hashFileInfo);

                    //TODO: throw an exception need to resolve
                    //System.IO.File.Delete(path);

                    return Content("Successfully Moved", "text/plain");
                }
                                  

                return Content("Successfully Uploaded Chunk", "text/plain");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
