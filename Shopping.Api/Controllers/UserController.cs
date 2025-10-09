using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shopping.ApplicationService.DTO.Request;
using Shopping.ApplicationService.DTO.Response;
using Shopping.Contract;
using Shopping.Infrastructure.Models;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CreateUser([FromBody] UserRequestSignin userRequest) {
            if (await _repository.UserRepository.ExistByEmailAsync(userRequest.Email, HttpContext.RequestAborted)) {
                return BadRequest("Conme trung mail roi! Nhap lai di!");
            }
            var user = _mapper.Map<User>(userRequest);// tạo mới một đối tượng User
            if (user is null) {
                return BadRequest("Dmm! Tao duoc deo dau!");
            }
            if (!ModelState.IsValid) {
                return BadRequest("Conme may sai roi kia!");
            }

            _repository.UserRepository.CreateUser(user);
            _repository.Save();
            var userSaveResponse = _mapper.Map<UserResponse>(user);
            return Ok(userSaveResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] UserRequestUpdate? userRequestUpdate) {
            if (await _repository.UserRepository.ExistByEmailAsync(userRequestUpdate.Email, HttpContext.RequestAborted)) {
                return BadRequest("Email ton tai roi! Chon cai khac me di!");
            }
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return NotFound($"Id = {id} co ton tai meo dau ma tim!");
            }
            if (userRequestUpdate is null) {
                return BadRequest("Thong tin cap nhan trong conmeno roi kia. Dien di!");
            }
            _mapper.Map(userRequestUpdate, user);// Cập nhật dữ liệu sẵn có vào 1 User sẵn có
            _repository.UserRepository.UpdateUser(user);
            _repository.Save();
            return Ok("Update roi nhe baby!");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) {
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return NotFound($"Co {id} nay meo dau ma tim!");
            }
            _repository.UserRepository.DeleteUser(user);
            _repository.Save();// sau khi xóa vẫn phải Save???
            return Ok("Xoa duoc roi nhe em yeu!");
        }

        [HttpPatch("{id}")]
        public IActionResult UpdateInformationDetail(int id, [FromBody] JsonPatchDocument<UserRequestUpdate> patchDoc) {
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return NotFound($"Khong tim thay nguoi dung co ID = {id}");
            }
            var userPatch = _mapper.Map<UserRequestUpdate>(user);
            patchDoc.ApplyTo(userPatch, ModelState);
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _mapper.Map(userPatch, user);
            _repository.UserRepository.UpdateUser(user);
            _repository.Save();
            return Ok("Update thanh cong!");
        }
    }
}
