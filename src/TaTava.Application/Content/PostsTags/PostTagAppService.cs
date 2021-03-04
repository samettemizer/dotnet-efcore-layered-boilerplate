using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Content.PostsTags;
using TaTava.Content.PostsTags.Dtos;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Content.PostsTags
{
    public class PostTagAppService : BaseAppService, IPostTagAppService
    {
        private readonly IRepository<PostTag, Guid> _postTagRepository;
        private readonly PostTagPolicy _postTagPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public PostTagAppService(IRepository<PostTag, Guid> postTagRepository, PostTagPolicy postTagPolicy, IUnitOfWork unitOfWork)
        {
            _postTagRepository = postTagRepository;
            _postTagPolicy = postTagPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeletePostTag(EntityDto<Guid> input)
        {
            var isPostTagExistById = await _postTagPolicy.IsPostTagExistById(input);
            if (isPostTagExistById.IsFailed) return isPostTagExistById;

            await _postTagRepository.Delete(postTag => postTag.Id == input.Id);
            _unitOfWork.SaveChanges();
            return new ServiceResult(Status.Success) { Message =string.Format(ServiceMessages.DeleteSuccessful, "Gönderi Etiketi") };
        }

        public async Task<ServiceResult<IQueryable<PostTagListOutputDto>>> GetAll()
        {
            var allPostTags = await _postTagRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<PostTagListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allPostTags.Count(), "Gönderi Etiketi"),
                Object = allPostTags.ToPostTagListOutput()
            };
        }

        public async Task<ServiceResult> InsertPostTagInput(InsertPostTagInput input)
        {
            try
            {
                var addedPostTagId = await _postTagRepository.InsertAndGetIdAsync(input.ToPostTagEntity());
                _unitOfWork.SaveChanges();
                return new ServiceResult<Guid>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Gönderi Etiketi"),
                    Object = addedPostTagId
                };

            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error)
                { Message = string.Format($"Gönderi etiketi kaydı eklerken bir hata oluştu.Sebebi;{0}", e.Message)};
            }
        }
    }
}
