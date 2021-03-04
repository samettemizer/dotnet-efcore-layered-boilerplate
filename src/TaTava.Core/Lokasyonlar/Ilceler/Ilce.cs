using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Lokasyonlar.Ilceler
{
    public class Ilce : Entity<short>
    {
        public Ilce(string ilceAdi)
        {
            SetIlceAdi(ilceAdi);
        }
        #region - Properties

        public string IlceAdi { get; private set; }

        #endregion

        #region - Navigation Properties
        #endregion

        #region - Domain Methods

        public void SetIlceAdi(string ilceAdi)
        {
            Policy.NullOrWhiteSpaceCheck(ilceAdi, nameof(ilceAdi));
            IlceAdi = ilceAdi;
        }

        #endregion
    }
}