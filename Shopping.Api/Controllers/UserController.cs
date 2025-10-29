using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.ApplicationService.DTO.Response;
using Shopping.ApplicationService.Services.IService;
using Shopping.Contract;
using Shopping.Infrastructure.Models;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Shopping.Api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public UserController(IRepositoryWrapper repository, IMapper mapper, IAuthService authService) {
            _repository = repository;
            _mapper = mapper;
            _authService = authService;
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
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest userRequest) {
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

            var hashPassword = new PasswordHasher<User>().HashPassword(user, user.Password);
            user.Password = hashPassword;
            _repository.UserRepository.CreateUser(user);
            _repository.Save();
            var userSaveResponse = _mapper.Map<UserResponse>(user);
            return Ok(userSaveResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest login) {
            var token = await _authService.LoginAsync(login);
            if (token is null) {
                return Unauthorized("Email dang nhap hoac mat khau khong chinh xac!");
            }

            Response.Cookies.Append("refreshToken", token.RefreshToken, new CookieOptions {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(7)
                //Expires = DateTime.UtcNow.AddMinutes(2)
            });


            return Ok(token);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody(EmptyBodyBehavior = EmptyBodyBehavior.Allow)] UpdateRequest? userRequestUpdate) {
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
        public IActionResult UpdateInformationDetail(int id, [FromBody] JsonPatchDocument<UpdateRequest> patchDoc) {
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return NotFound($"Khong tim thay nguoi dung co ID = {id}");
            }
            var userPatch = _mapper.Map<UpdateRequest>(user);
            patchDoc.ApplyTo(userPatch, ModelState);
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _mapper.Map(userPatch, user);
            _repository.UserRepository.UpdateUser(user);
            _repository.Save();
            return Ok("Update thanh cong!");
        }

        [HttpPut("changePass/{id}")]
        public IActionResult ChangePassword(int id, [FromBody] ChangePassword changePassword) {
            var user = _repository.UserRepository.GetUserById(id);
            if (user is null) {
                return NotFound("Nguoi dung khong ton tai trong he thong!");
            }
            var hashPassword = new PasswordHasher<ChangePassword>().HashPassword(changePassword, changePassword.NewPassword);

            user.Password = hashPassword;
            _repository.UserRepository.Update(user);
            _repository.Save();
            return Ok("Doi mat khau thanh cong!");
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokenAccess() {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken)) {

                return Unauthorized("Denied Access!");
            }

            var user = await _repository.UserRepository.GetUserByRefreshToken(refreshToken);
            //Console.WriteLine(user.Fullname);
            if (user is null) {
                return BadRequest("Nguoi dung khong ton tai!");
            }
            var rq = new RefreshTokenRequest {
                RefreshToken = refreshToken,
                UserId = user.Id,
            };
            var newToken = await _authService.RefreshTokenAsync(rq);
            if (newToken is null) {
                return BadRequest("Refresh token bi loi!");
            }
            Response.Cookies.Append("refreshToken", newToken.RefreshToken, new CookieOptions {
                HttpOnly = true,
                Secure = true,
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });
            return Ok(newToken);
        }
    }
}
