using ApiWithPostman.Constants;
using ApiWithPostman.Model;
using ApiWithPostman.RequestHandlers;
using Newtonsoft.Json;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using WebFromWord = Microsoft.Office.Interop.Word;

namespace ApiWithPostman
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Users;\n----------------------------------------------------------");
      Console.WriteLine();

      //These are the ways to consume RESTful APIs as described in the blog post
      IRequestHandler httpWebRequestHandler = new HttpWebRequestHandler();
      IRequestHandler webClientRequestHandler = new WebClientRequestHandler();
      IRequestHandler httpClientRequestHandler = new HttpClientRequestHandler();
      IRequestHandler restSharpRequestHandler = new RestSharpRequestHandler();
      IRequestHandler serviceStackRequestHandler = new ServiceStackRequestHandler();
      IRequestHandler flurlRequestHandler = new FlurlRequestHandler();
      IRequestHandler dalSoftRequestHandler = new DalSoftRequestHandler();

      //to support github's depreciation of older cryptographic standards (might be useful for some other APIs too)
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

      //By default HttpWebRequest is used to get the RestSharp releasesl
      //Replace the httpWebRequestHandler variable with one of the above to test out different libraries
      //Results should be the same
      var response = GetReleases(httpWebRequestHandler);

      var postmanReleases = JsonConvert.DeserializeObject<List<PostmanRelease>>(response);


      WebFromWord.Application word = new WebFromWord.Application();
      word.Visible = true;
      WebFromWord.Document document;
      object wordObj = System.Reflection.Missing.Value;
      document = word.Documents.Add(ref wordObj);
      
      foreach (var release in postmanReleases)
      {

        Console.WriteLine("Id: {0}", release.Id);
        Console.WriteLine("Name: {0}", release.Name);
        Console.WriteLine("UserName: {0}", release.UserName);
        Console.WriteLine("Email: {0}", release.Email);
        Console.WriteLine("----------------------------------------");


        word.Selection.TypeText("Id : ");
        word.Selection.TypeText(release.Id.ToString());
        word.Selection.TypeText(" ");
        word.Selection.TypeText("Name : ");
        word.Selection.TypeText(release.Name);
        word.Selection.TypeText(" ");
        word.Selection.TypeText("UserName : ");
        word.Selection.TypeText(release.UserName);
        word.Selection.TypeText(" ");
        word.Selection.TypeText("Email : ");
        word.Selection.TypeText(release.Email);
        word.Selection.TypeText(" ");
        word.Selection.TypeText("\n");


      }

      Console.ReadLine();
    }

    public static string GetReleases(IRequestHandler requestHandler)
    {
      return requestHandler.GetReleases(RequestConstants.url);
    }
  }
}

