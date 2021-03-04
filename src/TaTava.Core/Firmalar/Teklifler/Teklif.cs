using System;
using TaTava.Authorization.Users;
using TaTava.Entities;
using TaTava.Policies;

namespace TaTava.Firmalar.Teklifler
{
    public class Teklif : FullAuditedEntity<int>
    {
        public Teklif(string teklifYapanFirmaYetkiliAd, DateTime teklifTarihi, int firmaId)
        {
            SetTeklifYapanFirmaYetkiliAd(teklifYapanFirmaYetkiliAd);
            SetTeklifTarihi(teklifTarihi);
            SetFirmaId(firmaId);
        }

        #region - Properties

        public string TeklifYapanFirmaYetkiliAd { get; private set; }
        public decimal ToplamTutar { get; set; }
        public DateTime TeklifTarihi { get; private set; }
        public DateTime? TeklifinSonaErmeTarihi { get; set; }

        #endregion

        #region - Navigation Properties

        public Guid? MusteriId { get; set; }
        public User Musteri { get; set; }

        public int FirmaId { get; private set; }
        public Firma Firma { get; set; }

        #endregion

        #region - Domain Methods

        public void SetTeklifYapanFirmaYetkiliAd(string teklifYapanFirmaYetkiliAd)
        {
            Policy.NullOrWhiteSpaceCheck(teklifYapanFirmaYetkiliAd, nameof(teklifYapanFirmaYetkiliAd));
            TeklifYapanFirmaYetkiliAd = teklifYapanFirmaYetkiliAd;
        }

        public void SetTeklifTarihi(DateTime teklifTarihi)
        {
            TeklifTarihi = teklifTarihi;
        }

        public void SetFirmaId(int firmaId)
        {
            Policy.ZeroCheck(firmaId, nameof(firmaId));
            FirmaId = firmaId;
        }

        #endregion

    }
}