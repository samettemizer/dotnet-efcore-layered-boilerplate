using System;
using TaTava.Extensions;
using TaTava.Sliders.Dtos;

namespace TaTava.Web.Host.Validators.Slider
{
    public class UpdateSliderInputValidator : BaseDtoValidator<UpdateSliderInputDto,Guid>
    {
        public UpdateSliderInputValidator()
        {
            RuleFor(slider => slider.Title)
            .HasMaximumLength(300,"Slayt Basşlık")
            .NullOrEmpty("Slayt Başlık");
        }
    }
}