using AnimalProtection.Application.Querys.Interface;
using AnimalProtection.Domain.Dto;
using AnimalProtection.Domain.Entities;
using AnimalProtection.Domain.Result;
using AnimalProtection.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace AnimalProtection.Application.Querys.Service
{
    public class TiposArchivoQueryService : ITiposArchivoQueryService
    {
        private readonly ITiposArchivoRepository _repository;

        public TiposArchivoQueryService(ITiposArchivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultResponse<TiposArchivoRecord>> CreateTiposArchivo(TiposArchivoCreateRecord createRecord)
        {
            var tiposArchivo = Tiposarchivo.CreateFromRecord(createRecord);
            await _repository.AddAsync(tiposArchivo);
            await _repository.SaveAsync();
            return ResultResponse<TiposArchivoRecord>.Success(new TiposArchivoRecord(tiposArchivo), 201);
        }

        public async Task<ResultResponse<bool>> DeleteTiposArchivo(Guid id)
        {
            var tiposArchivo = await _repository.GetByIdAsync(id);
            if (tiposArchivo == null)
            {
                return ResultResponse<bool>.Failure($"No se encontró el tipo de archivo con id: {id}", 404);
            }
            tiposArchivo.Delete();
            await _repository.UpdateAsync(tiposArchivo);
            await _repository.SaveAsync();
            return ResultResponse<bool>.Success(true, 200);
        }

        public async Task<ResultResponse<PagedResponseRecord<TiposArchivoRecord>>> GetAllTiposArchivo(int pageNumber, int pageSize)
        {
            var query = _repository.GetPageableAsync().Where(t => t.Estaactivo == true);
            int totalRecords = await query.CountAsync();
            var pagedResult = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            var records = pagedResult.Select(t => new TiposArchivoRecord(t)).ToList();
            var response = new PagedResponseRecord<TiposArchivoRecord>(
                records, pageNumber, pageSize, totalRecords, (int)Math.Ceiling((double)totalRecords / pageSize)
            );
            return ResultResponse<PagedResponseRecord<TiposArchivoRecord>>.Success(response);
        }

        public async Task<ResultResponse<TiposArchivoRecord>> GetTiposArchivoById<T>(Guid id)
        {
            var tiposArchivo = await _repository.GetByIdAsync(id);
            if (tiposArchivo == null)
            {
                return ResultResponse<TiposArchivoRecord>.Failure($"No se encontró el tipo de archivo con id: {id}", 404);
            }
            return ResultResponse<TiposArchivoRecord>.Success(new TiposArchivoRecord(tiposArchivo));
        }

        public async Task<ResultResponse<TiposArchivoRecord>> UpdateTiposArchivo(TiposArchivoUpdateRecord updateRecord)
        {
            var tiposArchivo = await _repository.GetByIdAsync(updateRecord.Id);
            if (tiposArchivo == null)
            {
                return ResultResponse<TiposArchivoRecord>.Failure($"No se encontró el tipo de archivo con id: {updateRecord.Id}", 404);
            }
            tiposArchivo.UpdateFromRecord(updateRecord);
            await _repository.UpdateAsync(tiposArchivo);
            await _repository.SaveAsync();
            return ResultResponse<TiposArchivoRecord>.Success(new TiposArchivoRecord(tiposArchivo));
        }
    }
}
