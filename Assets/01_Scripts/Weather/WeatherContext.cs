using System;
using UnityEngine;

public class WeatherContext
{
    public WeatherData CurrentWeather { get; private set; }

    public event Action<WeatherData> OnWeatherChanged;

    public void SetWeather(WeatherData data)
    {
        CurrentWeather = data;
        OnWeatherChanged?.Invoke(data);
    }
}
