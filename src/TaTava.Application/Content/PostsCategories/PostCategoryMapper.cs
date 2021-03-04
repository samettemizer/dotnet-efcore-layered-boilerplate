using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.PostsCategories;
using TaTava.Content.PostsCategories.Dtos;

namespace TaTava.Content.PostsCategories
{
    public static class PostCategoryMapper
    {
        public static IQueryable<PostCategoryListOutputDto> ToPostCategoryListOutput(this IQueryable<PostCategory> postCategories)
        {
            return postCategories.Select(postCategoryList => new PostCategoryListOutputDto
            {
                Id = postCategoryList.Id,
                PostId = postCategoryList.PostId,
                CategoryId = postCategoryList.CategoryId
            });
        }

        public static PostCategory ToPostCategoryEntity(this InsertPostCategoryInputDto input)
        {
            return new PostCategory(input.PostId,input.CategoryId)
            {
            };
        }
    }
}
