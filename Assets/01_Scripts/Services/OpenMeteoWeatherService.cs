using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class OpenMeteoWeatherService : MonoBehaviour
{
    private const string URL = "https://api.open-meteo.com/v1/forecast?latitude=45.46&longitude=9.19&current_weather=true";

    private void Start()
    {
        RequestWeather();
    }

    public void RequestWeather()
    {
        Debug.Log("RequestWeather CALLED");
        StartCoroutine(GetWeather());
    }

    private IEnumerator GetWeather()
    {
        Debug.Log("API CALL STARTED");

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

        Debug.Log("Weather Code: " + response.current_weather.weathercode);

        var data = ConvertWeather(response.current_weather.weathercode);

        WeatherSystem.Instance.Context.SetWeather(data);
    }

    private WeatherData ConvertWeather(int code)
    {
        var type = WeatherType.Clear;

        if (code >= 70)
        {
            type = WeatherType.Snow;
        }
        else if (code >= 50)
        {
            type = WeatherType.Rain;
        }

        return new WeatherData(type);
    }
}