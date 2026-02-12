using UnityEngine;

[System.Serializable]
public class OpenMeteoResponse
{
    public CurrentWeather current_weather;
}

[System.Serializable]
public class CurrentWeather
{
    public int weathercode;
    public float temperature;
    public float windspeed;
    public int is_day;
}