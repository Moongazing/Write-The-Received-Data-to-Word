using Newtonsoft.Json;

namespace ApiWithPostman.Model
{
  public class PostmanRelease
  {
    [JsonProperty(PropertyName ="username")]

    public string UserName { get; set; }

    [JsonProperty(PropertyName ="email")]
    public string Email { get; set; }

    [JsonProperty(PropertyName ="id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName ="name")]
    public string Name { get; set; }

  }
}
