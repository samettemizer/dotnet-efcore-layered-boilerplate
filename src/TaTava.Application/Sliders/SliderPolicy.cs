using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Sliders
{
    public class SliderPolicy
    {
        private readonly IRepository<Slider, Guid> _sliderPolicy;
        public SliderPolicy(IRepository<Slider, Guid> sliderPolicy)
        {
            _sliderPolicy = sliderPolicy;
        }
        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUsedSomeone = await _sliderPolicy.Any(slider => slider.Title == title);

            if (isThisTitleUsedSomeone)
            {
                var errorMessage = $"Sistemde bu Slider adında slider bulunmaktadır. Slider adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> IsSliderExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
            {
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
            }

            var isSliderExistById = await _sliderPolicy.Any(slider => slider.Id == input.Id);

            if (!isSliderExistById)
            {
                var errorMessage = $"Sistem vermiş olduğunuz id ile kayıt slider bulunamadı, lütfen kontrol ediniz. Slider Id: {input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
    }
}
