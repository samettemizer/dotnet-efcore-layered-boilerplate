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

namespace TaTava.Content.Tags
{
    public class TagPolicy:BasePolicy
    {
        private readonly IRepository<Tag,Guid> _tagPolicyRepository;

        public TagPolicy(IRepository<Tag, Guid> tagPolicyRepository)
        {
            _tagPolicyRepository = tagPolicyRepository;
        }
        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUseAnySomeone = await _tagPolicyRepository.Any(tag => tag.Title == title);

            if (isThisTitleUseAnySomeone)
            {
                var errorMessage = $"Sistemde bu etiket adında etiket bulunmuştur. Etiket adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> IsTagExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
            {
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
            }
            var isTagExistById = await _tagPolicyRepository.Any(tag => tag.Id == input.Id);

            if (!isTagExistById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz id ile kayıtlı etiket bulunamadı, lütfen kontrol ediniz. Etiket Id:{input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
    }
}
