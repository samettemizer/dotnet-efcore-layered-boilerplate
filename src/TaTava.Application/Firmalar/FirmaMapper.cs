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
    }
}