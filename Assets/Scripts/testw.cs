using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class testw : MonoBehaviour
{



    public GameObject[] ensemble;

    public GameObject[] images;

    //add audiosource
    public AudioSource audioSource;


    //add audio clips

    public AudioClip sunny;
    public AudioClip cloudy;
    public AudioClip rainy;
    public AudioClip snowy;

    



    // Start is called before the first frame update
    void Start()
    {

        setDefault();

        
    }


    public void setDefault()
    {
        for (int i = 0; i < ensemble.Length; i++)
        {
            ensemble[i].SetActive(false);
        }

        ensemble[0].SetActive(true);

        RenderSettings.ambientIntensity = 1.45f;

        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }
        




        
    }

    public void setSunny()
    {
        for (int i = 0; i < ensemble.Length; i++)
        {
            ensemble[i].SetActive(false);
        }

        ensemble[1].SetActive(true);

        if(images.Length > 2){
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        images[0].SetActive(true);
        }

        RenderSettings.ambientIntensity = 2.45f;
        audioSource.clip = sunny;
        audioSource.Play();
    }

    public void setCloudy()
    {
        for (int i = 0; i < ensemble.Length; i++)
        {
            ensemble[i].SetActive(false);
        }

        ensemble[2].SetActive(true);


        if(images.Length > 2){
            for (int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(false);
            }

            images[1].SetActive(true);
    }

        RenderSettings.ambientIntensity = 1.45f;
        audioSource.clip = cloudy;
        audioSource.Play();
    }

    public void setRainy()
    {
        for (int i = 0; i < ensemble.Length; i++)
        {
            ensemble[i].SetActive(false);
        }

        ensemble[3].SetActive(true);

        if(images.Length > 2){
            for (int i = 0; i < images.Length; i++)
            {
                images[i].SetActive(false);
            }

            images[2].SetActive(true);
        }

        RenderSettings.ambientIntensity = 0.75f;
        audioSource.clip = rainy;
        audioSource.Play();
    }

    public void setSnowy()
    {


        for (int i = 0; i < ensemble.Length; i++)
        {
            ensemble[i].SetActive(false);
        }

        ensemble[4].SetActive(true);


        if(images.Length > 2){
        for (int i = 0; i < images.Length; i++)
        {
            images[i].SetActive(false);
        }

        images[3].SetActive(true);
        }



        RenderSettings.ambientIntensity = 1.75f;
        audioSource.clip = snowy;
        audioSource.Play();
    }


    public void set(string town){


        if (string.IsNullOrEmpty(town))
        {
            return;
        }

        StartCoroutine(GetWeather(town));
    }

        IEnumerator GetWeather(string town)
    {
        string apiKey = "7b36c0969d26d4157b5eb0980fc5f5fd"; // Remplacez par votre clé API
        string url = $"https://api.openweathermap.org/data/2.5/weather?q={town},uk&APPID={apiKey}";

        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                ProcessWeatherData(webRequest.downloadHandler.text);
            }
        }
    }


    void ProcessWeatherData(string jsonData)
    {
        WeatherData weatherData = JsonUtility.FromJson<WeatherData>(jsonData);
        string weatherCondition = weatherData.weather[0].main;

        switch (weatherCondition)
        {
            case "Clear":
                setSunny();
                break;
            case "Clouds":
                setCloudy();
                break;
            case "Rain":
                setRainy();
                break;
            case "Snow":
                setSnowy();
                break;
            default:
                setDefault();
                break;
        }
    }

    [System.Serializable]
    private class WeatherData
    {
        public Weather[] weather;
    }

    [System.Serializable]
    private class Weather
    {
        public string main;
    }    

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
