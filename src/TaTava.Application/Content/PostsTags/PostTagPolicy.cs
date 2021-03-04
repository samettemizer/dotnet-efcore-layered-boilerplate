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

namespace TaTava.Content.PostsTags
{
    public class PostTagPolicy:BasePolicy
    {
        private readonly IRepository<PostTag,Guid> _postTagPolicy;
        public PostTagPolicy(IRepository<PostTag,Guid> postTagPolicy)
        {
            postTagPolicy = _postTagPolicy;
        }
        public async Task<ServiceResult> IsPostTagExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
            {
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
            }
            var isPostTagExistById = await _postTagPolicy.Any(postTag => postTag.Id == input.Id);
            if (!isPostTagExistById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz id ile kayıtlı gönderi bulunamadı, lütfen kontrol ediniz. Gönderi etiket Id:{input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
    }
}
