using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Content.Tags;
using TaTava.Content.Tags.Dtos;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Content.Tags
{
    public class TagAppService : BaseAppService, ITagAppService
    {
        private readonly IRepository<Tag, Guid> _tagRepository;
        private readonly TagPolicy _tagPolicy;
        IUnitOfWork _unitOfWork;
        public TagAppService(IRepository<Tag,Guid> tagRepository, TagPolicy tagPolicy, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _tagPolicy = tagPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeleteTag(EntityDto<Guid> input)
        {
            var isTagExistById = await _tagPolicy.IsTagExistById(input);

            if (isTagExistById.IsFailed) return isTagExistById;

            await _tagRepository.Delete(tag => tag.Id == input.Id);
            _unitOfWork.SaveChanges();

            return new ServiceResult(Status.Success)
            {
                Message = string.Format(ServiceMessages.DeleteSuccessful, "Etiket")
            };
        }

        public async Task<ServiceResult<IQueryable<TagListOutputDto>>> GetAllTag()
        {
            var allTags = await _tagRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<TagListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allTags.Count(), "Etiket"),
                Object = allTags.ToTagListOutput()
            };
        }
        public async Task<ServiceResult> InsertTagInput(InsertTagInputDto input)
        {
            var isTagTakenBySomeone = await _tagPolicy.SameTitle(input.Title);

            if (isTagTakenBySomeone.IsFailed)
            {
                return new ServiceResult<Guid>(Status.Warning) { Message = isTagTakenBySomeone.Message };
            }

            var addedTagId = await _tagRepository.InsertAndGetIdAsync(input.ToTagEntity());
            _unitOfWork.SaveChanges();

            return new ServiceResult<Guid>(Status.Success)
            {
                Message = string.Format(ServiceMessages.InsertSuccessful, "Etiket"),
                Object = addedTagId
            };

        }

        public async Task<ServiceResult> UpdateTagInput(UpdateTagInputDto input)
        {
            var isTagExistById = await _tagPolicy.IsTagExistById(new EntityDto<Guid> { Id =input.Id});

            if (isTagExistById.IsFailed)
            {
                return new ServiceResult(isTagExistById.Status) { Message = isTagExistById.Message };
            }

            var postToUpdate = await _tagRepository.GetAsync(tag => tag.Id == input.Id);
            try
            {
                await _tagRepository.Update(postToUpdate.ToUpdateTagEntity(input));
                _unitOfWork.SaveChanges();
                return new ServiceResult(Status.Success)
                {
                    Message = $"{input.Title} adlı etiket başarıyla düzenlenmiştir."
                };
            }
            catch (Exception e)
            {

                return new ServiceResult(Status.Error)
                {
                    Message = string.Format($"{input.Title} adlı etiket düzenlerken bir hata oluştu. Sebebi; {0}", e.Message)
                };
            }
        }
    }
}
