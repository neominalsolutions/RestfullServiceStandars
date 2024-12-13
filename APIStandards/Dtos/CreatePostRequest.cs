using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIStandards.Dtos
{
  public record CreatePostRequest([property: JsonPropertyName("_title")] string  Title, [property: JsonIgnore()] string Description);


  
}
