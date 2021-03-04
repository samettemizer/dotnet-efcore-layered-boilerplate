using System;
using TaTava.Content.Tags.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Content.Tag
{
    public class UpdateTagInputValidator : BaseDtoValidator<UpdateTagInputDto,Guid>
    {
        public UpdateTagInputValidator()
        {
            RuleFor(tag => tag.Title)
                .HasMaximumLength(150, "Başlık")
                .NullOrEmpty("Etiket Başlık");
        }
    }
}