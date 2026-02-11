using UnityEngine;

public class WeatherServiceController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour serviceBehaviour;

    private IWeatherService service;

    private void Awake()
    {
        service = serviceBehaviour as IWeatherService;

        if (serviceBehaviour == null)
        {
            Debug.LogError("Service Behaviour NOT assigned");
        }

        if (service == null)
        {
            Debug.LogError("Assigned behaviour does not implement IWeatherService");
        }
    }

    public void RequestWeather()
    {
        Debug.Log("WeatherServiceController RequestWeather CALLED");
        service.RequestWeather();
    }
}