using TMPro;
using UnityEngine;

public class DashboardWeatherDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperatureText;
    [SerializeField] private TextMeshProUGUI windText;
    [SerializeField] private TextMeshProUGUI conditionText;

    private void OnEnable()
    {
        if (WeatherSystem.Instance == null || WeatherSystem.Instance.Context == null)
        {
            return;
        }

        WeatherSystem.Instance.Context.OnWeatherChanged += UpdateUI;
    }

    private void OnDisable()
    {
        if (WeatherSystem.Instance == null || WeatherSystem.Instance.Context == null)
        {
            return;
        }

        WeatherSystem.Instance.Context.OnWeatherChanged -= UpdateUI;
    }

    private void UpdateUI(WeatherData data)
    {
        temperatureText.text = $"{data.temperature}°C";
        windText.text = $"{data.windSpeed} km/h";
        conditionText.text = $"{data.weatherType}";
    }
}
