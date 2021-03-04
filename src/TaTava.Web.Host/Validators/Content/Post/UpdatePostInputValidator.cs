using System;
using TaTava.Content.Posts.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Content.Post
{
    public class UpdatePostInputValidator : BaseDtoValidator<UpdatePostInputDto,Guid>
    {
        public UpdatePostInputValidator()
        {
            RuleFor(post => post.Title)
                .HasMaximumLength(150,"Gönderi Başlığı")
                .NullOrEmpty("Gönderi Başlığı");
            
            RuleFor(post => post.Content)
                .HasMaximumLength(int.MaxValue, "İçerik")
                .NullOrEmpty("İçerik");
        }
    }
}