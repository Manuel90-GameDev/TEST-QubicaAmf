using UnityEngine;

public class SimulationWeatherService
{
    public WeatherData GenerateWeather(WeatherType type)
    {
        //return new WeatherData
        //{
        //    temperature = Random.Range(-5f, 30f),
        //    windSpeed = Random.Range(0f, 15f),
        //    weatherType = type
        //};

        return new WeatherData(type);
    }
}
