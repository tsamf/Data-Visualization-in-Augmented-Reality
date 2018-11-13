using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

#if UNITY_WINRT
using File = UnityEngine.Windows.File;
#else
using File = System.IO.File;
#endif

public class WriteFile : MonoBehaviour {

    FlagStore flagStore;
    
    public DB_GenerateData oxygen;
    public DB_GenerateData oxygen2;
    public DB_GenerateData suitPressure;
    public DB_GenerateData battery;
    public DB_GenerateData bodyTemperature;
    public DB_GenerateData water;
    public DB_GenerateData heartRate;

    Activity activity;

    string filename = "testwriting.txt";
    string data = "";
    string header = "event type\tcamera position\tcamera rotation\toxygen\toxygen two\tsuit pressure\tbattery\tbody temperature\twater\theart rate\ttimestamp\tseconds passed in game\ttask text\ttask setp\tprocedure number\t\n";

    GameObject camera;

	// Use this for initialization
	void Start () {
        data += header;
        flagStore = FlagStore.GetInstance();
        camera = GameObject.FindGameObjectWithTag("MainCamera");
        activity = Activity.GetInstance();

        //CreateFile();
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void WriteLine(string from)
    {
        string line = "";
        line += from + "\t";
        line += camera.transform.position.ToString() + "\t";
        line += camera.transform.rotation.ToString() + "\t";
        line += oxygen.current + "\t";
        line += oxygen2.current + "\t";
        line += suitPressure.current + "\t";
        line += battery.current + "\t";
        line += bodyTemperature.current + "\t";
        line += water.current + "\t";
        line += heartRate.current;
        line += "\t";
        line += DateTime.Now.ToString("HH:MM:ss.fff") + "\t";
        line += Time.time + "\t";

        if(activity.GetCurrentProcedure()!= null)
        {
            line += activity.GetCurrentProcedure().GetCurrentTask().Text + "\t";
            line += activity.GetCurrentProcedure().GetCurrentTask().StepNumer + "\t";
            line += activity.GetProcedureNumber() + "\t";
        }
        else
        {
            line += "null" + "\t";
            line += "null" + "\t";
            line += "null" + "\t";
        }

        line += '\n';
        data += line;
    }

    public void CreateFile()
    {
        filename = flagStore.userID + "_" + DateTime.Now.ToString("HHMMss") + ".txt";
        var myfile = System.IO.File.Create(Path.Combine(Application.persistentDataPath, filename));
        myfile.Dispose();
    }

    void WriteToFile()
    {
        try
        {
            string path = Path.Combine(Application.persistentDataPath, filename);
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(data);
  
           File.WriteAllBytes(path, bytes);
        }
        catch
        {
            Debug.LogWarning("File write error!");
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            WriteToFile();
        }
    } 

    private void OnDestroy()
    {
        WriteToFile();
    }
}
