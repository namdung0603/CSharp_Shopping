using AutoMapper;
using Shopping.ApplicationService.DTO.Request.Product;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.ApplicationService.DTO.Response;
using Shopping.Infrastructure.Models;

namespace Shopping.ApplicationService.Mapping {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<User, UserResponse>();
            CreateMap<RegisterRequest, User>();
            CreateMap<UpdateRequest, User>();
            CreateMap<User, UpdateRequest>();
            CreateMap<ProductRequest, Product>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
            CreateMap<Product, ProductResponse>();
            CreateMap<Category, CategoryResponse>();
            CreateMap<ProductUpdateDetail, Product>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            .ForAllMembers(otp => otp.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Product, ProductUpdateDetail>()
            .ForMember(dest => dest.Categories, opt => opt.Ignore()); //ProductUpdateDetail>

        }
    }
}
