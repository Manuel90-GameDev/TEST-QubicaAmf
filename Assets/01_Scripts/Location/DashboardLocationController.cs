using TMPro;
using UnityEngine;

public class DashboardLocationController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown locationDropdown;
    [SerializeField] private TMP_InputField latitudeInput;
    [SerializeField] private TMP_InputField longitudeInput;
    [SerializeField] private WeatherServiceController weatherService;

    public void RequestWeatherFromUI()
    {
        LocationType selected = (LocationType)locationDropdown.value;

        LocationData location = selected switch
        {
            LocationType.London => new LocationData(51.5072f, -0.1276f),

            LocationType.NewYork => new LocationData(40.7128f, -74.0060f),

            LocationType.Custom => new LocationData(
                        float.Parse(latitudeInput.text),
                        float.Parse(longitudeInput.text)
                    ),

            _ => new LocationData(0, 0)
        };

        weatherService.RequestWeather(location);
    }
}
