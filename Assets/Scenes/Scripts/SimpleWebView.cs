using UnityEngine;

public class SimpleWebView : MonoBehaviour {

    private string url = "https://www.google.co.jp/";
    WebViewObject webViewObject;

    void Start() {
        webViewObject = (new GameObject("WebViewObject")).AddComponent<WebViewObject>();
        webViewObject.Init((msg) => {
            Debug.Log(msg);
        });
        webViewObject.LoadURL(url);
        // 中央に配置
        webViewObject.SetMargins(Screen.width / 4, Screen.height / 4, Screen.width / 4, Screen.height / 4);
        webViewObject.SetVisibility(true);
    }


    void Update() {

    }
}
