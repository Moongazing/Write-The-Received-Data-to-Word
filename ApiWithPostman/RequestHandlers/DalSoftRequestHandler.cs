using DalSoft.RestClient;
using ApiWithPostman.Constants;
using ApiWithPostman.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  class DalSoftRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      dynamic client = new RestClient(RequestConstants.baseUrl,
          new Headers { { RequestConstants.UserAgent, RequestConstants.UserAgentValue } });

      var response = client.repos.restsharp.restsharp.releases.Get().Result.ToString();

      return response;
    }

    //Here's a great way to deserialize the response "organically"
    public async Task<List<PostmanRelease>> GetDeserializedReleases(string url)
    {
      dynamic client = new RestClient(RequestConstants.baseUrl,
          new Headers { { RequestConstants.UserAgent, RequestConstants.UserAgentValue } });

      var response = await client.repos.restsharp.restsharp.releases.Get();

      return response;
    }
  
  }
}
