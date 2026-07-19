using Microsoft.Extensions.DependencyInjection;

namespace Utilities.Configuration;

public static class ConfigurationServiceRegistration
{
	public static IServiceCollection AddConfigurationServices(this IServiceCollection services, string? mediatRLicenseKey = null)
	{
		services.AddLogging();

		services.AddMediatR(cfg =>
		{
			if(!string.IsNullOrWhiteSpace(mediatRLicenseKey))
			{
				cfg.LicenseKey = mediatRLicenseKey;
			}

			cfg.RegisterServicesFromAssemblies(typeof(ConfigurationServiceRegistration).Assembly);
		});

		return services;
	}
}
