using ApiWithPostman.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWithPostman.RequestHandlers
{
  public class RestSharpRequestHandler : IRequestHandler
  {
    public string GetReleases(string url)
    {
      var client = new RestClient(url);

      var response = client.Execute(new RestRequest());

      return response.Content;
    }

    //Alternative way, using RestSharp's parser
    public List<PostmanRelease> GetDeserializedReleases(string url)
    {
      var client = new RestClient(url);

      var response = client.Execute<List<PostmanRelease>>(new RestRequest());

      return response.Data;
    }
  }
}
