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
using TaTava.Sliders;
using TaTava.Sliders.Dtos;

namespace TaTava.Sliders
{
    public class SliderAppService : BaseAppService, ISliderAppService
    {
        private readonly IRepository<Slider, Guid> _sliderRepository;
        private readonly SliderPolicy _sliderPolicy;
        private readonly IUnitOfWork _unitOfWork;
        public SliderAppService(IRepository<Slider,Guid> sliderRepository,SliderPolicy sliderPolicy, IUnitOfWork unitOfWork)
        {
            _sliderRepository = sliderRepository;
            _sliderPolicy = sliderPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeleteSliderInput(EntityDto<Guid> input)
        {
            var isSliderExistById = await _sliderPolicy.IsSliderExistById(new EntityDto<Guid> { Id =input.Id});

            if (isSliderExistById.IsFailed)
            {
                return new ServiceResult(isSliderExistById.Status) { Message = isSliderExistById.Message };
            }
            await _sliderRepository.Delete(slider => slider.Id == input.Id);
            _unitOfWork.SaveChanges();
            return new ServiceResult(Status.Success){ Message = string.Format(ServiceMessages.DeleteSuccessful) };

        }

        public async Task<ServiceResult<IQueryable<SliderListOutputDto>>> GetAllSliders()
        {
            var allSliders = await _sliderRepository.GetQueryableAsync(slider => !slider.IsDeleted);

            return new ServiceResult<IQueryable<SliderListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allSliders.Count(), "Slayt"),
                Object = allSliders.ToSliderListEntity()
            };
        }

        public async Task<ServiceResult> InsertSliderInput(InsertSliderInputDto input)
        {
            var isSliderTakenBySomeone = await _sliderPolicy.SameTitle(input.Title);
            if (isSliderTakenBySomeone.IsFailed)
                return new ServiceResult(Status.Warning) { Message = isSliderTakenBySomeone.Message };

            try
            {
                var addedSlider = await _sliderRepository.InsertAndGetIdAsync(input.ToSliderInsertEntity());
                _unitOfWork.SaveChanges();
                return new ServiceResult<Guid>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Slayt"),
                    Object = addedSlider
                };
            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error)
                {
                    Message = string.Format("Slayt kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message)
                };
            }
        }

        public async Task<ServiceResult> UpdateSliderInput(UpdateSliderInputDto input)
        {
            var isSliderExistById = await _sliderPolicy.IsSliderExistById(new EntityDto<Guid> { Id = input.Id });
            if (isSliderExistById.IsFailed)
            {
                return new ServiceResult(isSliderExistById.Status) { Message = isSliderExistById.Message };
            }
               var sliderToUpdate = await _sliderRepository.GetAsync(slider => slider.Id == input.Id);
            try
            {
                await _sliderRepository.Update(sliderToUpdate.ToSliderUpdateEntity(input));
                _unitOfWork.SaveChanges();

                return new ServiceResult(Status.Success)
                {
                    Message= $"{input.Title} adlı slayt güncellemiştir."
                };
            }
            catch (Exception e)
            {
             return new ServiceResult(Status.Error)
                { Message = string.Format($"{input.Title} adlı slayt bilgilerini düzenlerken bir hata oluştu. Sebebi;{0}", e.Message) };
            }
        }
    }
}
