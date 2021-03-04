using System;
using TaTava.Authorization.Users;
using TaTava.Entities;
using TaTava.Firmalar.FirmaUrunleri;
using TaTava.Firmalar.Teklifler;
using TaTava.Policies;

namespace TaTava.Firmalar.TeklifDetaylari
{
    public class TeklifDetay : FullAuditedEntity<long>
    {
        public TeklifDetay(int teklifId)
        {
            SetTeklifId(teklifId);
        }

        #region - Properties

        public decimal Fiyat { get; set; }
        public short Adet { get; set; }
        public Birim Birim { get; set; }
        public decimal Tutar { get; set; }

        #endregion

        #region - Navigation Properties

        public Guid? MusteriId { get; set; }

        public int TeklifId { get; private set; }
        public Teklif Teklif { get; set; }

        public int? FirmaUrunId { get; private set; }

        #endregion

        #region - Domain Methods

        public void SetTeklifId(int teklifId)
        {
            Policy.ZeroCheck(teklifId, nameof(teklifId));
            TeklifId = teklifId;
        }

        #endregion
    }
}