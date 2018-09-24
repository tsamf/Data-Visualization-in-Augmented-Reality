using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ConsumableDAC : MonoBehaviour {

    //List<ConsumableLine> consumables();
  
    public static List<ConsumableLine> LoadConsumables()
    {
        string file = GetFileFromDisk("Canned Consumable.txt");
        return PopulateConsumables(file);
    }

    private static List<ConsumableLine> PopulateConsumables(string file)
    {
        List<ConsumableLine> result = new List<ConsumableLine>();

        string fileData = file.Replace('\r', ' ');
        fileData = file.Replace('"', ' ');
        string[] consumables = fileData.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        for(int i = 1; i < consumables.Length; i++)
        {
            ConsumableLine consumableLine = new ConsumableLine();

            string[] fileLine = consumables[i].Split(',');

            consumableLine.pressure = float.Parse(fileLine[0]);
            consumableLine.heartRate = float.Parse(fileLine[1]);
            consumableLine.bodyTemp = float.Parse(fileLine[2]);
            consumableLine.oxygen = float.Parse(fileLine[3]);
            consumableLine.water = float.Parse(fileLine[4]);
            consumableLine.battery = float.Parse(fileLine[5]);

            result.Add(consumableLine);
        }

        return result;
    }

    private static string GetFileFromDisk(string filename)
    {
        try
        {
            string fileName = Path.Combine(Application.streamingAssetsPath, filename);
            byte[] bytes = UnityEngine.Windows.File.ReadAllBytes(fileName);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        catch
        {
            Debug.LogWarning("Consumable DAC: Error loading file.");
            return string.Empty;
        }
    }  
}

public class ConsumableLine
{
    public float pressure;
    public float heartRate;
    public float bodyTemp;
    public float oxygen;
    public float water;
    public float battery;
}