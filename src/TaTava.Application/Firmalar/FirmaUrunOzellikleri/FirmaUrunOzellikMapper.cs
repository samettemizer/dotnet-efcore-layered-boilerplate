using System.Linq;
using TaTava.Firmalar.FirmaUrunOzellikleri.Dtos;
using TaTava.Urunler.UrunOzellikleri;

namespace TaTava.Firmalar.FirmaUrunOzellikleri
{
    public static class FirmaUrunOzellikMapper
    {
        public static IQueryable<FirmaUrunOzellikListOutputDto> ToFirmaUrunOzellikListOutputDto(this IQueryable<FirmaUrunOzellik> firmaUrunOzellikleri)
        {
            return firmaUrunOzellikleri.Select(firmaUrunOzellik => new FirmaUrunOzellikListOutputDto
            {
                Detay = firmaUrunOzellik.Detay,
                DetayTipi = firmaUrunOzellik.DetayTipi,
                OzellikTuru = firmaUrunOzellik.OzellikTuru,
                FirmaId = firmaUrunOzellik.FirmaId,
                UrunId = firmaUrunOzellik.UrunId,
                UrunOzellikId = firmaUrunOzellik.UrunOzellikId,
                UrunOzellik = new UrunOzellikOutputDto
                {
                    OzellikAdi = firmaUrunOzellik.UrunOzellik.OzellikAdi
                }
            });
        }
    }
}