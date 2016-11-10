using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Shypp.Models;
using static Shypp.Models.Photo;


namespace Shypp.Services
{

    public class PhotoService
    {
        const int MAX_FILES_UPLOAD = 10;

        private ApplicationDbContext db = new ApplicationDbContext();

        private List<string> AcceptedExtensions = new List<string>
        {
            ".jpg",
            ".jpeg",
            ".png"
        };

        // ---------------------------------------------------------------------------------------

        public bool SaveFiles(IEnumerable<HttpPostedFileBase> Files, HttpServerUtilityBase Server, int requestId)
        {
            string subPath = "~/Content/Upload/Photos/Request/" + requestId;

            bool exists = System.IO.Directory.Exists(Server.MapPath(subPath));

            if (!exists)
            {
                System.IO.Directory.CreateDirectory(Server.MapPath(subPath));
            }

            foreach (var File in Files)
            {
                if (File.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(File.FileName);
                    var path = Path.Combine(Server.MapPath(subPath), fileName);
                    File.SaveAs(path);
                    saveToTable();
                }
                else
                {
                    return false;
                }

            }
            return true;
        }

        private bool saveToTable()
        {
            //TODO: save photo
            return true;
        }

        // ---------------------------------------------------------------------------------------

        public bool ValidNumberFilesPosted(IEnumerable<HttpPostedFileBase> Files)
        {
            ICollection<HttpPostedFileBase> cFiles = Files as ICollection<HttpPostedFileBase>;
            int nFiles = cFiles.Count;
            return nFiles <= MAX_FILES_UPLOAD;
        }

        // ---------------------------------------------------------------------------------------

        public int GetMaxFilesUpload()
        {
            return MAX_FILES_UPLOAD;
        }

        // ---------------------------------------------------------------------------------------

        public bool ValidFilesExtensions(IEnumerable<HttpPostedFileBase> Files)
        {
            foreach (var File in Files)
            {
                if (File.ContentLength > 0)
                {
                    var extension = Path.GetExtension(File.FileName);
                    if (AcceptedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase) == false)
                    {
                        return false;
                    }

                }
            }

            return true;
        }
        // ---------------------------------------------------------------------------------------

        public string GetAcceptedExtensionsToString()
        {
            var result = String.Join(", ", AcceptedExtensions.ToArray());
            return result;
        }


    }
}