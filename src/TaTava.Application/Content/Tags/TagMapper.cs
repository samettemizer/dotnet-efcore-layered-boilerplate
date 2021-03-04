using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.Tags.Dtos;

namespace TaTava.Content.Tags
{
    public static class TagMapper
    {
        public static IQueryable<TagListOutputDto> ToTagListOutput(this IQueryable<Tag> tags)
        {
            return tags.Select(tagListOutput => new TagListOutputDto
            {
                Title = tagListOutput.Title,
                Url = tagListOutput.Url
            });
        }
        public static Tag ToTagEntity(this InsertTagInputDto input)
        {
            return new Tag(input.Title)
            {
                Url = input.Url
            };
        }
        public static Tag ToUpdateTagEntity(this Tag tag, UpdateTagInputDto input)
        {
            tag.SetTitle(input.Title);
            tag.Url = input.Url;

            return tag;
        }
    }
}
