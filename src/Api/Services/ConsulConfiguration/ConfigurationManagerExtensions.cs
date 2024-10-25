using System.Reflection;
using Consul;

namespace UserService.Api.Services.ConsulConfiguration;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddConsul(
        this ConfigurationManager manager)
    {
        IConfigurationBuilder configBuilder = manager;
        IConfigurationSection consulAddress = manager.GetSection("Configuration:Consul:Url");
        Guard.Against.NullOrEmpty(consulAddress.Value);
        var consulKey = Assembly.GetExecutingAssembly().GetName().Name + "/appsettings.json";
        Guard.Against.NullOrEmpty(consulKey);
        // CUSTOM CONSUL CONFIGURATION
        // configBuilder.Add(new ConsulConfigurationSource(consulKey, new Uri(consulAddress.Value)));
        
        var consulClient = new ConsulClient(config => config.Address = new Uri(consulAddress.Value));
        var response = consulClient.KV.Get(consulKey).Result;
        Guard.Against.Null(response.Response);
        manager.AddJsonStream(new MemoryStream(response.Response.Value));
        return manager;
    }
}
