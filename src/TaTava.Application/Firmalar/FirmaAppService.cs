using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaTava.Authorization.UserAccounts.Dtos;
using TaTava.Authorization.Users;
using TaTava.Authorization.Users.Dtos;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar
{
    public class FirmaAppService : BaseAppService, IFirmaAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Firma, int> _firmaRepository;

        public FirmaAppService(IRepository<Firma, int> firmaRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _firmaRepository = firmaRepository;
        }

        public async Task<ServiceResult<IQueryable<FirmaOutputDto>>> FirmaListesi(query query = null)
        {
            var firmalar = await _firmaRepository.GetQueryableAsync(x => 
                x.Unvan.Contains(query.unvan) && 
                x.YetkiliSoyad.Contains(query.yetkiliSoyad)
                // x.Foo.Contains(query.Foo) &&
            );

            return new ServiceResult<IQueryable<FirmaOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, firmalar.Count(), "Firma"),
                Object = firmalar.ToFirmaOutputDto()
            };
        }

        public async Task<ServiceResult<FirmaOutputDto>> FirmeEkle(FirmaInputDto input)
        {
            try
            {
                using (var transaction = _unitOfWork.BeginTransaction())
                {
                    var userService = GetService<IUserAppService>();

                    var sirketYetkilisiInsertInput = new InsertUserInput()
                    {
                        FirstName = input.YetkiliAd,
                        LastName = input.YetkiliSoyad,
                        UserAccount = new InserUserAccountInput() { Email = input.SirketEposta, Password = input.SirketParola },
                        PhoneNumber = input.MobilTelefon,
                        Address = input.Adres
                    };
                    var sirketYetkilisi = await userService.InsertUser(sirketYetkilisiInsertInput);

                    if (sirketYetkilisi.IsFailed)
                        return new ServiceResult<FirmaOutputDto>(sirketYetkilisi.Status)
                        {
                            Message = sirketYetkilisi.Message
                        };

                    var firmaEntity = input.ToFirmaEntity();
                    firmaEntity.FirmaYetkiliKullaniciId = sirketYetkilisi.Object.Id;

                    await _firmaRepository.InsertAsync(firmaEntity);

                    _unitOfWork.SaveChanges();

                    transaction.Commit();

                    return new ServiceResult<FirmaOutputDto>(Status.Success)
                    {
                        Message = string.Format(ServiceMessages.InsertSuccessful, "Firma"),
                        Object = firmaEntity.ToFirmaOutputDto()
                    };

                }
            }
            catch (Exception e)
            {
                return new ServiceResult<FirmaOutputDto>(Status.Error) { Message = string.Format("Kullanıcı kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message) };
            }
        }

        [HttpGet("{id}")]
        public async Task<ServiceResult<FirmaOutputDto>> FirmaOge(int id)
        {
            try
            {
                var oge = await _firmaRepository.GetAsync(firma => firma.Id == id);
                if (oge == null)
                {
                    throw new Exception("Yokh ki");
                }
                return new ServiceResult<FirmaOutputDto>(Status.Success)
                {
                    Message = string.Format(ServiceMessages.RecordFound, "Firma"),
                    Object = oge.ToFirmaOutputDto()
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<FirmaOutputDto>(Status.Error) { Message = string.Format("Hede hude. {0}", e.Message) };
            }
        }
    }
}