using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.PostsTags;
using TaTava.Content.PostsTags.Dtos;

namespace TaTava.Content.PostsTags
{
    public static class PostTagMapper
    {
        public static IQueryable<PostTagListOutputDto> ToPostTagListOutput(this IQueryable<PostTag> postTags)
        {
            return postTags.Select(postTagList => new PostTagListOutputDto
            {
                Id = postTagList.Id,
                PostId = postTagList.PostId,
                TagId = postTagList.TagId
            });
        }
        public static PostTag ToPostTagEntity(this InsertPostTagInput input)
        {
            return new PostTag(input.PostId, input.TagId) { };
        }
    }
}
