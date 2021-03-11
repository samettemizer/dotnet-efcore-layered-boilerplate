using System.Linq;
using TaTava.Firmalar.Teklifler.Dtos;

namespace TaTava.Firmalar.Teklifler
{
    public static class TeklifMapper
    {
        public static IQueryable<TeklifListOutputDto> ToTeklifListOutput(this IQueryable<Teklif> teklifler)
        {
            return teklifler.Select(teklif => new TeklifListOutputDto
            {
                Id = teklif.Id,
                FirmaId = teklif.FirmaId,
                MusteriId = teklif.MusteriId,
                TeklifinSonaErmeTarihi = teklif.TeklifinSonaErmeTarihi,
                TeklifTarihi = teklif.TeklifTarihi,
                TeklifYapanFirmaYetkiliAd = teklif.TeklifYapanFirmaYetkiliAd,
                ToplamTutar = teklif.ToplamTutar
            });
        }
    }
}