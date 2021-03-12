using TaTava.Firmalar.TeklifDetaylari.Dtos;

namespace TaTava.Firmalar.TeklifDetaylari
{
    public static class TeklifDetayMapper
    {
        public static TeklifDetay ToTeklifDetayEntity(this TeklifDetayInputDto input)
        {
            return new TeklifDetay(input.TeklifId)
            {
                Fiyat = input.Fiyat,
                Adet = input.Adet,
                Birim = input.Birim,
                Tutar = input.Tutar,

                MusteriId = input.MusteriId,
            };
        }

        public static TeklifDetayOutputDto ToTeklifDetayOutputDto(this TeklifDetay entity)
        {
            return new TeklifDetayOutputDto
            {
                Fiyat = entity.Fiyat,
                Adet = entity.Adet,
                Birim = entity.Birim,
                Tutar = entity.Tutar,

                TeklifId = entity.TeklifId,
                FirmaUrunId = entity.TeklifId,
                MusteriId = entity.MusteriId,
            };
        }
    }
}