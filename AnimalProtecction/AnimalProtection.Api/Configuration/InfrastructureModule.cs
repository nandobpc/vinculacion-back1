using AnimalProtecction.Generated.Repositories.Interface;
using AnimalProtecction.Generated.Repositories.Repository;
using AnimalProtecction.GenericRepository;
using AnimalProtection.Repositories.Interface;
using AnimalProtection.Repositories.Repository;
using Autofac;

namespace AnimalProtection.Api.Configuration;

public class InfrastructureModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(GenericRepository<>))
            .As(typeof(IGenericRepository<>))
            .InstancePerLifetimeScope();

        builder.RegisterType<UsuarioRepository>()
            .As<IUsuarioRepository>();
            
        builder.RegisterType<TramiteRepository>()
            .As<ITramiteRepository>();

        builder.RegisterType<TipostramiteRepository>()
            .As<ITipostramiteRepository>();

        builder.RegisterType<EstadostramiteRepository>()
            .As<IEstadostramiteRepository>();

        builder.RegisterType<PreguntasFrecuenteRepository>()
            .As<IPreguntasFrecuenteRepository>();
            
        builder.RegisterType<DatosInstitucionRepository>()
            .As<IDatosInstitucionRepository>();
            
        builder.RegisterType<CooperantesRepository>()
            .As<ICooperantesRepository>();

        builder.RegisterType<GeneroRepository>()
            .As<IGeneroRepository>();
            
        builder.RegisterType<EspecyRepository>()
            .As<IEspecyRepository>();
            
        builder.RegisterType<RazaRepository>()
            .As<IRazaRepository>();
            
        builder.RegisterType<MascotaRepository>()
            .As<IMascotaRepository>();

        builder.RegisterType<ArchivoRepository>()
            .As<IArchivoRepository>();
            
        builder.RegisterType<TiposArchivoRepository>()
            .As<ITiposArchivoRepository>();


    }
}