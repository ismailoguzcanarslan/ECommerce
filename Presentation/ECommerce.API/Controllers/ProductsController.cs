using System.Net;
using ECommerce.Application.Repositories;
using ECommerce.Application.ViewModels.Products;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerseAPI.API.Controllers;

[Route("api/[controller]")]
public class ProductsController : Controller
{
    private readonly IProductWriteRepository _productWriteRepository;
    private readonly IProductReadRepository _productReadRepository;

    public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    [HttpPost]
    [Route("DummyData")]
    public async Task DummyData()
    {
        await _productWriteRepository.AddRangeAsync(new List<ECommerce.Domain.Entities.Product>()
        {
            new (){Id = Guid.NewGuid(), Name = "IPhone 13", Price = 35000, CreatedOn = DateTime.UtcNow, Stock = 120},
            new (){Id = Guid.NewGuid(), Name = "IPhone 13 Pro", Price = 40000, CreatedOn = DateTime.UtcNow, Stock = 56},
            new (){Id = Guid.NewGuid(), Name = "IPhone 13 Pro Max", Price = 45000, CreatedOn = DateTime.UtcNow, Stock = 24}
        });

        await _productWriteRepository.SaveAsync();
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_productReadRepository.GetAll(false));
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById([FromQuery] string id)
    {
        return Ok(await _productReadRepository.GetByIdAsync(id, false));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ProductUpdateViewModel model)
    {
        var p = await _productReadRepository.GetByIdAsync(model.Id);

        p.Stock = model.Stock;
        p.Price = model.Price;
        p.Name = model.Name;

        await _productWriteRepository.SaveAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        await _productWriteRepository.RemoveAsync(id);
        await _productWriteRepository.SaveAsync();
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ProductCreateViewModel model)
    {
            var p = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock

            };

            await _productWriteRepository.AddAsync(p);

            await _productWriteRepository.SaveAsync();

            return StatusCode((int)HttpStatusCode.Created);
        
    }
}

