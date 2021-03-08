using System.Linq;
using TaTava.Firmalar.Sektorler;
using TaTava.Firmalar.Sektorler.Dtos;

namespace TaTava.Application.Firmalar.Sektorler
{
    public static class SektorMapper
    {
        public static IQueryable<SektorListOutputDto> ToSektorListOutput(this IQueryable<Sektor> sektorlerEntities)
        {
            return sektorlerEntities.Select(sektorListOutput => new SektorListOutputDto
            {
                Id = sektorListOutput.Id,
                SektorAdi = sektorListOutput.SektorAdi
            });
        }
    }
}