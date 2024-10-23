using UserService.Application.WeatherForecasts.Queries.GetWeatherForecasts;

namespace UserService.Api.Endpoints;

public class WeatherForecasts : IEndpointGroupBase
{
    public void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecasts);
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }
}
