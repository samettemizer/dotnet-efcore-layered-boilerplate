using TaTava.Extensions;
using TaTava.Sliders.Dtos;

namespace TaTava.Web.Host.Validators.Slider
{
    public class InsertSliderInputValidator : BaseDtoValidator<InsertSliderInputDto>
    {
        public InsertSliderInputValidator()
        {
            RuleFor(slider => slider.Title)
            .HasMaximumLength(300,"Slayt Basşlık")
            .NullOrEmpty("Slayt Başlık");
        }        
    }
}