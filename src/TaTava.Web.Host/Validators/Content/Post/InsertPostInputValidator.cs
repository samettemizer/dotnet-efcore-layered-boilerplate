using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Content.Posts.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Content.Post
{
    public class InsertPostInputValidator:BaseDtoValidator<InsertPostInputDto>
    {
        public InsertPostInputValidator()
        {
            RuleFor(post => post.Title)
                .HasMaximumLength(150, "Gönderi")
                .NullOrEmpty("Gönderi Başlık");

            RuleFor(post => post.Content)
                .HasMaximumLength(int.MaxValue, "İçerik")
                .NullOrEmpty("İçerik");
        }
    }
}
