using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class TestReader : MonoBehaviour {

    public TextMesh testText;
    // Use this for initialization
    void Start () {
        //StreamReader reader = new StreamReader(new FileStream(Path.Combine(Application.streamingAssetsPath , "test.csv"), FileMode.Open));

        string fileData = "";
        string fileName = Path.Combine(Application.streamingAssetsPath, "test.csv");
        byte[] bytes = UnityEngine.Windows.File.ReadAllBytes(fileName);

        fileData = System.Text.Encoding.ASCII.GetString(bytes);

        fileData.Replace('\r', ' ');
        string[] lines = fileData.Split('\n');

        Debug.Log(lines[0]);

        testText.text = lines[0];

        // testText.text = Application.streamingAssetsPath;
        // reader.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
