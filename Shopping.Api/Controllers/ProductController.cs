using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.ApplicationService.DTO.Request.Product;
using Shopping.Contract;
using Shopping.Infrastructure.Models;

namespace Shopping.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        public ProductController(IRepositoryWrapper repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProducts() {
            var products = _repository.ProductRepository.GetAllProduct();
            if (products == null) {
                return BadRequest("Lam del gi co san pham ma lay!");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id) {
            var product = _repository.ProductRepository.GetProductById(id);
            if (product == null) {
                return BadRequest("Khong co dau!");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewProduct([FromBody] ProductRequest productRequest) {
            if (productRequest is null) {
                return BadRequest("Co loi xay ra trong qua trinh tao san pham! Tao san pham that bai!");
            }

            var product = _mapper.Map<Product>(productRequest);
            if (product is null) {
                return BadRequest("Khong the tao duoc doi tuong!");
            }

            if (!ModelState.IsValid) {
                return BadRequest("Du lieu khong hop le!");
            }

            foreach (string category in productRequest.Categories) {
                var categoryModel = await _repository.CategoryRepository.GetCategoryByNameAsync(category);
                if (categoryModel is null) {
                    return BadRequest("Bi loi trong qua trinh gan category! Co category khong ton tai!");
                }
                product.Categories.Add(categoryModel);
            }

            return Ok(product);
        }
    }
}
