using TMPro;
using UnityEngine;

public class DashboardWeatherDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI temperatureText;
    [SerializeField] private TextMeshProUGUI windText;
    [SerializeField] private TextMeshProUGUI conditionText;

    private void OnEnable()
    {
        if (WeatherSystem.Instance == null ||
            WeatherSystem.Instance.Context == null)
        {
            Debug.LogWarning("WeatherSystem not ready yet.");
            return;
        }

        WeatherSystem.Instance.Context.OnWeatherChanged += UpdateUI;
    }

    private void OnDisable()
    {
        WeatherSystem.Instance.Context.OnWeatherChanged -= UpdateUI;
    }

    private void UpdateUI(WeatherData data)
    {
        Debug.Log("Dashboard UpdateUI CALLED");

        temperatureText.text = $"{data.temperature}°C";
        windText.text = $"{data.windSpeed} km/h";
        conditionText.text = $"{data.weatherType}";
    }
}
