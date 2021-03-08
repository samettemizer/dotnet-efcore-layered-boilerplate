using TaTava.Application.Shared.Dtos;

namespace TaTava.Urunler.Dtos
{
    public class UrunListOutputDto : EntityDto<short>
    {
        public string UrunAdi { get; set; }
        public string Tur { get; set; }

        public short UrunKategoriId { get; set; }
        public short SektorId { get; set; }

    }
}