using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Urunler.UrunOzellikleri
{
    public class UrunOzellik : Entity<int>
    {
        public UrunOzellik(string ozellikAdi)
        {
            SetOzellikAdi(ozellikAdi);
        }

        #region - Properties

        public string OzellikAdi { get; private set; }

        public byte OzellikTuru { get; set; }

        #endregion

        #region - Navigation Properties



        #endregion

        #region - Domain Methods

        public void SetOzellikAdi(string ozellikAdi)
        {
            Policy.NullOrWhiteSpaceCheck(ozellikAdi, nameof(ozellikAdi));
            OzellikAdi = ozellikAdi;
        }

        #endregion
    }
}