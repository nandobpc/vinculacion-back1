namespace AnimalProtection.Domain.Entities;

public partial class Tiposarchivo
{
    public Guid Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string? Descripcion { get; set; }
    public bool? Estaactivo { get; set; }
    public virtual ICollection<Archivo> Archivos { get; set; } = new List<Archivo>();

  
    public static Tiposarchivo CreateFromRecord(Domain.Dto.TiposArchivoCreateRecord createRecord)
    {
        return new Tiposarchivo
        {
            Id = Guid.NewGuid(),
            Nombre = createRecord.Nombre,
            Descripcion = createRecord.Descripcion,
            Estaactivo = true
        };
    }

  
    public void UpdateFromRecord(Domain.Dto.TiposArchivoUpdateRecord updateRecord)
    {
        if (!string.IsNullOrWhiteSpace(updateRecord.Nombre))
            Nombre = updateRecord.Nombre;
        if (!string.IsNullOrWhiteSpace(updateRecord.Descripcion))
            Descripcion = updateRecord.Descripcion;
    }


    public void Delete()
    {
        Estaactivo = false;
    }
}
