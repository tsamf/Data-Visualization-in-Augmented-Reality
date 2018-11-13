using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateSettings : MonoBehaviour {


    public Text dropDownText;
    public Toggle uiToggle;
    FlagStore store = FlagStore.GetInstance();
    public TaskUIController taskController;

    public GameObject pie;
    public GameObject barChart;
    public GameObject taskInterface;
    public WriteFile writeFile;
    public Tutorial tutorial;

	public void UpdateAndChangeScenes()
    {
        store.userID = int.Parse(dropDownText.text);
        store.pieUI = uiToggle.isOn;
        store.currentState = FlagStore.GameState.tutorial;
        gameObject.SetActive(false);
        
        if(store.pieUI == true)
        {
            pie.SetActive(true);
            barChart.SetActive(false);
        }
        else
        {
            pie.SetActive(false);
            barChart.SetActive(true);
        }

        taskInterface.SetActive(true);

        tutorial.CreateTutorial();

        taskController.StartPocedure();

        writeFile.CreateFile();
    }
}
