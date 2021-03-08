using TaTava.EntityFrameworkCore.Interfaces;

namespace TaTava.Firmalar
{
    public class FirmaAppService : IFirmaAppService
    {
        private readonly IRepository<Firma, int> _firmaRepository;

        public FirmaAppService(IRepository<Firma, int> firmaRepository)
        {
            _firmaRepository = firmaRepository;
        }
    }
}