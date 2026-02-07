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
        Debug.Log($"Simulated: {data.weatherType}");
    }

    public void SimulateRain()
    {
        var data = simulationService.GenerateWeather(WeatherType.Rain);
        Debug.Log($"Simulated: {data.weatherType}");
    }

    public void SimulateSnow()
    {
        var data = simulationService.GenerateWeather(WeatherType.Snow);
        Debug.Log($"Simulated: {data.weatherType}");
    }
}
