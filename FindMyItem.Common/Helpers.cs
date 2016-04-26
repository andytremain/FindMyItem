using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

using Newtonsoft.Json;

namespace FindMyItem.Common.Helpers
{
    public class CacheHelpers
    {
        public static string GetCachePath()
        {
            return HttpContext.Current.Server.MapPath(Path.Combine("~", Constants.CACHE_FOLDER));
        }

        public static string GetCachePathWithFilename()
        {
            return HttpContext.Current.Server.MapPath(Path.Combine("~", Constants.CACHE_FOLDER, Constants.CACHE_FILE_NAME));
        } 
    }

    public static class MenuExtensions
    {
        public static IHtmlString MenuItem(
             this HtmlHelper htmlHelper,
             string text,
             string action,
             string controller
         )
        {
            var li = new TagBuilder("li");
            var routeData = htmlHelper.ViewContext.RouteData;
            var currentAction = routeData.GetRequiredString("action");
            var currentController = routeData.GetRequiredString("controller");
            if (string.Equals(currentAction, action, StringComparison.OrdinalIgnoreCase) &&
                string.Equals(currentController, controller, StringComparison.OrdinalIgnoreCase))
            {
                li.AddCssClass("active");
            }

            li.InnerHtml = htmlHelper.ActionLink(text, action, controller, null, new { Title = text }).ToHtmlString();
            return new HtmlString(li.ToString());
        }
    }

    public static class SiteHelpers
    {
        public static bool SiteLive(string url)
        {
            try
            {
                // prepare the web page we will be asking for
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 5000; // millisecond
                request.UserAgent = "Scanner Agent";

                var response = (HttpWebResponse)request.GetResponse();

                // we will read data via the response stream
                Stream resStream = response.GetResponseStream();
            }
            catch
            {
                return false;
            }

            return true;
            //string tempString = null;
            //int count = 0;

            //do
            //{
            //    // fill the buffer with data
            //    count = resStream.Read(buf, 0, buf.Length);

            //    // make sure we read some data
            //    if (count != 0)
            //    {
            //        // translate from bytes to ASCII text
            //        tempString = Encoding.ASCII.GetString(buf, 0, count);

            //        // continue building the string
            //        sb.Append(tempString);
            //    }
            //}
        }
    }

    public class StringHelpers
    {
        public static string GetNumbersFromString(string value)
        {
            var ofPos = value.ToLower().LastIndexOf("of", StringComparison.Ordinal);

            if (ofPos > 0)
            {
                value = value.Substring(ofPos);
            }
            
            string[] numbers = Regex.Split(value, @"\D+");

            return numbers.Where(n => !string.IsNullOrEmpty(n)).Aggregate("", (current, n) => current + n);
        }

        public static string StripHTML(string htmlString)
        {
            const string pattern = @"<(.|\n)*?>";

            return Regex.Replace(htmlString, pattern, string.Empty);
        }

        public static string ToTitleCase(String text)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }
    }

    public static class JSON
    {
        public static T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string Serialize(object inObject)
        {
            return JsonConvert.SerializeObject(inObject);
        }
    }
}



//private void SaveHTMLDoc(WebClient Client, string url)
//{
//    Stream data = Client.OpenRead(new Uri(url));

//    Guid FileName = Guid.NewGuid();

//    string FilePath = Path.Combine(@"D:\TestHTML", FileName.ToString() + ".html");

//    FileStream File = new FileStream(FilePath, FileMode.OpenOrCreate);

//    StreamReader reader = new StreamReader(data);

//    string html = reader.ReadToEnd();

//    StreamWriter sw = new StreamWriter(File);

//    sw.Write(html);

//    sw.Close();
//    File.Close();
//}