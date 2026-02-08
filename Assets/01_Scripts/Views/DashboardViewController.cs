using UnityEngine;

public class DashboardViewController : BaseViewController
{
    [SerializeField] private WeatherServiceController weatherService;

    public void SimulateClear()
    {
        WeatherSystem.Instance.Context.SetWeather(new WeatherData(WeatherType.Clear));
    }

    public void SimulateRain()
    {
        WeatherSystem.Instance.Context.SetWeather(new WeatherData(WeatherType.Rain));
    }

    public void SimulateSnow()
    {
        WeatherSystem.Instance.Context.SetWeather(new WeatherData(WeatherType.Snow));
    }

    public void RequestRealWeather()
    {
        weatherService.RequestWeather();
    }
}
