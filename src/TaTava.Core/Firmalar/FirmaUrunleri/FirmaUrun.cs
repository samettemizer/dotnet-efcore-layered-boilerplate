using TaTava.Entities;
using TaTava.Urunler;

namespace TaTava.Firmalar.FirmaUrunleri
{
    public class FirmaUrun : FullAuditedEntity<int>
    {
        #region - Properties

        public decimal Fiyat { get; set; }

        public decimal Kdv { get; set; }

        #endregion

        #region - Navigation Properties

        public int FirmaId { get; set; }
        public Firma Firma { get; set; }

        public short UrunId { get; set; }
        public Urun Urun { get; set; }

        #endregion
    }
}