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

namespace TaTava.Content.Posts
{
    public class PostPolicy:BasePolicy
    {
        private readonly IRepository<Post,Guid> _postRepository;

        public PostPolicy(IRepository<Post,Guid> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUsedAnySomeone = await _postRepository.Any(post => post.Title == title);

            if (isThisTitleUsedAnySomeone)
            {
                var errorMessage = $"Sistemde aynı başlıktan bulunmaktadır. Başlığın adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }

        public async Task<ServiceResult> IsPostExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
            {
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
            }

            var IsPostExistById = await _postRepository.Any(post => post.Id == input.Id);

            if (!IsPostExistById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz id ile kayıtlı gönderi bulunamadı, lütfen kontrol ediniz. Gönderi Id:{input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
    }
}
