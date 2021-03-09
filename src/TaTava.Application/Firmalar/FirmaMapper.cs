using System.Linq;
using TaTava.Firmalar;
using TaTava.Firmalar.Dtos;

namespace TaTava.Firmalar
{
    public static class FirmaMapper
    {
        public static FirmaOutputDto ToFirmaOutputDto(this Firma firma)
        {
            return new FirmaOutputDto
            {
                Id = firma.Id,
                Unvan = firma.Unvan,
                YetkiliAd = firma.YetkiliAd,
                YetkiliSoyad = firma.YetkiliSoyad,
                Telefon = firma.Telefon,
                MobilTelefon = firma.MobilTelefon,
                Faks = firma.Faks,
                Adres = firma.Adres,
                GoogleHarita = firma.GoogleHarita,

                IlId = firma.IlId,
                IlceId = firma.IlceId,
                SektorId = firma.SektorId
            };
        }

        public static IQueryable<FirmaOutputDto> ToFirmaOutputDto(this IQueryable<Firma> firmalar)
        {
            return firmalar.Select(firmaOutputDto => new FirmaOutputDto
            {
                Id = firmaOutputDto.Id,
                Unvan = firmaOutputDto.Unvan,
                YetkiliAd = firmaOutputDto.YetkiliAd,
                YetkiliSoyad = firmaOutputDto.YetkiliSoyad,
                Telefon = firmaOutputDto.Telefon,
                MobilTelefon = firmaOutputDto.MobilTelefon,
                Faks = firmaOutputDto.Faks,
                Adres = firmaOutputDto.Adres,
                GoogleHarita = firmaOutputDto.GoogleHarita,

                IlId = firmaOutputDto.IlId,
                IlceId = firmaOutputDto.IlceId,
                SektorId = firmaOutputDto.SektorId
            });
        }

        public static Firma ToFirmaEntity(this FirmaInputDto input)
        {
            return new Firma(input.Unvan, input.YetkiliAd, input.YetkiliSoyad, input.Adres, input.IlId, input.IlceId, input.SektorId)
            {
                MobilTelefon = input.MobilTelefon,
                Telefon = input.Telefon,
                Faks = input.Faks,
                GoogleHarita = input.GoogleHarita,

                FirmaYetkiliKullaniciId = input.FirmaYetkiliKullaniciId,
                
            };
        }
    }
}