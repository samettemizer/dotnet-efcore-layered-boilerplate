using System.Collections.Generic;
using TaTava.Entities.Audited;
using TaTava.Policies;
using TaTava.Urunler;

namespace TaTava.Firmalar.Sektorler
{
    public class Sektor : AuditedEntity<short>
    {
        public Sektor(string sektorAdi)
        {
            SetSektorAdi(sektorAdi);
        }

        #region - Properties

        public string SektorAdi { get; private set; }

        #endregion

        #region - Navigation Properties

        public ICollection<Firma> Firmalar { get; set; }

        #endregion

        #region - Domain Methods

        public void SetSektorAdi(string sektorAdi)
        {
            Policy.NullOrWhiteSpaceCheck(sektorAdi, nameof(sektorAdi));
            SektorAdi = sektorAdi;
        }

        #endregion
    }
}