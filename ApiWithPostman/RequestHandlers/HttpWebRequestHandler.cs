using ApiWithPostman.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  public class HttpWebRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      var request = (HttpWebRequest)WebRequest.Create(url);

      request.Method = "GET";
      request.UserAgent = RequestConstants.UserAgentValue;
      request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

      var content = string.Empty;

      using (var response = (HttpWebResponse)request.GetResponse())
      {
        using (var stream = response.GetResponseStream())
        {
          using (var sr = new StreamReader(stream))
          {
            content = sr.ReadToEnd();
          }
        }
      }

      return content;
    }
  }
}
