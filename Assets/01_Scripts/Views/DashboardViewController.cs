using UnityEngine;

public class DashboardViewController : BaseViewController
{
    private SimulationWeatherService simulationService;

    private void Awake()
    {
        simulationService = new SimulationWeatherService();
    }

    public void SimulateClear()
    {
        var data = simulationService.GenerateWeather(WeatherType.Clear);
        WeatherSystem.Instance.Context.SetWeather(data);
    }

    public void SimulateRain()
    {
        var data = simulationService.GenerateWeather(WeatherType.Rain);
        WeatherSystem.Instance.Context.SetWeather(data);
    }

    public void SimulateSnow()
    {
        var data = simulationService.GenerateWeather(WeatherType.Snow);
        WeatherSystem.Instance.Context.SetWeather(data);
    }
}
