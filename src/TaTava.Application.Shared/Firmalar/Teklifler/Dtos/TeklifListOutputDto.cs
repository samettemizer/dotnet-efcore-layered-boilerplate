using System;
using TaTava.Application.Shared.Dtos;

namespace TaTava.Firmalar.Teklifler.Dtos
{
    public class TeklifListOutputDto : EntityDto<int>
    {
        #region - Properties
        public string TeklifYapanFirmaYetkiliAd { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime TeklifTarihi { get; set; }
        public DateTime? TeklifinSonaErmeTarihi { get; set; }

        #endregion

        #region - Navigation Properties

        public Guid? MusteriId { get; set; }
        public int FirmaId { get; set; }

        #endregion
    }
}