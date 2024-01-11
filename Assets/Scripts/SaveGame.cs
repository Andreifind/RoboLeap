using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveGame
{
    public static void SavePlayer(Behaviour player)
    {
        BinaryFormatter formater = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.jmp";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);
        formater.Serialize(stream, data);
        stream.Close();
        Debug.Log("Game saved");
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.jmp";
        if (File.Exists(path))
        {
            BinaryFormatter formater = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formater.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;
            Debug.Log("Save found");
        }
        else
        {
            Debug.LogError("Save file not found in "+ path);
            return null;
        }
    }
    public static void Delete()
    {
        try
        {
            File.Delete(Application.persistentDataPath + "/player.jmp");
            Debug.Log("Delete successfull!");
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
        }
    }
    public static int CanContinue()
    {
        string path = Application.persistentDataPath + "/player.dt";
        if (File.Exists(path)) return 1;
        else return 0;
    }
}
