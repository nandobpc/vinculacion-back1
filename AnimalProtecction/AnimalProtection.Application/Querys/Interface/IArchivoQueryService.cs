using AnimalProtection.Domain.Dto;
using AnimalProtection.Domain.Result;

namespace AnimalProtection.Application.Querys.Interface
{
    public interface IArchivoQueryService
    {
        Task<ResultResponse<PagedResponseRecord<ArchivoRecord>>> GetAllArchivos(int pageNumber, int pageSize);
        Task<ResultResponse<ArchivoRecord>> GetArchivoById<T>(Guid id);
        Task<ResultResponse<ArchivoRecord>> CreateArchivo(ArchivoCreateRecord createRecord);
        Task<ResultResponse<ArchivoRecord>> UpdateArchivo(ArchivoUpdateRecord updateRecord);
        Task<ResultResponse<bool>> DeleteArchivo(Guid id);
    }
}
