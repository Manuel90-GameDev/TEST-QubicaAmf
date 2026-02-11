using UnityEngine;

public class WeatherServiceController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour serviceBehaviour;

    private IWeatherService service;

    private void Awake()
    {
        service = serviceBehaviour as IWeatherService;
    }

    public void RequestWeather(LocationData location)
    {
        if (service is OpenMeteoWeatherService api)
        {
            api.RequestWeather(location);
        }
        else
        {
            service.RequestWeather(location);
        } 
    }
}