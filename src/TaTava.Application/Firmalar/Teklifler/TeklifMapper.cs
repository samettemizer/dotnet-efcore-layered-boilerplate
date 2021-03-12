using System;
using System.Linq;
using TaTava.Application.Shared.Firmalar.Teklifler.Dtos;
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

        public static Teklif ToTeklifEntity(this TeklifInputDto input)
        {
            return new Teklif(input.TeklifYapanFirmaYetkiliAd, input.TeklifTarihi ?? DateTime.Now, input.FirmaId)
            {
                Id = input.Id,
                MusteriId = input.MusteriId,
                TeklifinSonaErmeTarihi = input.TeklifinSonaErmeTarihi,
                ToplamTutar = input.ToplamTutar
            };
        }

        public static TeklifListOutputDto ToTeklifOutputDto(this Teklif teklif)
        {
            return new TeklifListOutputDto
            {
                Id = teklif.Id,
                FirmaId = teklif.FirmaId,
                MusteriId = teklif.MusteriId,
                TeklifinSonaErmeTarihi = teklif.TeklifinSonaErmeTarihi,
                TeklifTarihi = teklif.TeklifTarihi,
                TeklifYapanFirmaYetkiliAd = teklif.TeklifYapanFirmaYetkiliAd,
                ToplamTutar = teklif.ToplamTutar,
            };
        }
    }
}