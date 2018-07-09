using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUIView : MonoBehaviour {

    public Text taskHeaderText;
    public Text previousTask;
    public Text currentTask;
    public Text nextTask;
    public Image taskImage;
    public Text cautionText;
    public GameObject taskPanel;
    public GameObject cautionPanel;
    public Image cautionImage;

    private void PopulateImage(EVATask task)
    {
        if (task != null && task.Images != "")
        {
            taskImage.gameObject.SetActive(true);
            taskImage.sprite = Resources.Load<Sprite>(task.Images);
        }
        else
        {
            taskImage.gameObject.SetActive(false);
        }
    }
    
    public void DisplayProcedures(Activity activity)
    {
        taskHeaderText.text = "Procedures";
        previousTask.text = "procedure1";
        currentTask.text = "procedure2";
        nextTask.text = "procedure3";
    }

    public void DisplayTasks(EVAProcedure procedure)
    {
        //Populate Task Window
        taskHeaderText.text = "Tasks";
        previousTask.text = procedure.GetPreviousTask() != null ? procedure.GetPreviousTask().Text : "" ;
        currentTask.text = procedure.GetCurrentTask() != null ? procedure.GetCurrentTask().Text : "";
        nextTask.text = procedure.GetNextTask() != null ? procedure.GetNextTask().Text : "";

        //PopulateImage
        PopulateImage(procedure.GetCurrentTask());
    }
}
