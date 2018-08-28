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

    private void Awake()
    {
        cautionPanel.gameObject.SetActive(false);
        cautionText.gameObject.SetActive(false);
    }

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
        taskPanel.gameObject.SetActive(true);

        taskHeaderText.text = "";
        previousTask.text = "";
        currentTask.text = "Activity loaded, say start procedure to continue.";
        nextTask.text = "";
    }

    public void DisplayTasks(EVAProcedure procedure)
    {
        //Populate Task Window
        taskHeaderText.text = "Tasks";
        previousTask.text = procedure.GetPreviousTask() != null ? procedure.GetPreviousTask().Text : "" ;
        currentTask.text = procedure.GetCurrentTask() != null ? procedure.GetCurrentTask().Text : "";
        nextTask.text = procedure.GetNextTask() != null ? procedure.GetNextTask().Text : "";

        //Update cautions and warnings 
        if (procedure.GetCurrentTask().Warning != "")
        {
            cautionText.gameObject.SetActive(true);
            cautionPanel.gameObject.SetActive(true);
            cautionPanel.GetComponent<Image>().color = new Color32(208, 46, 40, 214);
            cautionText.text = procedure.GetCurrentTask().Warning;
        }
         else if (procedure.GetCurrentTask().Caution != "")
        {
            cautionText.gameObject.SetActive(true);
            cautionPanel.gameObject.SetActive(true);
            cautionPanel.GetComponent<Image>().color = new Color32(255, 255, 114, 249);
            cautionText.text = procedure.GetCurrentTask().Caution;
        }
        else
        {
            cautionPanel.gameObject.SetActive(false);
        }

        //PopulateImage
        PopulateImage(procedure.GetCurrentTask());

        //Update Holograms
        UpdateHolograms(procedure.GetCurrentTask());
    }

    public void UpdateHolograms(EVATask task)
    {
        //find all the holograms in the scene
        GameObject[] holograms =  GameObject.FindGameObjectsWithTag("Hologram");

        //turn all holograms off
        for(int i = 0; i < holograms.Length; i++)
        {
            holograms[i].gameObject.GetComponent<Renderer>().enabled = false;
        }

        //turn on specific holograms
        if(task.Holograms != "")
        {
            GameObject hologram = GameObject.Find(task.Holograms);
            hologram.GetComponent<Renderer>().enabled = true;
        }
    }

    public void DisplayEndOfProcedure()
    {
        taskHeaderText.text = "Tasks";
        previousTask.text = "";
        currentTask.text = "Procedure complete, say next procedure to continue.";
        nextTask.text = "";
    }
    public void DisplayEndOfActivity()
    {
        taskHeaderText.text = "";
        previousTask.text = "";
        currentTask.text = "Activity Complete!";
        nextTask.text = "";
    }
}
