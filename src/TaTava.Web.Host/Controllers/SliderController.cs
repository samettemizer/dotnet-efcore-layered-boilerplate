using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Infrastructure;
using TaTava.Sliders;
using TaTava.Sliders.Dtos;

namespace TaTava.Web.Host.Controllers
{
    public class SliderController : BaseApiController
    {
        private readonly ISliderAppService _sliderAppService;
        public SliderController(ISliderAppService sliderAppService)
        {
            _sliderAppService = sliderAppService;
        }

        [HttpGet]
        public async Task<ServiceResult<IQueryable<SliderListOutputDto>>> Get()
        {
            return await _sliderAppService.GetAllSliders();
        }

        [HttpPost]
        public async Task<ServiceResult> Post(InsertSliderInputDto input)
        {
            return await _sliderAppService.InsertSliderInput(input);
        }

        [HttpPut]
        public async Task<ServiceResult> Put(UpdateSliderInputDto input)
        {
            return await _sliderAppService.UpdateSliderInput(input);
        }

        [HttpDelete]
        public async Task<ServiceResult> Delete(EntityDto<Guid> input)
        {
            return await _sliderAppService.DeleteSliderInput(input);
        }
    }
}
