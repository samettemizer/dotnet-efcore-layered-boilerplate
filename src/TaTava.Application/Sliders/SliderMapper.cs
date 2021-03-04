using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Sliders.Dtos;

namespace TaTava.Sliders
{
    public static class SliderMapper
    {
        public static IQueryable<SliderListOutputDto> ToSliderListEntity(this IQueryable<Slider> sliders)
        {
            return sliders.Select(sliderList => new SliderListOutputDto
            {
                Id = sliderList.Id,
                Title = sliderList.Title,
                Url = sliderList.Url
            });
        }
        public static Slider ToSliderInsertEntity (this InsertSliderInputDto input)
        {
            return new Slider(input.Title)
            {
                Url = input.Url
            };
        }
        public static Slider ToSliderUpdateEntity(this Slider slider , UpdateSliderInputDto input)
        {
            slider.SetTitle(input.Title);
            slider.Url = input.Url;

            return slider;
        }
    }
}
