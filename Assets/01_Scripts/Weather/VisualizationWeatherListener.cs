using UnityEngine;

public class VisualizationWeatherListener : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private AddressablesWeatherFXLoader fxLoader;

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

        fxLoader.ClearCurrentFX();

        switch (data.weatherType)
        {
            case WeatherType.Clear:
                directionalLight.color = Color.white;
                break;

            case WeatherType.Rain:
                directionalLight.color = Color.gray;
                fxLoader.LoadFX("RainFX");
                break;

            case WeatherType.Snow:
                directionalLight.color = Color.cyan;
                fxLoader.LoadFX("SnowFX");
                break;
        }
    }
}
