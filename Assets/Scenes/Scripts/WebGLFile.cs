using System.IO;
using UnityEngine;

public class WebGLFile {

    public void Write(string filePath, byte[] data) {
        string dataPath = Application.persistentDataPath + filePath;
        Debug.Log("dataPath: " + dataPath);
        // byte[] d = System.Text.Encoding.GetEncoding("Shift_JIS").GetBytes(data);
        File.WriteAllBytes(dataPath, data);
        Debug.Log("dataPath: " + dataPath);
    }

    public byte[] Read(string filePath) {
        string dataPath = Application.persistentDataPath + filePath;
        Debug.Log("dataPath: " + dataPath);
        byte[] fileData = File.ReadAllBytes(dataPath);
        Debug.Log("fileData length: " + fileData.Length);
        return fileData;
    }

    public void Delete(string filePath) {
        string dataPath = Application.persistentDataPath + filePath;
        if (IsFileExist(dataPath)) {
            File.Delete(dataPath);
            Debug.Log("動画ファイルを削除しました。");
        }
        if (IsFileExist(dataPath + ".meta")) {
            File.Delete(dataPath + ".meta");
            Debug.Log("メタファイルを削除しました。");
        }
    }

    public bool IsFileExist(string filePath) {
        if (File.Exists(filePath)) {
            Debug.Log("ファイルが存在します。");
            return true;
        }
        string dataPath = Application.persistentDataPath + filePath;
        if (File.Exists(dataPath)) {
            Debug.Log("ファイルが存在します。");
            return true;
        }
        return false;
    }

}
