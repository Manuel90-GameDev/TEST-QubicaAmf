using UnityEngine;

public class WeatherServiceController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour serviceBehaviour;

    private IWeatherService service;

    private void Awake()
    {
        service = serviceBehaviour as IWeatherService;

        Debug.Log("ServiceController Awake");
        Debug.Log("Assigned Behaviour: " + serviceBehaviour);

        if (service == null)
            Debug.LogError("SERVICE IS NULL");
        else
            Debug.Log("Service Type: " + service.GetType());
    }

    public void RequestWeather()
    {
        Debug.Log("WeatherServiceController RequestWeather CALLED");
        service.RequestWeather();
    }
}