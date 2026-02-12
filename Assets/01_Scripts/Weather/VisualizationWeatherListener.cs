using UnityEngine;

public class VisualizationWeatherListener : MonoBehaviour
{
    [SerializeField] private GameObject directionalLight;
    [SerializeField] private AddressablesWeatherFXLoader fxLoader;

    private void OnEnable()
    {
        WeatherSystem.Instance.Context.OnWeatherChanged += ApplyWeather;

        var current = WeatherSystem.Instance.Context.CurrentWeather;
        if (current != null)
        {
            ApplyWeather(current);
        }
    }

    private void OnDisable()
    {
        WeatherSystem.Instance.Context.OnWeatherChanged -= ApplyWeather;
    }

    private void ApplyWeather(WeatherData data)
    {
        fxLoader.ClearCurrentFX();

        Light directionalLightComponent = directionalLight.GetComponent<Light>();
        Transform directionalLightTransform = directionalLight.GetComponent<Transform>();

        if (data.is_day)
        {
            directionalLightComponent.intensity = 1f;
            directionalLightTransform.localRotation = Quaternion.Euler(50f, -30f, 0f);
        }
        else
        {
            directionalLightComponent.intensity = 0.2f;
            directionalLightTransform.localRotation = Quaternion.Euler(20f, -30f, 0f);
        }

        switch (data.weatherType)
        {
            case WeatherType.Clear:
                directionalLightComponent.color = Color.white;
                break;

            case WeatherType.Rain:
                directionalLightComponent.color = Color.gray;
                fxLoader.LoadFX("RainFX");
                break;

            case WeatherType.Snow:
                directionalLightComponent.color = Color.cyan;
                fxLoader.LoadFX("SnowFX");
                break;
        }
    }
}
