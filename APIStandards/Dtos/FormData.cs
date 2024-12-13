namespace APIStandards.Dtos
{
  public record FormData(string name,string description, IEnumerable<IFormFile> files);

}
