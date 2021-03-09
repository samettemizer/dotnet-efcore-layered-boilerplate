using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Firmalar.Dtos
{
    public class FirmaInputDto : EntityDto<int>
    {
        public string Unvan { get; set; }
        public string YetkiliAd { get; set; }
        public string YetkiliSoyad { get; set; }
        public string Telefon { get; set; }
        public string MobilTelefon { get; set; }
        public string Faks { get; set; }
        public string Adres { get; set; }
        public string GoogleHarita { get; set; }

        public short IlId { get; set; }
        public short IlceId { get; set; }
        public short SektorId { get; set; }

        public string SirketEposta { get; set; }
        public string SirketParola { get; set; }
        public Guid FirmaYetkiliKullaniciId { get; set; }
    }
}