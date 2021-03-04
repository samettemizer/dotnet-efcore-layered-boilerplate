using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Content.Tags.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Content.Tag
{
    public class InsertTagInputValidator : BaseDtoValidator<InsertTagInputDto>
    {
        public InsertTagInputValidator()
        {
            RuleFor(tag => tag.Title)
                .HasMaximumLength(150, "Başlık")
                .NullOrEmpty("Etiket Başlık");
        }
    }
}
