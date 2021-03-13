using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TaTava.Firmalar.Teklifler.Dtos;
using TaTava.Authorization.Users;
using TaTava.CommonTypes;
using TaTava.Core.Shared.Consts;
using TaTava.EntityFrameworkCore.Interfaces;
using TaTava.Firmalar.TeklifDetaylari;
using TaTava.Firmalar.TeklifDetaylari.Dtos;
using TaTava.Infrastructure;

namespace TaTava.Firmalar.Teklifler
{
    public class TeklifAppService : BaseAppService, ITeklifAppService
    {
        private readonly IRepository<Teklif, int> _teklifRepository;
        private readonly IRepository<User, Guid> _userRepository;
        private readonly IRepository<Firma, int> _firmaRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;

        public TeklifAppService(IRepository<Teklif, int> teklifRepository, IRepository<User, Guid> userRepository, IRepository<Firma, int> firmaRepository, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork) : base(httpContextAccessor)
        {
            _teklifRepository = teklifRepository;
            _userRepository = userRepository;
            _firmaRepository = firmaRepository;
            _httpContextAccessor = httpContextAccessor;
            _unitOfWork = unitOfWork;
        }


        public async Task<ServiceResult<TeklifListOutputDto>> TeklifEkle(TeklifInputDto input)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var random = new Random();
                    var totalDetay = (decimal)random.Next(1, 5);
                    Console.WriteLine(totalDetay);
                    var totalFiyat = (decimal)random.Next(100, 999);
                    Console.WriteLine(totalFiyat);
                    var detayFiyati = totalFiyat / totalDetay;

                    var userIdClaim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(claim => claim.Type == "Id");
                    var userId = new Guid(userIdClaim.Value);
                    var user = await _userRepository.GetAsync(user => user.Id == userId);
                    var firma = await _firmaRepository.GetAsync(firma => firma.FirmaYetkiliKullaniciId == userId);

                    input.TeklifYapanFirmaYetkiliAd = $"{user.FirstName} {user.LastName}";
                    input.FirmaId = firma.Id;
                    input.TeklifTarihi = DateTime.Now;
                    input.ToplamTutar = totalFiyat;
                    input.MusteriId = userId;


                    var teklifEntity = input.ToTeklifEntity();
                    await _teklifRepository.InsertAsync(teklifEntity);

                    _unitOfWork.SaveChanges();

                    var teklifDetayAppService = GetService<ITeklifDetayAppService>();
                    for (int i = 0; i < totalDetay; i++)
                    {
                        var teklifDetay = await teklifDetayAppService.TeklifDetayEkle(new TeklifDetayInputDto { FirmaUrunId = 1, TeklifId = teklifEntity.Id, Adet = 1, Birim = Birim.M2, Fiyat = detayFiyati, Tutar = detayFiyati });
                    }


                    transaction.Commit();

                    return new ServiceResult<TeklifListOutputDto>(Status.Success)
                    {
                        Message = string.Format(ServiceMessages.InsertSuccessful, "Teklif"),
                        Object = teklifEntity.ToTeklifOutputDto()
                    };
                }
                catch (Exception e)
                {
                    return new ServiceResult<TeklifListOutputDto>(Status.Error)
                    {
                        Message = string.Format("Tekl'f kaydı sırasında bir hata oluştu. Sebebi; {0}", e.Message)
                    };
                }
            }
        }

        public async Task<ServiceResult<IQueryable<TeklifListOutputDto>>> Teklifler()
        {
            var teklifler = await _teklifRepository.GetQueryableAsync();

            return new ServiceResult<IQueryable<TeklifListOutputDto>>(Status.Success)
            {
                Message = string.Format(ServiceMessages.ListResultSuccessfulWithItemCount, teklifler.Count(), "Teklif"),
                Object = teklifler.ToTeklifListOutput()
            };
        }
    }
}