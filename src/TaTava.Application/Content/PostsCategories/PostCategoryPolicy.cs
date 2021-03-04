using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Content.PostsCategories;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Application.Content.PostsCategories
{
    public class PostCategoryPolicy:BasePolicy
    {
        private readonly IRepository<PostCategory,Guid> _postCategoryrepository;

        public PostCategoryPolicy(IRepository<PostCategory, Guid> postCategoryrepository)
        {
            _postCategoryrepository = postCategoryrepository;
        }

        public async Task<ServiceResult> IsPostCategoryExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
            {
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
            }

            var IsPostCategoryExistById = await _postCategoryrepository.Any(postCategory => postCategory.Id == input.Id);

            if (!IsPostCategoryExistById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz id ile kayıtlı gönderi bulunamadı, lütfen kontrol ediniz. Gönderi Id:{input.Id}";
                return new ServiceResult(Status.Error) { Message = errorMessage };
            }

            return new ServiceResult(Status.Success);
        }
    }
}
