using UnityEngine;

public class VisualizationWeatherListener : MonoBehaviour
{
    [SerializeField] private Light directionalLight;

    private void OnEnable()
    {
        Debug.Log("VisualizationWeatherListener enabled, subscribing to weather changes.");
        WeatherSystem.Instance.Context.OnWeatherChanged += ApplyWeather;

        var current = WeatherSystem.Instance.Context.CurrentWeather;
        if (current != null)
        {
            ApplyWeather(current);
        }
    }

    private void OnDisable()
    {
        Debug.Log("VisualizationWeatherListener disabled, unsubscribing from weather changes.");
        WeatherSystem.Instance.Context.OnWeatherChanged -= ApplyWeather;
    }

    private void ApplyWeather(WeatherData data)
    {
        Debug.Log($"Applying Weather: {data.weatherType}");

        switch (data.weatherType)
        {
            case WeatherType.Clear:
                directionalLight.color = Color.white;
                break;

            case WeatherType.Rain:
                directionalLight.color = Color.gray;
                break;

            case WeatherType.Snow:
                directionalLight.color = Color.cyan;
                break;
        }
    }
}
