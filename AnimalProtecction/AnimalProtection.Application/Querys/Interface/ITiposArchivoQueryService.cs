using AnimalProtection.Domain.Dto;
using AnimalProtection.Domain.Result;

namespace AnimalProtection.Application.Querys.Interface
{
    public interface ITiposArchivoQueryService
    {
        Task<ResultResponse<PagedResponseRecord<TiposArchivoRecord>>> GetAllTiposArchivo(int pageNumber, int pageSize);
        Task<ResultResponse<TiposArchivoRecord>> GetTiposArchivoById<T>(Guid id);
        Task<ResultResponse<TiposArchivoRecord>> CreateTiposArchivo(TiposArchivoCreateRecord createRecord);
        Task<ResultResponse<TiposArchivoRecord>> UpdateTiposArchivo(TiposArchivoUpdateRecord updateRecord);
        Task<ResultResponse<bool>> DeleteTiposArchivo(Guid id);
    }
}
