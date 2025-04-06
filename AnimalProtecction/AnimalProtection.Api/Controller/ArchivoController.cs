using AnimalProtection.Application.Querys.Interface;
using AnimalProtection.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AnimalProtection.Api.Controller
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ArchivoController : ControllerBase
    {
        private readonly IArchivoQueryService _archivoService;
        private readonly ILogger<ArchivoController> _logger;

        public ArchivoController(IArchivoQueryService archivoService, ILogger<ArchivoController> logger)
        {
            _archivoService = archivoService;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene una lista paginada de archivos activos.
        /// </summary>
        [HttpGet("GetAllArchivos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllArchivos([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            _logger.LogInformation("Obteniendo lista de archivos activos");
            var result = await _archivoService.GetAllArchivos(pageNumber, pageSize);
            if (!result.IsSuccess)
            {
                _logger.LogWarning("Error obteniendo archivos: {Error}", result.Error);
                return result.Code switch
                {
                    (int)HttpStatusCode.NotFound => NotFound(result.Error),
                    _ => BadRequest(result.Error)
                };
            }
            return Ok(result.Value);
        }

        /// <summary>
        /// Obtiene un archivo por su ID.
        /// </summary>
        [HttpGet("GetArchivoById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetArchivoById(Guid id)
        {
            var result = await _archivoService.GetArchivoById<ArchivoRecord>(id);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        /// <summary>
        /// Crea un nuevo archivo.
        /// </summary>
        [HttpPost("CreateArchivo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateArchivo([FromBody] ArchivoCreateRecord createRecord)
        {
            var result = await _archivoService.CreateArchivo(createRecord);
            return result.IsSuccess 
                ? CreatedAtAction(nameof(GetArchivoById), new { id = result.Value.Id }, result.Value)
                : BadRequest(result.Error);
        }

        /// <summary>
        /// Actualiza un archivo existente.
        /// </summary>
        [HttpPut("UpdateArchivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateArchivo([FromBody] ArchivoUpdateRecord updateRecord)
        {
            var result = await _archivoService.UpdateArchivo(updateRecord);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);
        }

        /// <summary>
        /// Elimina lógicamente un archivo (marca Estaactivo = false).
        /// </summary>
        [HttpDelete("DeleteArchivo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteArchivo(Guid id)
        {
            var result = await _archivoService.DeleteArchivo(id);
            return result.IsSuccess ? Ok() : NotFound(result.Error);
        }
    }
}
