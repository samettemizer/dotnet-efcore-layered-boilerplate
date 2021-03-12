using System;

namespace TaTava.Firmalar.TeklifDetaylari.Dtos
{
    public class TeklifDetayOutputDto
    {
        #region - Properties

        public decimal Fiyat { get; set; }
        public short Adet { get; set; }
        public Birim Birim { get; set; }
        public decimal Tutar { get; set; }

        #endregion

        #region - Navigation Properties

        public Guid? MusteriId { get; set; }

        public int TeklifId { get; set; }

        public int? FirmaUrunId { get; set; }

        #endregion

    }
}