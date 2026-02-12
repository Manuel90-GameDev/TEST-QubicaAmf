using UnityEngine;

[System.Serializable]
public class WeatherData
{
    public float temperature;
    public float windSpeed;
    public bool is_day;
    public WeatherType weatherType;

    public WeatherData(WeatherType type)
    {
        weatherType = type;
    }
}