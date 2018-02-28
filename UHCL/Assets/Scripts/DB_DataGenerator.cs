using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_DataGenerator : MonoBehaviour {

    //Seed
    System.Random random = new System.Random();
    List<Pipe> pipes = new List<Pipe>();

    public enum dataType { Canned, Dynamic, GenerateCanned };

    public dataType operation = dataType.Dynamic;

    //Used for both canned and dynamic
    public float dataUpdateSpeed = .25f;
    private float timesinceLastUpdate = 0.0f;

    //Generate canned data variables
    public bool includeHeader = false;
    public int cannedSize = 1;
    public string generateFileName = "test";

    //Canned data variables
    public string filename = "test";
    private int currentCannedIndex = 0;
    private List<string[]> cannedData = new List<string[]>();


    //Initialize list of pipes
    private void Start()
    {
        //Consumables
        pipes.Add(new Pipe("Oxygen", 0.0f, 100.0f, 100.0f, 25.0f, 0.0f, 0.0f, 100.0f, .1f, true));
        pipes.Add(new Pipe("Oxygen2", 0.0f, 100.0f, 100.0f, 25.0f, 0.0f, 0.0f, 100.0f, .1f, false));
        pipes.Add(new Pipe("Water", 0.0f, 32.0f, 32.0f, 25.0f, 0.0f, 0.0f, 32.0f, .01f, true));
        pipes.Add(new Pipe("Battery", 0.0f, 100.0f, 100.0f, 25.0f, 0.0f, 0.0f, 100.0f, .01f, true));

        //Biometric Data
        pipes.Add(new Pipe("Body Temperature", 91.0f, 110.0f, 110.0f, 10.0f, 91.0f, 10.0f, 98.7f, 0.01f, true));
        pipes.Add(new Pipe("Heart Rate", 62.0f, 70.0f, 70.0f, 10.0f, 62.0f, 10.0f, 65.0f, .01f, true));

        //Suit Data
        pipes.Add(new Pipe("Suit Pressure", 3.0f, 4.9f, 4.9f, 10.0f, 0.0f, 0.0f, 4.9f, .01f, true));

        //Example of accesing a pipe in the list by its name and toggeling inactive
        //pipes.Where(pipe => pipe.PipeName == "Oxygen2").First().ToggleActive();

        //Generate a canned file if selected
        if(operation == dataType.GenerateCanned)
        {
            GenerateCannedDataSet(cannedSize, generateFileName, includeHeader);
        }
        else if( operation == dataType.Canned)
        {
            cannedData = RetrieveCannedDataSet(filename, true);
        }
        
    }

    //Populate values 
    public void Update()
    {
        timesinceLastUpdate += Time.deltaTime;

        if (timesinceLastUpdate > dataUpdateSpeed)
        {
            Debug.Log(timesinceLastUpdate);
            timesinceLastUpdate -= dataUpdateSpeed;
            switch (operation)
            {
                case dataType.Canned:
                    {
                        //Advance index
                        currentCannedIndex++;

                        //If index out of range start over
                        if(currentCannedIndex >= cannedData.Count)
                        {
                            currentCannedIndex = 0;
                        }
                        
                        string[] row = cannedData[currentCannedIndex];
                        Debug.Log(row[0].ToString() + row[1].ToString()+row[6].ToString());
                        break;
                    }
                case dataType.Dynamic:
                    {
                        break;
                    }
            }
        }
    }

    //Next Step increment for all pipes returns a string of the values after
    public string[] GetNextStep()
    {
        List<string> result = new List<string>();

        foreach (Pipe p in pipes)
        {
            p.AdvancePipe(1, random);
            result.Add(p.Current.ToString());
        }
        
        return result.ToArray();
    }

    //Generat a file with canned values
    public void GenerateCannedDataSet(int size, string FileName, bool includeHeader)
    {
        string path = Application.streamingAssetsPath + "/" + FileName + ".csv";
        List<string[]> fileContents = new List<string[]>();

        //Write header if it needs to be included
        if(includeHeader)
        {
            fileContents.Add(GenerateHeader());
        }

        //Generate Body of file
        for(int i = 0; i < size; i++)
        {
            fileContents.Add(GetNextStep());
        }

        //Write file
        DB_CSVFileParser.WriteFile(path, fileContents);
    }

    public List<string[]> RetrieveCannedDataSet(string FileName,bool removeHeader)
    {
        string path = Application.streamingAssetsPath + "/" + FileName + ".csv";
        return DB_CSVFileParser.readfile(path, removeHeader);
    }

    private string[] GenerateHeader()
    {
        List<string> result = new List<string>();

        foreach (Pipe p in pipes)
        {
            result.Add(p.PipeName);
        }

        return result.ToArray();
    }
}

class Pipe
{
    string pipeName;
    float min;
    float max;
    float threshold1;
    float threshold1Percentage;
    float threshold2;
    float threshold2Percentage;
    float initial;
    float current;
    float increment;
    bool isActive;

    public float Current { get { return current; } }
    public string PipeName { get { return pipeName; } }

    public Pipe(string pipeName, float min, float max, float threshold1, float threshold1Percentage, float threshold2, float threshold2Percentage, float initial, float increment, bool isActive)
    {
        this.pipeName = pipeName;
        this.min = min;
        this.max = max;
        this.threshold1 = threshold1;
        this.threshold2 = threshold2;
        this.threshold1Percentage = threshold1Percentage;
        this.threshold2Percentage = threshold2Percentage;
        this.initial = initial;
        this.increment = increment;
        this.current = initial;
        this.isActive = isActive;
    }

    public void AdvancePipe(int steps, System.Random random)
    {
        //If the pipe has been deactivated return with out advancing
        if (!isActive)
        {
            return;
        }

        //Move steps by amount passed in 
        for (int lcv = steps; lcv > 0; lcv--)
        {
            //Get random number between 0 and 100
            int nextRandom = random.Next(0, 101);

            //If less than first threshold subtract by increment amount
            if (nextRandom <= threshold1Percentage)
            {
                if (current - increment > min)
                {
                    current -= increment;
                }
            }
            //Stay the same if between both thresholds
            else if (nextRandom <= 100.0f - threshold2Percentage)
            {

            }
            //If greater than second threshold add by increment amount
            else
            {
                if (current + increment < max)
                {
                    current += increment;
                }
            }
        }
    }

    public void ToggleActive()
    {
        isActive = !isActive;
    }
}