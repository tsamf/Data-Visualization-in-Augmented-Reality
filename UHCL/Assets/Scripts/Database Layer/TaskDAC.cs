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

public class TaskDAC {

    public static void LoadActivity()
    {
        string file = GetFileFromDisk("Canned Task.txt");
        PopulateActivity(file);
    }

    private static void PopulateActivity(string file)
    {
        Activity activity = Activity.GetInstance();

        string fileData = file.Replace('\r', ' ');
        fileData = file.Replace('"', ' ');
        string[] procedures = fileData.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string procedureString in procedures)
        {
          activity.AddProcedure(CreateProcedure(procedureString));
        }
    }

    private static EVATask CreateTask(string taskString)
    {
        string[] taskStrings = taskString.Split('\t');
        EVATask task = new EVATask(
            Convert.ToInt32(taskStrings[0].Replace("\r", "")),
            float.Parse(taskStrings[1].Replace("\r", "")),
            taskStrings[2].Replace("\r", ""),
            taskStrings[3].Replace("\r", ""),
            taskStrings[4].Replace("\r", ""),
            taskStrings[5].Replace("\r", ""),
            taskStrings[6].Replace("\r", ""));
        return task;
    }

    private static EVAProcedure CreateProcedure(string procedureString)
    {
        EVAProcedure procedure = new EVAProcedure();

        string[] tasks = procedureString.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 2; i < tasks.Length; i++)
        {
            procedure.AddTask(CreateTask(tasks[i]));
        }

        return procedure;
    }

	private static string GetFileFromDisk(string filename)
    { 
        try
        {
            string fileName = Path.Combine(Application.streamingAssetsPath, filename);
            byte[] bytes = File.ReadAllBytes(fileName);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        catch
        {
            Debug.LogWarning("Task DAC: Error loading file.");
            return string.Empty;
        }
    }
}
