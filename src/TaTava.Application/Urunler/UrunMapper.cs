using System.Linq;
using TaTava.Urunler;
using TaTava.Urunler.Dtos;

namespace TaTava.Application.Urunler
{
    public static class UrunMapper
    {
        public static IQueryable<UrunListOutputDto> ToUrunListOutputDto(this IQueryable<Urun> urunler)
        {
            return urunler.Select(urunOutputDto => new UrunListOutputDto
            {
                Id = urunOutputDto.Id,
                SektorId = urunOutputDto.SektorId,
                Tur = urunOutputDto.Tur,
                UrunAdi = urunOutputDto.UrunAdi,
                UrunKategoriId = urunOutputDto.UrunKategoriId
            });
        }
    }
}