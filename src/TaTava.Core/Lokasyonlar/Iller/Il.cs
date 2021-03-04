using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Lokasyonlar.Iller
{
    public class Il : Entity<short>
    {
        public Il(string ilAdi)
        {
            SetIlAdi(ilAdi);
        }
        #region - Properties

        public string IlAdi { get; private set; }

        #endregion

        #region - Navigation Properties
        #endregion

        #region - Domain Methods

        public void SetIlAdi(string ilAdi)
        {
            Policy.NullOrWhiteSpaceCheck(ilAdi, nameof(ilAdi));
            IlAdi = ilAdi;
        }

        #endregion
    }
}