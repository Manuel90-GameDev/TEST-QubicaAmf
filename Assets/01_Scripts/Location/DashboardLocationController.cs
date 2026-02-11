using System.Globalization;
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
                        float.Parse(latitudeInput.text, CultureInfo.InvariantCulture),
                        float.Parse(longitudeInput.text, CultureInfo.InvariantCulture)
                    ),

            _ => new LocationData(0, 0)
        };

        weatherService.RequestWeather(location);
    }

    public void OnLocationChanged(int value)
    {
        LocationType selected = (LocationType)value;

        bool isCustom = selected == LocationType.Custom;

        latitudeInput.interactable = isCustom;
        longitudeInput.interactable = isCustom;

        if (!isCustom)
        {
            latitudeInput.text = "";
            longitudeInput.text = "";
        }
    }
}
