using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Content.Posts.Dtos;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Content.Posts
{
    public class PostAppService : BaseAppService, IPostAppService
    {
        private readonly IRepository<Post,Guid> _postRepository;
        private readonly PostPolicy _postPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public PostAppService(IRepository<Post, Guid> postRepository, PostPolicy postPolicy,IUnitOfWork unitOfWork)
        {
            _postRepository = postRepository;
            _postPolicy = postPolicy;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult> DeletePost(EntityDto<Guid> input)
        {
            var isPostExistById = await _postPolicy.IsPostExistById(new EntityDto<Guid> { Id = input.Id });

            if (isPostExistById.IsFailed) return isPostExistById;

            await _postRepository.Delete(post => post.Id == input.Id);

            _unitOfWork.SaveChanges();

            return new ServiceResult(Status.Success)
            {
                Message = string.Format(ServiceMessages.DeleteSuccessful, "Gönderi")
            };
        }

        public async Task<ServiceResult<IQueryable<PostListOutputDto>>> GetAllPosts()
        {
            var allPosts = await _postRepository.GetQueryableAsync(post => !post.IsDeleted);

            return new ServiceResult<IQueryable<PostListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allPosts.Count(), "Gönderi"),
                Object = allPosts.ToPostListOutput()
            };
        }

        public async Task<ServiceResult> InsertPostInput(InsertPostInputDto input)
        {
            var isPostTakenBySomeone = await _postPolicy.SameTitle(input.Title);

            if (isPostTakenBySomeone.IsFailed)
            {
                return new ServiceResult(Status.Warning) { Message = isPostTakenBySomeone.Message };
            }

            try
            {
                var addPostId = await _postRepository.InsertAndGetIdAsync(input.ToPostEntity());

                _unitOfWork.SaveChanges();

                return new ServiceResult<Guid>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Gönderi"),
                    Object = addPostId
                };
            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error) { Message = string.Format("Gönderi kaydı eklerken bir hata oluştu. Sebebi; {0}", e.Message) };

            }
        }

        public async Task<ServiceResult> UpdatePostInput(UpdatePostInputDto input)
        {
            var IsPostExistById = await _postPolicy.IsPostExistById(new EntityDto<Guid> { Id = input.Id });

            if (IsPostExistById.IsFailed)
                return new ServiceResult(IsPostExistById.Status)
                {
                    Message = IsPostExistById.Message
                };

            var postToUpdate = await _postRepository.GetAsync(post => post.Id == input.Id);
            try
            {
                await _postRepository.Update(postToUpdate.ToUpdatePostEntity(input));

                _unitOfWork.SaveChanges();

                return new ServiceResult(Status.Success)
                {
                    Message = $"{input.Title} adlı gönderi başarıyla güncellenmiştir."
                };
            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error)
                {
                    Message = string.Format($"{input.Title} adlı gönderi düzenlenirken bir hata oluştu. Sebebi; {0}", e.Message)
                };
            }
        }
    }
}
