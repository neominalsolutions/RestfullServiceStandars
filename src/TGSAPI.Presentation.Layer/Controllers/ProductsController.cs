using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TGSAPI.Application.Layer.Contracts;
using TGSAPI.Application.Layer.Requests;

namespace TGSAPI.Presentation.Layer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private ICreateProductApplicationService createProductApplicationService;

    public ProductsController(ICreateProductApplicationService createProductApplicationService)
    {
      this.createProductApplicationService = createProductApplicationService;
      ;
    }

    [HttpPost]
    public async Task<IActionResult> POST([FromBody] CreateProductDto request)
    {
      await this.createProductApplicationService.HandleAsync(request);

      return Created();

    }
  }
}
