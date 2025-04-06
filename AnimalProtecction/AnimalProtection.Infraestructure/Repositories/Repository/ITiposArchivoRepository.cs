using AnimalProtecction.GenericRepository;
using AnimalProtection.Domain.Entities;
using AnimalProtection.Repositories.Interface;

namespace AnimalProtection.Generated.Repositories.Repository
{
    public class TiposArchivoRepository : GenericRepository<Tiposarchivo>, ITiposArchivoRepository
    {
        public TiposArchivoRepository(AnimalprotectionContext context) : base(context)
        {
        }
    }
}
