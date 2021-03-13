using TaTava.Application.Shared.Dtos;

namespace TaTava.Urunler.UrunOzellikleri
{
    public class UrunOzellikOutputDto : EntityDto<int>
    {
        public string OzellikAdi { get; set; }

    }
}