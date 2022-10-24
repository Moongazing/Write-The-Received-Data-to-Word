using Flurl.Http;
using Newtonsoft.Json;
using ApiWithPostman.Constants;
using ApiWithPostman.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  public class FlurlRequestHandler  : IRequestHandler
  {

    // Flurl has it's own deserializer so it's better to do it like demonstrated in GetDeserializedReleases method
    public string GetReleases(string url)
    {
      var result = url
          .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
          .GetJsonAsync<List<PostmanRelease>>()
          .Result;

      return JsonConvert.SerializeObject(result);
    }

    public List<PostmanRelease> GetDeserializedReleases(string url)
    {
      var result = url
          .WithHeader(RequestConstants.UserAgent, RequestConstants.UserAgentValue)
          .GetJsonAsync<List<PostmanRelease>>()
          .Result;

      return result;
    }
  }
}
