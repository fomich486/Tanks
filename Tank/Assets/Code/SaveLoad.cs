using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveLoad
{
    public static void SaveAsJSON(string _lastScore)
    {
        string path = Application.persistentDataPath + "/playerInfo.json";
        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
        }
        SavedData data = new SavedData { LastScore = _lastScore};
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
        Debug.Log("Saving as JSON: " + json);
    }

    public static SavedData LoadAsJSON()
    {
        SavedData data = new SavedData { LastScore = "" };
        string path = Application.persistentDataPath + "/playerInfo.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SavedData>(json);
        }
        return data;
    }
}
[System.Serializable]
public class SavedData
{
    public string LastScore;
}