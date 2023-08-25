using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestAPI.Application.Repositories;
using RestAPI.Application.Services;
using RestAPI.Application.ViewModels.Products;
using RestAPI.Domain.Entities;

namespace RestAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        readonly IFileService _fileService;
        readonly IFileWriteRepository _fileWriteRepository; 
        readonly IFileReadRepository _fileReadRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository,
            ICustomerReadRepository customerReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IFileService fileService,
            IProductImageFileReadRepository productImageFileReadRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerReadRepository = customerReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var totalCount = _productReadRepository.GetAll(false).Count();
            var products = _productReadRepository.GetAll(false).Select(p => new
            {
                p.Id,
                p.Name,
                p.Category,
                p.Price,
                p.Stock,
                p.CreatedDate,
                p.UpdateDate
            });
            return Ok(new
            {
                totalCount,
                products
            }); // herhangi bir islem yok o nedenle tracking gereksiz, false vererek traking sonlandir
            
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id, false));
        }
        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
           await _productWriteRepository.AddAsync((new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
                Category = model.Category
            }));
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            product.Category = model.Category;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]    
        public async Task<IActionResult> Delete(string id   )
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok() ;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
           List<(string fileName, string path)> result = await 
                _fileService.UploadAsync("resource/product-images", Request.Form.Files);

           await _productImageFileWriteRepository.AddRangeAsync(result.Select(a => new ProductImageFile
            {
                FileName = a.fileName,
                Path = a.path
            }).ToList());
            await _productImageFileWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
