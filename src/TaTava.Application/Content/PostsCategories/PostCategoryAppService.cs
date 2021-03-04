using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Content.PostsCategories;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Content.PostsCategories;
using TaTava.Content.PostsCategories.Dtos;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Content.PostsCategories
{
    public class PostCategoryAppService : BaseAppService, IPostCategoryAppService
    {
        private readonly IRepository<PostCategory,Guid> _postCategoryRepository;
        private readonly PostCategoryPolicy _postCategoryPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public PostCategoryAppService(IRepository<PostCategory, Guid> postCategoryRepository, PostCategoryPolicy postCategoryPolicy , IUnitOfWork unitOfWork)
        {
            _postCategoryRepository = postCategoryRepository;
            _postCategoryPolicy = postCategoryPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeletePostCategory(EntityDto<Guid> input)
        {
            var isPostCategoryExistById = await _postCategoryPolicy.IsPostCategoryExistById(new EntityDto<Guid> { Id = input.Id });
            if (isPostCategoryExistById.IsFailed) return isPostCategoryExistById;

            await _postCategoryRepository.Delete(postCategory => postCategory.Id == input.Id);

            _unitOfWork.SaveChanges();

            return new ServiceResult(Status.Success)
            {
                Message = string.Format(ServiceMessages.DeleteSuccessful, "Item")
            };
            
        }

        public async Task<ServiceResult<IQueryable<PostCategoryListOutputDto>>> GetAllPostCategory()
        {
            var allPostCategories = await _postCategoryRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<PostCategoryListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allPostCategories.Count(), "Item"),
                Object = allPostCategories.ToPostCategoryListOutput()
            };

        }

        public async Task<ServiceResult> InsertPostCategoryInput(InsertPostCategoryInputDto input)
        {
            try
            {
                var addPostCategoryId = await _postCategoryRepository.InsertAndGetIdAsync(input.ToPostCategoryEntity());
                _unitOfWork.SaveChanges();

                return new ServiceResult<Guid>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Gönderi"),
                    Object = addPostCategoryId
                };
            }
            catch (Exception e)
            {

                return new ServiceResult(Status.Error)
                { Message = string.Format("Gönderi kaydı eklerken bir hata oluştu. Sebebi; {0}", e.Message) };
            }
        }
    }
}
