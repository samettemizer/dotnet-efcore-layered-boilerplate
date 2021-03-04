using System;
using System.Linq;
using System.Threading.Tasks;
using TaTava.Categories.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;
using TaTava.Application.Shared.Dtos;
using TaTava.Categories;

namespace TaTava.Content.Categories
{
    public class CategoryAppService : BaseAppService, ICategoryAppService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
        private readonly CategoryPolicy _categoryPolicy;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryAppService(IRepository<Category, Guid> categoryRepository, CategoryPolicy categoryPolicy, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _categoryPolicy = categoryPolicy;
            _unitOfWork = unitOfWork;

        }

        public async Task<ServiceResult> DeleteCategory(EntityDto<Guid> input)
        {
            var isCategoryExist = await _categoryPolicy.IsCategoryExistById(input);

            if (isCategoryExist.IsFailed) return isCategoryExist;

            await _categoryRepository.Delete(category => category.Id == input.Id);

            _unitOfWork.SaveChanges();

            return new ServiceResult(Status.Success)
            {
                Message = string.Format(ServiceMessages.DeleteSuccessful, "Kategori")
            };
        }

        public async Task<ServiceResult<IQueryable<CategoryListOutputDto>>> GetAllCategory()
        {
            var allCategories = await _categoryRepository.GetQueryableAsync(category => !category.IsDeleted);

            return new ServiceResult<IQueryable<CategoryListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, allCategories.Count(), "Kategori"),
                Object = allCategories.ToCategoryListOutput()
            };
        }

        public async Task<ServiceResult> InsertCategory(InsertCategoryInputDto input)
        {
            var isCategoryTakenBySomeone = await _categoryPolicy.SameTitle(input.Title);

            if (isCategoryTakenBySomeone.IsFailed)
                return new ServiceResult<Guid>(Status.Warning) { Message = isCategoryTakenBySomeone.Message };

            try
            {
                var addedCategoryId = await _categoryRepository.InsertAndGetIdAsync(input.ToCategoryEntity());

                _unitOfWork.SaveChanges();

                return new ServiceResult<Guid>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Kategori"),
                    Object = addedCategoryId

                };
            }
            catch (Exception e)
            {

                return new ServiceResult(Status.Error) { Message = string.Format("Kategori kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message) };
            }

        }

        public async Task<ServiceResult> UpdateCategory(UpdateCategoryInputDto input)
        {
            var isCategoryExistById = await _categoryPolicy.IsCategoryExistById(new EntityDto<Guid> { Id = input.Id });

            if (isCategoryExistById.IsFailed)
                return new ServiceResult(isCategoryExistById.Status)
                {
                    Message = isCategoryExistById.Message
                };

            var categoryToUpdate = await _categoryRepository.GetAsync(category => category.Id == input.Id);

            try
            {
                await _categoryRepository.Update(categoryToUpdate.ToUpdateCategoryEntity(input));

                _unitOfWork.SaveChanges();

                return new ServiceResult(Status.Success)
                {
                    Message = $"{input.Title} adlı kategori bilgileri güncellenmiştir.",
                };
            }
            catch (Exception e)
            {
                return new ServiceResult(Status.Error)
                { Message = string.Format($"{input.Title} adlı kullanıcının bilgilerini düzenlerken bir hata oluştu. Sebebi;{0}", e.Message) };
            }
        }
    }
}
