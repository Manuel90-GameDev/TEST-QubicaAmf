using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OpenMeteoWeatherService : MonoBehaviour, IWeatherService
{
    private const string URL = "https://api.open-meteo.com/v1/forecast?latitude=56.210949&longitude=159.346725&current_weather=true";

    private void Start()
    {
        RequestWeather();
    }

    public void RequestWeather()
    {
        Debug.Log("OpenMeteo Request START");
        StartCoroutine(GetWeather());
    }

    private IEnumerator GetWeather()
    {
        Debug.Log("API CALL START");

        using var request = UnityWebRequest.Get(URL);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API ERROR: " + request.error);
            yield break;
        }

        Debug.Log("API RESPONSE: " + request.downloadHandler.text);

        var json = request.downloadHandler.text;
        var response = JsonUtility.FromJson<OpenMeteoResponse>(json);

        Debug.Log("JSON RECEIVED");

        Debug.Log("Weather Code: " + response.current_weather.weathercode);

        var data = ConvertWeather(response.current_weather);

        WeatherSystem.Instance.Context.SetWeather(data);

        Debug.Log("WeatherSystem SetWeather CALLED");
    }

    private WeatherData ConvertWeather(CurrentWeather cw)
    {
        WeatherType type = WeatherType.Clear;

        int code = cw.weathercode;

        //SNOW
        if (code == 71 || code == 73 || code == 75 ||
            code == 77 ||
            code == 85 || code == 86)
        {
            type = WeatherType.Snow;
        }

        //RAIN
        else if (code == 51 || code == 53 || code == 55 ||
                    code == 61 || code == 63 || code == 65 ||
                    code == 80 || code == 81 || code == 82)
        {
            type = WeatherType.Rain;
        }

        return new WeatherData(type)
        {
            temperature = cw.temperature,
            windSpeed = cw.windspeed
        };
    }
}