using System.Linq;
using TaTava.Categories.Dtos;

namespace TaTava.Categories
{
    public static class CategoryMapper
    {
        public static IQueryable<CategoryListOutputDto> ToCategoryListOutput(this IQueryable<Category> categories)
        {
            return categories.Select(categoryListOutput => new CategoryListOutputDto
            {
                Id = categoryListOutput.Id,
                Title = categoryListOutput.Title,
                CreationTime = categoryListOutput.CreationTime
            });
        }
        public static Category ToCategoryEntity(this InsertCategoryInputDto input)
        {
            return new Category(input.Title)
            {
            };
        }
        public static Category ToUpdateCategoryEntity(this Category category, UpdateCategoryInputDto input)
        {
            category.SetTitle(input.Title);

            return category;      
        }
    }
}