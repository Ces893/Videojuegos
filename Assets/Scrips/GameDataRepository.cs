using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameDataRepository : MonoBehaviour
{
    public void SaveGame(GameData data)
    {
        // Save the game data
        var filePath = Application.persistentDataPath + "/gameData.json";
        FileStream file;
        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);
        }
        var formatter = new BinaryFormatter();
        formatter.Serialize(file, data);
        file.Close();
    }
    public GameData LoadGame()
    {
        var filePath = Application.persistentDataPath + "/gameData.json";
        Debug.Log(filePath);
        if (File.Exists(filePath))
        {
            var file = File.OpenRead(filePath);
            var formatter = new BinaryFormatter();
            var data = (GameData)formatter.Deserialize(file);
            file.Close();
            return data;
        }
        else
        {
            return new GameData();
        }
    }
}
