using ApiWithPostman.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  public class HttpClientRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      using (var httpClient = new HttpClient())
      {
        httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);

        var response = httpClient.GetStringAsync(new Uri(url)).Result;

        return response;
      }
    }
  }
}
