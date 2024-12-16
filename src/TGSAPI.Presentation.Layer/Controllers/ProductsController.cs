using MediatR;
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
    private readonly IMediator mediator; // In Direction
    public ProductsController(ICreateProductApplicationService createProductApplicationService, IMediator mediator)
    {
      this.createProductApplicationService = createProductApplicationService;
      ;
      this.mediator = mediator;
    }

    // Not: Her request bir tane request handler üzerinden tanımlanmalıdır.
    // Yoksa request Mediator Object üzerinden hangi handler'a yönleneceiğini program bilemez.


    [HttpPost("createV2")]
    public async Task<IActionResult> POST([FromBody] CreateProductRequest request)
    {
      await this.mediator.Send(request);

      return Created();

    }

    [HttpPost]
    public async Task<IActionResult> POST([FromBody] CreateProductDto request)
    {
   
      await this.createProductApplicationService.HandleAsync(request);

      return Created();

    }


  }
}
