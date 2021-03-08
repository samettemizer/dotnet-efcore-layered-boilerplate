using TaTava.Urunler.UrunKategorileri;
using TaTava.Entities;
using TaTava.Policies;
using System.Collections.Generic;
using TaTava.Firmalar.FirmaUrunleri;
using TaTava.Firmalar.Sektorler;

namespace TaTava.Urunler
{
    public class Urun : FullAuditedEntity<short>
    {
        public Urun(string urunAdi)
        {
            SetUrunAdi(urunAdi);
        }

        #region - Properties

        public string UrunAdi { get; private set; }

        public string Tur { get; set; }

        #endregion

        #region - Navigation Properties

        public short UrunKategoriId { get; set; }
        public UrunKategori UrunKategori { get; set; }

        public short SektorId { get; set; }

        #endregion

        #region - Navigation Properties

        public ICollection<FirmaUrun> FirmaUrunleri { get; set; }

        #endregion

        #region - Domain Methods

        public void SetUrunAdi(string urunAdi)
        {
            Policy.NullOrWhiteSpaceCheck(urunAdi, nameof(urunAdi));
            UrunAdi = urunAdi;
        }

        #endregion
    }
}