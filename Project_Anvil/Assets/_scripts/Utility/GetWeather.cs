using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class GetWeather : MonoBehaviour {

    float myLat;
    float myLong;
    bool isFinished = false;
    float gridX;
    float gridY;
    public float temperature;
    public float windSpeed;
    public float windDirection;

    // Use this for initialization
    void Start() {
        StartCoroutine(StartLocService());
        StartCoroutine(SecondStart());
    }

    // Update is called once per frame
    void Update() {

    }
    // SecondStart //
    // needed because Start function cant to waitforseconds. it also starts the weather to update ever 1000 seconds //
    IEnumerator SecondStart()
    {
        yield return new WaitForSeconds(21);
        if (Input.location.status != LocationServiceStatus.Failed && isFinished)
        {
            InvokeRepeating("StartWeather", 1, 1000);
        }
        else
        {
            Debug.Log("the location services are not working, cant get location.");
        }
    }

    // StartLocServices //
    // checks to see if the GPS can be enabled and then enables it if so. sets isFinished to true if successful //
    IEnumerator StartLocService()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
        {
            isFinished = false;
            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            isFinished = false;
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            isFinished = false;
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            isFinished = true;
            yield break;
        }
    }
    // StartWeather //
    // starts the process of getting the local weather. must start by getting a location, sending that
    // to the server, which returns gridpoints, which we parse and then send those to the server to
    // get the actual weather report //
    IEnumerator StartWeather()
    {
        myLat = Input.location.lastData.latitude;
        myLong = Input.location.lastData.longitude;
        Input.location.Stop();
        string firstURLToFetch = "https://api.weather.gov/points/" + myLat + "," + myLong;
        yield return new WaitForSeconds(10);
        Vector2 myLoc = new Vector2(myLat, myLong);
        Debug.Log(myLoc);
        StartCoroutine(GetGridPoints(firstURLToFetch));
        yield return new WaitForSeconds(10);
        string secondURLToFetch = "https://api.weather.gov/gridpoints/TOP/" + gridX + "," + gridY;
        StartCoroutine(LoadWeather(secondURLToFetch));
    }



    // LoadWeather //
    // Gets the json data from the server if possible, then sends it to ReadWeather() for parsing //
    IEnumerator GetGridPoints(string _myURL)
    {
        UnityWebRequest fetch = UnityWebRequest.Get(_myURL);
        yield return fetch.SendWebRequest();

        if (fetch.isNetworkError || fetch.isHttpError)
        {
            Debug.Log(fetch.error);
        }
        else
        {
            string theJson = fetch.downloadHandler.text;
            ParseGridPoints(theJson);
        }
    }

    // ReadWeather //
    // takes a json sting and parses it to get weather data then assigns it to a WeatherData object //
    void ParseGridPoints(string _theJson)
    {
        var json = JSON.Parse(_theJson);

        gridX = json["properties"]["gridX"];
        gridY = json["properties"]["gridY"];
    
    }



    // LoadWeather //
    // Gets the json data from the server if possible, then sends it to ParseWeather() for parsing //
    IEnumerator LoadWeather(string _myURL)
    {
        UnityWebRequest fetch = UnityWebRequest.Get(_myURL);
        yield return fetch.SendWebRequest();

        if (fetch.isNetworkError || fetch.isHttpError)
        {
            Debug.Log(fetch.error);
        }
        else
        {
            string theJson = fetch.downloadHandler.text;
            ParseWeather(theJson);
        }
    }

    // ParseWeather //
    // takes a json sting and parses it to get weather data then assigns it to a WeatherData object //
    void ParseWeather(string _theJson)
    {
        var json = JSON.Parse(_theJson);
        temperature = json["properties"]["temperature"]["values"][0][1];
        windSpeed = json["properties"]["windSpeed"]["values"][0][1];
        windDirection = json["properties"]["windDirection"]["values"][0][1];
    }
}

