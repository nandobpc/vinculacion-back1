namespace AnimalProtection.Domain.Dto
{
    public record ArchivoRecord(
        Guid Id,
        string Url,
        string Formato,
        Guid Idtipoarchivo,
        bool Estaactivo
    )
    {
        public ArchivoRecord(Entities.Archivo archivo)
            : this(
                archivo.Id,
                archivo.Url,
                archivo.Formato,
                archivo.Idtipoarchivo,
                archivo.Estaactivo ?? false
            )
        { }
    }
}
