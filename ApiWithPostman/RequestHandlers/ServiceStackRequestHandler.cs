using ApiWithPostman.Constants;
using ApiWithPostman.Model;
using ServiceStack;
using System.Collections.Generic;

namespace ApiWithPostman.RequestHandlers
{
  public class ServiceStackRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      var response = url.GetJsonFromUrl(webReq =>
      {
        webReq.UserAgent = RequestConstants.UserAgentValue;
      });

      return response;
    }

    //Alternative way, using ServiceStack's parser
    public List<PostmanRelease> GetDeserializedReleases(string url)
    {
      var releases = url.GetJsonFromUrl(webReq =>
      {
        webReq.UserAgent = RequestConstants.UserAgentValue;
      }).FromJson<List<PostmanRelease>>();

      return releases;
    }
  }
}
