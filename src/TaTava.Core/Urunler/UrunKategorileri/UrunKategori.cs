using System.Collections;
using System.Collections.Generic;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Urunler.UrunKategorileri
{
    public class UrunKategori : FullAuditedEntity<short>
    {
        public UrunKategori(string kategoriAdi)
        {
            SetKategoriAdi(kategoriAdi);
        }

        #region - Properties

        public string KategoriAdi { get; private set; }

        #endregion

        #region - Navigation Properties

        public short UstKategoryId { get; set; }


        public ICollection<Urun> Urunler { get; set; }

        #endregion

        #region - Domain Method

        public void SetKategoriAdi(string kategoriAdi)
        {
            Policy.NullOrWhiteSpaceCheck(kategoriAdi, nameof(kategoriAdi));
            KategoriAdi = kategoriAdi;
        }

        #endregion 
    }
}