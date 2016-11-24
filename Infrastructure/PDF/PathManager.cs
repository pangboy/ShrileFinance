namespace Infrastructure.PDF
{
    using System.IO;
    using System.Web;

    public class PathManager
    {
        public string GetPath(string virtualPath)
        {
            string fullpath = HttpContext.Current.Server.MapPath(virtualPath);
            string directory = Directory.GetCurrentDirectory();
            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            return fullpath;
        }

        public string GetTemplatePath()
        {
            return HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath.ToString()) + "\\Contracts\\";
        }
    }
}
