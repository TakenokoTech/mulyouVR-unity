using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Video;
using VideoLibrary;

public class MovieManager : MonoBehaviour {

    [NonSerialized] public string movieTitle;
    [NonSerialized] public string moviePath;

    private string uri = "https://youtu.be/88POYNT42vs"; //"Youtubeの動画のURI";
    private VideoPlayer videoPlayer;
    private bool moviePlayFlag = false;
    private WebGLFile file = new WebGLFile();

    private void Awake() {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private async void Start() {
        var v = await GetVideoInforationAsync(uri);
        if (v == null || !(IsFormatSupport(v.FileExtension))) return;

        movieTitle = v.FullName;
        moviePath = @"/" + movieTitle;
        if (file.IsFileExist(moviePath)) return;

        var t = await DownLoadMovieFromYoutubeAsync(v);
        if (t == null) return;

        Debug.Log("dataPath: " + moviePath);
        file.Write(moviePath, t);
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Update() {
        if (!moviePlayFlag) {
            if (!file.IsFileExist(moviePath)) return;
            videoPlayer.url = Application.persistentDataPath + moviePath;
            videoPlayer.Play();
            videoPlayer.SetDirectAudioVolume(0, 0);
            moviePlayFlag = true;
        }
    }

    void OnApplicationQuit() {
        Debug.Log("OnApplicationQuit");
        videoPlayer.clip = null;
        file.Delete(moviePath);
    }

    private async Task<YouTubeVideo> GetVideoInforationAsync(string uri) {
        try {
            var youTube = YouTube.Default;
            var video = await youTube.GetVideoAsync(uri);
            Debug.Log("動画情報を取得しました。");
            return video;
        }
        catch (Exception e) {
            Debug.Log("動画情報取得時にエラーが発生しました。:" + e);
            return null;
        }
    }

    private bool IsFormatSupport(string fileExtention) {
        string[] supportFormat = { ".asf", ".avi", ".dv", ".m4v", ".mov", ".mp4", ".mpg", ".mpeg", ".ogv", ".vp8", ".webm", ".wmv" };
        for (int i = 0; i < supportFormat.Length; i++) {
            if (fileExtention.Equals(supportFormat[i])) return true;
        }
        Debug.Log("対応していない動画フォーマットです:" + fileExtention);
        return false;
    }

    private async Task<byte[]> DownLoadMovieFromYoutubeAsync(YouTubeVideo y) {
        Debug.Log("IsEncrypted: " + y.IsEncrypted);
        try {
            if (!y.IsEncrypted) {
                Debug.Log("動画の再生準備中です。少しお待ちください。");
                byte[] bytes = await y.GetBytesAsync();
                Debug.Log("完了しました！");
                return bytes;
            }
            else {
                Debug.Log("再生できない動画です。");
                return null;
            }
        }
        catch (Exception e) {
            Debug.Log("動画再生準備時にエラーが発生しました。:" + e);
            return null;
        }
    }
}
