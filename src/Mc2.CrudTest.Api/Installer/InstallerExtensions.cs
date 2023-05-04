namespace Mc2.CrudTest.Api.Installer;

public static class InstallerExtensions
{
    public static void InstallServicesAssembly(this IServiceCollection services)
    {
        var installer = typeof(Program).Assembly.ExportedTypes.Where(x =>
                typeof(IInstaller).IsAssignableFrom(x) && x is {IsInterface: false, IsAbstract: false})
            .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();


        installer.ForEach(install => install.InstallServices(services));


    }
}