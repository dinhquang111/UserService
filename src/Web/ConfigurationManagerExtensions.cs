namespace UserService.Web;

public static class ConfigurationManagerExtensions
{
    public static ConfigurationManager AddConsul(
        this ConfigurationManager manager)
    {
        IConfigurationBuilder configBuilder = manager;

        IConfigurationSection consulAddress = manager.GetSection("ConsulAddress");
        IConfigurationSection consulKey = manager.GetSection("ConsulKey");
        if (string.IsNullOrWhiteSpace(consulAddress.Value) || string.IsNullOrWhiteSpace(consulKey.Value))
        {
            throw new ArgumentException("Consul address is not found");
        }

        configBuilder.Add(new ConsulConfigurationSource(consulKey.Value, new Uri(consulAddress.Value)));
        return manager;
    }
}
