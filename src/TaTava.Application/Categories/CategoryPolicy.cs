using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.Categories;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Content.Categories
{
    public class CategoryPolicy: BasePolicy
    {
        private readonly IRepository<Category, Guid> _categoryRepository;

        public CategoryPolicy(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUsedNySomeone = await _categoryRepository.Any(category => category.Title == title);

            if (isThisTitleUsedNySomeone)
            {
                var errorMessage = $"Sistemde bu kategori adında kategori bulunmaktadır. Kategori adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> IsCategoryExistById(EntityDto<Guid> input)
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck)
                return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };
           
            var isCategoryExistById = await _categoryRepository.Any(category => category.Id == input.Id);

            if (!isCategoryExistById)
            {
                var errorMessage = $"Sistemde vermiş olduğunuz id ile kayıtlı kategori bulunamadı,lütfen kontrol ediniz. Kategor Id:{input.Id}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }

            return new ServiceResult(Status.Success);
        }
    }
}
