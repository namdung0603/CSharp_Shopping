using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.Contract;

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
    }
}
