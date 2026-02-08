using UnityEngine;

public class SimulationWeatherService : MonoBehaviour, IWeatherService
{
    public void RequestWeather()
    {
        var randomType = (WeatherType)Random.Range(0,3);
        var data = new WeatherData(randomType);

        WeatherSystem.Instance.Context.SetWeather(data);
    }
}
