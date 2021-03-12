using System;
using System.Threading.Tasks;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.TeklifDetaylari.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.TeklifDetaylari
{
    public class TeklifDetayAppService : BaseAppService, ITeklifDetayAppService
    {
        private readonly IRepository<TeklifDetay, long> _teklifDetaylariRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeklifDetayAppService(IRepository<TeklifDetay, long> teklifDetaylariRepository, IUnitOfWork unitOfWork)
        {
            _teklifDetaylariRepository = teklifDetaylariRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResult<TeklifDetayOutputDto>> TeklifDetayEkle(TeklifDetayInputDto input)
        {
            try
            {
                var teklifEntity = input.ToTeklifDetayEntity();
                await _teklifDetaylariRepository.InsertAsync(teklifEntity);

                _unitOfWork.SaveChanges();

                return new ServiceResult<TeklifDetayOutputDto>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.InsertSuccessful, "Teklif Detay"),
                    Object = teklifEntity.ToTeklifDetayOutputDto()
                };

            }
            catch (Exception e)
            {
                return new ServiceResult<TeklifDetayOutputDto>(Status.Error)
                {
                    Message = string.Format("Menu kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message)
                };
            }
        }
    }
}