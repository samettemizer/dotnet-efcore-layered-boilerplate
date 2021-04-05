using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaTava.Application.Shared.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Extensions;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Infrastructure;

namespace TaTava.Firmalar
{
    /**
     * todo: eksik replace'ler yapılacak. menüden copy paste yapıldı
     * todo: henüz kullanım denenmedi. 
     * todo: [post] aynı unvanda bir firma kaydı yapılması durumunda hoop demece hedefleniyor
     * todo: [put] aynı unvanda kayıtlı bir firma kaydı yapılması durumunda hoop demece
     */
    public class FirmaPolicy : BasePolicy
    {
        private readonly IRepository<Firma, int> _firmaRepository;
        public FirmaPolicy(IRepository<Firma, int> firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }

        public async Task<ServiceResult> SameTitle(string title)
        {
            var isThisTitleUsedAnySomeone = await _firmaRepository.Any(firma => firma.Unvan == title && !firma.IsDeleted);
            if (isThisTitleUsedAnySomeone)
            {
                var errorMessage = $"Sistemde bu Firma adında firma bulunmaktadır. Firma adı: {title}";
                return new ServiceResult(Status.Warning) { Message = errorMessage };
            }
            return new ServiceResult(Status.Success);
        }
        public async Task<ServiceResult> IsFirmaExistById(EntityDto<Guid> input) 
        {
            var zeroCheck = input.Id == new Guid() ? false : true;
            if (!zeroCheck) return new ServiceResult(Status.Warning) { Message = ServiceMessages.RecordFound };

            /*var isFirmaExistById = await _firmaRepository.Any(firma => firma.Id == input.Id);

            if (!isFirmaExistById)
            {
                var errorMessage = $"Sistem vermiş olduğunuz id ile kayıt menü bulunamadı, lütfen kontrol ediniz. Menü Id: {input.Id}";
                return new ServiceResult(Status.Error) { Message = errorMessage };
            }*/
            return new ServiceResult(Status.Success);
        }
    }
}