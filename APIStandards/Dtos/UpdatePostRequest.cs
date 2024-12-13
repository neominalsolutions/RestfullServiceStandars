using System.Text.Json.Serialization;

namespace APIStandards.Dtos
{

  public record UpdatePostRequest([property: JsonPropertyName("_title")] string Title, [property: JsonPropertyName("_description")] string Description);
}
