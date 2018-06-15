using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TestReader : MonoBehaviour {

    public TextMesh testText;
    // Use this for initialization
    void Start () {
        TaskDAC.LoadActivity();

        //StreamReader reader = new StreamReader(new FileStream(Path.Combine(Application.streamingAssetsPath , "test.csv"), FileMode.Open));

        //string fileData = "";
        //string fileName = Path.Combine(Application.streamingAssetsPath, "Canned Task.txt");
        //byte[] bytes = UnityEngine.Windows.File.ReadAllBytes(fileName);

        //fileData = System.Text.Encoding.ASCII.GetString(bytes);


        //fileData = fileData.Replace('\r', ' ');
        //string[] procedures = fileData.Split('$');

        //foreach(string procedure in procedures)
        //{
        //    string[] tasks = fileData.Split('\n');

        //    for(int i = 2; i < tasks.Length; i++)
        //    {
        //        string[] task = tasks[i].Split('\t');
        //    }
        //}




        // testText.text = Application.streamingAssetsPath;
        // reader.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
