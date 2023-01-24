using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AndroidPluginSample : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button button;
    private AndroidJavaObject pluginInstance;

    // Start is called before the first frame update
    void Start()
    {
        var pluginClass = new AndroidJavaObject("com.example.myplugin.UnityPlugin");
        pluginInstance = pluginClass.CallStatic<AndroidJavaObject>("instance");
        text.text = pluginInstance.Call<string>("GetPackageName");
        button.onClick.AddListener(() =>
        {
            pluginInstance.Call("UnitySendMessage", gameObject.name, "CallByAndroid", "Hello");
        });
     }

    void CallByAndroid(string message)
    {
        pluginInstance.Call("ShowToast", message);
    }
}
