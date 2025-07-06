using FluentValidation;
using Tourism.Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Tourism.Domain.Helpers;

public static class DependencyHelper
{
    public static void AddDas(this IServiceCollection services, Assembly assembly)
    {

        var classAssembly = assembly.GetTypes().Where(x => x.IsClass && x.GetInterface(nameof(IBaseDas)) != null);
        foreach (var type in classAssembly)
        {
            var interfaceWorkflow = type.GetInterfaces().FirstOrDefault(x => x != typeof(IBaseDas));
            if (interfaceWorkflow == null) continue;
            services.AddScoped(interfaceWorkflow, type);
        }
    }

    public static void AddServices(this IServiceCollection services, Assembly assembly)
    {
        var validatorTypes = assembly.GetTypes().Where(x => x is { IsClass: true, IsAbstract: false, BaseType.IsGenericType: true }
                                                            && x.BaseType.GetGenericTypeDefinition() == typeof(AbstractValidator<>));

        foreach (var validatorType in validatorTypes)
        {
            var modelType = validatorType.BaseType?.GetGenericArguments().FirstOrDefault();
            if (modelType == null) continue;
            var interfaceType = typeof(IValidator<>).MakeGenericType(modelType);
            services.AddScoped(interfaceType, validatorType);
        }

        var classAssembly = assembly.GetTypes().Where(x => x.IsClass && x.GetInterface(nameof(IBaseService)) != null);
        foreach (var type in classAssembly)
        {
            var interfaceWorkflow = type.GetInterfaces().FirstOrDefault(x => x != typeof(IBaseService));
            if (interfaceWorkflow == null) continue;
            services.AddScoped(interfaceWorkflow, type);
        }
    }
}
