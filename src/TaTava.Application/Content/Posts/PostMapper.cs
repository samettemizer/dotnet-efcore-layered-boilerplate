using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.Posts.Dtos;

namespace TaTava.Content.Posts
{
    public static class PostMapper
    {
        public static IQueryable<PostListOutputDto> ToPostListOutput(this IQueryable<Post> posts)
        {
            return posts.Select(postListOutput => new PostListOutputDto
            {
                Id = postListOutput.Id,
                Title = postListOutput.Title,
                Content = postListOutput.Content,
                PublishDate = postListOutput.PublishDate,
                Published = postListOutput.Published,
                QueueNumber = postListOutput.QueueNumber,
                Url = postListOutput.Url
            });
        }

        public static Post ToPostEntity(this InsertPostInputDto input)
        {
            return new Post(input.Title,input.Content)
            {
                PublishDate = input.PublishDate,
                Published = input.Published,
                QueueNumber = input.QueueNumber,
                Url = input.Url
            };
        }
        public static Post ToUpdatePostEntity(this Post post, UpdatePostInputDto input)
        {
            post.SetTitle(input.Title);
            post.SetContent(input.Content);

            post.PublishDate = input.PublishDate;
            post.Published = input.Published;
            post.QueueNumber = input.QueueNumber;
            post.Url = input.Url;

            return post;
        }
    }
}
