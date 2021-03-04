using TaTava.Categories.Dtos;
using TaTava.Extensions;

namespace TaTava.Web.Host.Validators.Category
{
    public class InsertCategoryInputValidator : BaseDtoValidator<InsertCategoryInputDto>
    {
        public InsertCategoryInputValidator()
        {
            RuleFor(category => category.Title)
                .HasMaximumLength(100, "Kategori")
                .NullOrEmpty("Kategori Baslik");
        }
    }
}