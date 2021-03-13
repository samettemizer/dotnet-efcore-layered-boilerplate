using TaTava.Application.Shared.Dtos;
using TaTava.Firmalar.FirmaUrunOzellik;
using TaTava.Urunler.UrunOzellikleri;

namespace TaTava.Firmalar.FirmaUrunOzellikleri.Dtos
{
    public class FirmaUrunOzellikOutputDto : EntityDto<long>
    {
        #region - Properties

        public FirmaUrunOzellikTypes OzellikTuru { get; set; }
        public DetayTypes DetayTipi { get; set; }
        public string Detay { get; set; }

        #endregion

        #region - Navigation Properties

        public int UrunId { get; set; }

        public int UrunOzellikId { get; set; }
        public UrunOzellikOutputDto UrunOzellik { get; set; }

        public int FirmaId { get; set; }

        #endregion
    }
}