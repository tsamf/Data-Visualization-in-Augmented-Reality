using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TaskDAC {

    public static void LoadActivity()
    {
        string file = GetFileFromDisk("Canned Task.txt");
        PopulateActivity(file);
    }

    private static void PopulateActivity(string file)
    {
        Activity activity = GameObject.FindObjectOfType<Activity>();

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
            Convert.ToInt32(taskStrings[0]),
            float.Parse(taskStrings[1]),
            taskStrings[2],
            taskStrings[3],
            taskStrings[4],
            taskStrings[5],
            taskStrings[6]);
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
            byte[] bytes = UnityEngine.Windows.File.ReadAllBytes(fileName);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }
        catch
        {
            Debug.LogWarning("Task DAC: Error loading file.");
            return string.Empty;
        }
    }
}
