namespace UserService.Web;

public class ConsulConfigurationSource(string keyPrefix, Uri consulAddress) : IConfigurationSource
{
    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new ConsulConfigurationProvider(keyPrefix, consulAddress);
    }
}
