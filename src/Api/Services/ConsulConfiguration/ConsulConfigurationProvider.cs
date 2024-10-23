using System.Text;
using Consul;
using Newtonsoft.Json.Linq;

namespace UserService.Api.Services.ConsulConfiguration;

public class ConsulConfigurationProvider : ConfigurationProvider
{
    private readonly ConsulClient _client;
    private readonly Uri _consulAddress;
    private readonly string _prefix;

    public ConsulConfigurationProvider(string prefix, Uri consulAddress)
    {
        _prefix = prefix;
        _consulAddress = consulAddress;
        _client = new ConsulClient(config => { config.Address = consulAddress; });
    }

    public override void Load()
    {
        QueryResult<KVPair>? result = _client.KV.Get(_prefix).Result;

        if (result.Response == null)
        {
            return;
        }

        string json = Encoding.UTF8.GetString(result.Response.Value);
        JObject config = JObject.Parse(json);

        foreach (KeyValuePair<string, string> kv in Flatten(config))
        {
            Data[kv.Key] = kv.Value;
        }
    }

    private IEnumerable<KeyValuePair<string, string>> Flatten(JToken token, string parentKey = "")
    {
        switch (token)
        {
            case JObject obj:
                {
                    foreach (JProperty property in obj.Properties())
                    {
                        string newKey = string.IsNullOrEmpty(parentKey)
                            ? property.Name
                            : $"{parentKey}:{property.Name}";
                        foreach (KeyValuePair<string, string> kv in Flatten(property.Value, newKey))
                        {
                            yield return kv;
                        }
                    }

                    break;
                }
            case JArray arr:
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        string newKey = $"{parentKey}:{i}";
                        foreach (KeyValuePair<string, string> kv in Flatten(arr[i], newKey))
                        {
                            yield return kv;
                        }
                    }

                    break;
                }
            default:
                yield return new KeyValuePair<string, string>(parentKey, token.ToString());
                break;
        }
    }
}
