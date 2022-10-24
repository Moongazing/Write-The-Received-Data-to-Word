using ApiWithPostman.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  public class WebClientRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      var client = new WebClient();
      client.Headers.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

      var response = client.DownloadString(url);

      return response;
    }
  }
}
