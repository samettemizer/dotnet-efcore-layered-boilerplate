using FluentValidation;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Web.Host.Validators
{
    public class BaseDtoValidator<TDto> : AbstractValidator<TDto> where TDto : EntityDto
    {
    }

    public class BaseDtoValidator<TDto, TPrimaryKey> : AbstractValidator<TDto> where TDto : EntityDto<TPrimaryKey>
    {
    }

}   