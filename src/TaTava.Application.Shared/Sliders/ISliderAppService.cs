using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared;
using TaTava.Application.Shared.Dtos;
using TaTava.Infrastructure;
using TaTava.Sliders.Dtos;

namespace TaTava.Sliders
{
    public interface ISliderAppService:IApplicationService
    {
        Task<ServiceResult<IQueryable<SliderListOutputDto>>> GetAllSliders();
        Task<ServiceResult> InsertSliderInput(InsertSliderInputDto input);
        Task<ServiceResult> UpdateSliderInput(UpdateSliderInputDto input);
        Task<ServiceResult> DeleteSliderInput(EntityDto<Guid> input);
    }
}
