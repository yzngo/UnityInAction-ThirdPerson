using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=HangZhou,CN&mode=xml&APPID=5b5269ade62687a6847d28196df214bd";
    private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=HangZhou,CN&APPID=5b5269ade62687a6847d28196df214bd";

    private IEnumerator CallAPI(string url, Action<string> callback)
    {
        using (UnityWebRequest request = UnityWebRequest.Get(url)) {
            yield return request.SendWebRequest();

            if (request.isNetworkError) {
                Debug.LogError("network problem: " + request.error);

            } else if (request.responseCode != (long)System.Net.HttpStatusCode.OK) {
                Debug.LogError("respone error: " + request.responseCode);

            } else {
                callback(request.downloadHandler.text);
            }
        }
    }

    public IEnumerator GetWeatherXML(Action<string> callback) 
    {
        return CallAPI(xmlApi, callback);
    }
    public IEnumerator GetWeatherJson(Action<string> callback) 
    {
        return CallAPI(jsonApi, callback);
    }

}
