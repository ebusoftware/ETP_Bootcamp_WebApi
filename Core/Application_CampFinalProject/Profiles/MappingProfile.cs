using Application_CampFinalProject.Dtos.Brand;
using Application_CampFinalProject.Dtos.Category;
using Application_CampFinalProject.Dtos.Product;
using Application_CampFinalProject.Dtos.ShoppingList;
using Application_CampFinalProject.Dtos.ShoppingListItem;
using Application_CampFinalProject.Dtos.User;
using Application_CampFinalProject.Features.Commands;
using AutoMapper;
using Domain_CampFinalProject.Entities;
using Domain_CampFinalProject.Entities.Identity;

namespace Application_CampFinalProject.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            //Brand
            CreateMap<Brand,CreateBrandDTO>().ReverseMap();
            CreateMap<Brand,CreateBrandCommand>().ReverseMap();

            CreateMap<Brand,DeleteBrandDTO>().ReverseMap();
            CreateMap<Brand,DeleteBrandCommand>().ReverseMap();

            CreateMap<Brand,UpdateBrandCommand>().ReverseMap();
            CreateMap<Brand,UpdateBrandDTO>().ReverseMap();

            //Category
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CreateCategoryCommand>().ReverseMap();

            CreateMap<Category, DeleteCategoryCommand>().ReverseMap();
            CreateMap<Category, DeleteCategoryDTO>().ReverseMap();

            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();


            //Product
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();

            CreateMap<Product, DeleteProductCommand>().ReverseMap();
            CreateMap<Product, DeleteProductDTO>().ReverseMap();

            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();

            //ShoppingListItem
            CreateMap<ShoppingListItem, CreateShoppingListItemCommand>().ReverseMap();
            CreateMap<ShoppingListItem, CreateShoppingListItemDTO>().ReverseMap();

            CreateMap<ShoppingListItem, UpdateShoppingListItemCommand>().ReverseMap();
            CreateMap<ShoppingListItem, UpdateShoppingListItemDTO>().ReverseMap();

            CreateMap<ShoppingListItem, DeleteShoppingListItemCommand>().ReverseMap();
            CreateMap<ShoppingListItem, DeleteShoppingListItemDTO>().ReverseMap();

            //ShoppingList
            CreateMap<ShoppingList, CreateShoppingListDTO>().ReverseMap();
            CreateMap<ShoppingList, CreateShoppingListCommand>().ReverseMap();

            CreateMap<ShoppingList, DeleteShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingList, DeleteShoppingListDTO>().ReverseMap();

            CreateMap<ShoppingList, UpdateShoppingListCommand>().ReverseMap();
            CreateMap<ShoppingList, UpdateShoppingListDTO>().ReverseMap();

            //AppUser
            CreateMap<AppUser, DeleteUserCommand>().ReverseMap();
            CreateMap<AppUser, DeleteUserDTO>().ReverseMap();
            
            




        }
    }
}
