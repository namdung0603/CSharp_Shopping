using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping.ApplicationService.DTO.Request;
using Shopping.ApplicationService.DTO.Response;
using Shopping.Contract;
using Shopping.Infrastructure.Models;

namespace Shopping.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UserController(IRepositoryWrapper repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllUser() {
            try {
                var users = _repository.UserRepository.GetAllUser();
                var usersResult = _mapper.Map<IEnumerable<UserResponse>>(users);
                return Ok(usersResult);
            }
            catch (Exception ex) {
                return BadRequest("Loi cmnr kia!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) {
            var user = _repository.UserRepository.GetUserById(id);
            if (user != null) {
                var userResponse = _mapper.Map<UserResponse>(user);
                return Ok(userResponse);
            }
            return BadRequest("Lay duoc del dau!");
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest userRequest) {
            var user = _mapper.Map<User>(userRequest);// 
            if (user is null) {
                return BadRequest("Dmm! Tao duoc deo dau!");
            }
            if (!ModelState.IsValid) {
                return BadRequest("Conme may sai roi kia!");
            }
            var userSave = _mapper.Map<User>(userRequest);// tạo mới một đối tượng User
            _repository.UserRepository.CreateUser(userSave);
            _repository.Save();
            var userSaveResponse = _mapper.Map<UserResponse>(userSave);
            return Ok(userSaveResponse);
        }

        [HttpPut]
        public IActionResult UpdateUser(int id, [FromBody] UserRequest userRequest) {
            if (userRequest is null) {
                return BadRequest("Thong tin cap nhan trong conmeno roi kia. Dien di!");
            }
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return BadRequest($"Id = {id} co ton tai meo dau ma tim!");
            }

            _mapper.Map(userRequest, user);// Cập nhật dữ liệu sẵn có vào 1 User sẵn có
            _repository.UserRepository.UpdateUser(user);
            _repository.Save();
            return Ok("Update roi nhe baby!");

        }
    }
}
