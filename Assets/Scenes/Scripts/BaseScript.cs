using UnityEngine;

public class BaseScript : MonoBehaviour {

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void BeforeSceneLoad() {
        Debug.Log("BeforeSceneLoad");
    }

    [RuntimeInitializeOnLoadMethod]
    static void OnLoad() {
        Debug.Log("OnLoad");
    }

    void Awake() {
        Debug.Log("Awake");
    }

    void OnEnable() {
        Debug.Log("OnEnable");
    }

    void Start() {
        Debug.Log("Start");
    }

    void Update() {
        Debug.Log("Update");
    }

    void LateUpdate() {
        Debug.Log("LateUpdate");
    }

    void OnApplicationPause(bool b) {
        Debug.Log("OnApplicationPause " + b);
    }

    void OnApplicationQuit() {
        Debug.Log("OnApplicationQuit");
    }

    void OnDisable() {
        Debug.Log("OnDisable");
    }

    void OnDestroy() {
        Debug.Log("OnDestroy");
    }
}
