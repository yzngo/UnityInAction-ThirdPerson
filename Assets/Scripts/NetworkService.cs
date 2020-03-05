using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkService
{
    private const string xmlApi = "http://api.openweathermap.org/data/2.5/weather?q=HangZhou,CN&mode=xml&APPID=5b5269ade62687a6847d28196df214bd";
    private const string jsonApi = "http://api.openweathermap.org/data/2.5/weather?q=HangZhou,CN&APPID=5b5269ade62687a6847d28196df214bd";
    private const string webImage = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1583255876005&di=2052dbe788538cf1a7fa02b266c7cf07&imgtype=0&src=http%3A%2F%2Fi0.hdslb.com%2Fbfs%2Farticle%2F19de927d6de05d9ea9d6cc6a5042f8bb0f270100.jpg";
    private const string localApi = "http://127.0.0.1:8080/playfab/savefile.lua";

    private IEnumerator CallAPI(string url, WWWForm form, Action<string> callback)
    {
        using (UnityWebRequest request = (form == null) ?
                UnityWebRequest.Get(url) : UnityWebRequest.Post(url, form)) {
                    yield return request.SendWebRequest();
                    if (request.isNetworkError) {
                        Debug.LogError("network problem: " + request.error);
                    } 
                    else if (request.responseCode != (long)System.Net.HttpStatusCode.OK)
                    {
                        Debug.LogError("request error: " + request.responseCode);
                    } else {
                        callback(request.downloadHandler.text);
                    }
                }
    }
    public IEnumerator GetWeatherXML(Action<string> callback) 
    {
        return CallAPI(xmlApi, null, callback);
    }
    public IEnumerator GetWeatherJson(Action<string> callback) 
    {
        return CallAPI(jsonApi, null, callback);
    }
    public IEnumerator LogWeather(string name, float cloudValue, Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", name);
        form.AddField("cloud_value", cloudValue.ToString());
        form.AddField("timestamp", DateTime.UtcNow.Ticks.ToString());

        return CallAPI(localApi, form, callback);
    }
    public IEnumerator DownloadImage(Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(webImage);
        yield return request.SendWebRequest();
        callback(DownloadHandlerTexture.GetContent(request));
    }

}
