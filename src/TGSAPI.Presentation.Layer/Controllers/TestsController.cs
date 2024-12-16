using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TGS.Infra.Core.EF.Contracts;
using TGSAPI.Domain.Layer.Contracts;
using TGSAPI.Domain.Layer.Entities;

namespace TGSAPI.Presentation.Layer.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TestsController : ControllerBase
  {
    private readonly IProductRepository productRepository;
    private readonly ICategoryRepository categoryRepository;
    private readonly IUnitOfwork unitOfwork;
    public TestsController(IProductRepository productRepository, ICategoryRepository categoryRepository, IUnitOfwork unitOfwork)
    {
      this.productRepository = productRepository;
      this.categoryRepository = categoryRepository;
      this.unitOfwork = unitOfwork;
    }

    [HttpPost]
    public async Task<IActionResult> Test()
    {
      var p = new Product { Name = "Test10011" };
      var c = new Category { Name = "KategoriTest11" };

      await productRepository.CreateAsync(p);
      await categoryRepository.CreateAsync(c);
      await unitOfwork.CommitAsync();

      return Ok();
    }
  }
}
