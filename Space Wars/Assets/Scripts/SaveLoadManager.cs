using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;
public class SaveLoadManager 
{

    public void SaveData()
    {
        SerializedData mySerializedData = new SerializedData();
        mySerializedData.ser_score = GameData.Score;
        mySerializedData.ser_health = GameData.PlayerHealth;

        BinaryFormatter bf = new BinaryFormatter();

        FileStream myfile = File.Create(Application.persistentDataPath + "/CannonData.save");
        bf.Serialize(myfile, mySerializedData);  //Serialize and save
        myfile.Close();
        Debug.Log("FILE SAVED");
    }

    public void LoadData()
    {
        SerializedData mySerializedData = new SerializedData();

        if (File.Exists(Application.persistentDataPath + "/CannonData.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream myfile = File.Open(Application.persistentDataPath + "/CannonData.save", FileMode.Open);
            mySerializedData = (SerializedData)bf.Deserialize(myfile);
            myfile.Close();

            GameData.Score = mySerializedData.ser_score;
            GameData.PlayerHealth = mySerializedData.ser_health;
        }
    }

    public void DeleteFile()
    {
        if (File.Exists(Application.persistentDataPath + "/CannonData.save"))
        {
            File.Delete(Application.persistentDataPath + "/CannonData.save");
        }

    }

}