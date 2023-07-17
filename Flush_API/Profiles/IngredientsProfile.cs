using AutoMapper;
using Flush_API.Dtos;
using Flush_API.Models;

namespace Flush_API.Profiles
{
    public class IngredientsProfile : Profile
    {
        public IngredientsProfile() 
        {
            //Source -> Target
            CreateMap<Ingredient, IngredientReadDto>();
            CreateMap<IngredientCreateDto, Ingredient>();
            CreateMap<IngredientUpdateDto, Ingredient>();
        }
    }
}
