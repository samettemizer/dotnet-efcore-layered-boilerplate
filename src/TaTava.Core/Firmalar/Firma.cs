using System;
using System.Collections.Generic;
using TaTava.Authorization.Users;
using TaTava.Entities;
using TaTava.Firmalar.FirmaUrunleri;
using TaTava.Firmalar.Sektorler;
using TaTava.Lokasyonlar.Ilceler;
using TaTava.Lokasyonlar.Iller;
using TaTava.Policies;

namespace TaTava.Firmalar
{
    public class Firma : FullAuditedEntity<int>
    {
        public Firma(string unvan, string yetkiliAd, string yetkiliSoyad, string adres, short ilId, short ilceId, short sektorId)
        {
            SetUnvan(unvan);
            SetYetkiliAd(yetkiliAd);
            SetYetkiliSoyad(yetkiliSoyad);
            SetAdres(adres);
            SetIlId(ilId);
            SetIlceId(ilceId);
            SetSektorId(sektorId);
        }

        #region - Properties

        public string Unvan { get; private set; }
        public string YetkiliAd { get; private set; }
        public string YetkiliSoyad { get; private set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Faks { get; set; }
        public string Adres { get; private set; }
        public string GoogleHarita { get; set; }

        #endregion

        #region - Domain Properties

        public short IlId { get; private set; }
        public Il Il { get; set; }

        public short IlceId { get; private set; }
        public Ilce Ilce { get; set; }

        public short SektorId { get; private set; }
        public Sektor Sektor { get; set; }

        public Guid? FirmaYetkiliKullaniciId { get; set; }
        public User FirmaYetkiliKullanici { get; set; }

        public ICollection<FirmaUrun> FirmaUrunleri { get; set; }

        #endregion

        #region - Domain Methods

        public void SetUnvan(string unvan)
        {
            Policy.NullOrWhiteSpaceCheck(unvan, nameof(unvan));
            Unvan = unvan;
        }

        public void SetYetkiliAd(string yetkiliAd)
        {
            Policy.NullOrWhiteSpaceCheck(yetkiliAd, nameof(yetkiliAd));
            YetkiliAd = yetkiliAd;
        }

        public void SetYetkiliSoyad(string yetkiliSoyad)
        {
            Policy.NullOrWhiteSpaceCheck(yetkiliSoyad, nameof(yetkiliSoyad));
            YetkiliSoyad = yetkiliSoyad;
        }

        public void SetAdres(string adres)
        {
            Policy.NullOrWhiteSpaceCheck(adres, nameof(adres));
            Adres = adres;
        }

        public void SetIlId(short ilId)
        {
            Policy.ZeroCheck(ilId, nameof(ilId));
            IlId = ilId;
        }

        public void SetIlceId(short ilceId)
        {
            Policy.ZeroCheck(ilceId, nameof(ilceId));
            IlceId = ilceId;
        }

        public void SetSektorId(short sektorId)
        {
            Policy.ZeroCheck(sektorId, nameof(sektorId));
            SektorId = sektorId;
        }

        #endregion
    }
}