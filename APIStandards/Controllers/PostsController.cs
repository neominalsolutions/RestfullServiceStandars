using APIStandards.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace APIStandards.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    // api/posts GET  => Status 200
    // api/posts POST => Status 201
    // api/posts/id GET => Status 200
    // api/posts/id DELETE => Status 204
    // api/posts/id PUT => Status 204

    //[JsonConstructor]
    //public PostsController()
    //{

    //}


    [HttpGet]
    public IActionResult Get()
    {
      return Ok(); // Status Code 200 döner
    }


    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
      return Ok();
    }


    [HttpPost]
    public IActionResult Post([FromBody] CreatePostRequest request)
    {
      // request.Description = "sadsad";

      //var request1 = new CreatePostRequest(Title:"Makale1",Description:"Deneme1");

      //var request2 = new CreatePostRequest(Title: "Makale1", Description: "Deneme1");

      //request1.Equals(request2); // true , class olsaydı refransa bakacak ve false dönecekti.


      return Created("/api/posts/1", request); // 201
    }


    [HttpPut("{id}")]
    public IActionResult PUT([FromRoute] int id,[FromBody]  UpdatePostRequest request)
    {

      return NoContent(); // 204
    }

    [HttpDelete("{id}")]
    public IActionResult DELETE([FromRoute] int id)
    {
      return NoContent();
    }


    [HttpPatch("{id}/update-title")]
    public IActionResult PATCH([FromRoute] int id,[FromBody] UpdateTitleRequest request)
    {
      return NoContent();
    }

    // Nested Routing
    // api/posts/{id}/comments GET
    // api/posts/{id}/comments/{id} GET

    [HttpGet("{postId}/comments")]
    public IActionResult GetCommentsByPostId([FromRoute] int postId, [FromBody] GetPostCommentsRequest request)
    {
      return Ok();
    }


    [HttpGet("{postId}/comments/{commentId}")]
    public IActionResult GetCommentByIdByPostId([FromRoute] int postId, [FromRoute] int commentId, [FromBody] GetPostCommentsRequest request)
    {
      return Ok();
    }

    //[HttpGet("client-name-from-headers")]
    [HttpPost("clientNameFromHeaders")]
    public IActionResult GetRequest([FromHeader] string clientName)
    {
      return Ok();
    }

    // api da sırlama,sayfalama,filtereleme işlemlerine ait client da yapılan işlemin sunucu tarafına aktarolması için
    // serverside işlemleri için bu şekilde yapalım.
    [HttpPost("q")]
    public IActionResult GetQueryString([FromQuery] int pageSize, [FromQuery] string searchText, [FromQuery] string sortBy = "asc")
    {
      return Ok();
    }


    [HttpPost("form-data")]
    public IActionResult PostFormData([FromForm] FormData request)
    {
      return Ok();
    }

    // Headerdan veri yakalama
    // query stringden veri yakalama




  }
}
