using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUIView : MonoBehaviour {

    public Text previousTask;
    public Text currentTask;
    public Text nextTask;
    public Image taskImage;
    public Text cautionText;
    public GameObject taskPanel;
    public GameObject cautionPanel;
    public Image cautionImage;

    public Activity activity;

    // Use this for initialization
    void Start() {
        activity = Activity.GetInstance();
    }

    // Update is called once per frame
    void Update() {

        //If procedure is loaded populate task fields
        if (activity.GetCurrentProcedure() != null)
        {
            PopulatePerviousTask();
            PopulateCurrentTask();
            PopulateNextTask();

            PopulateImage();
        }
    }

    private void PopulateImage()
    {
        EVATask task = activity.GetCurrentProcedure().GetCurrentTask();

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
    
    private void PopulatePerviousTask()
    {
        EVATask task = activity.GetCurrentProcedure().GetPreviousTask();
        if (task != null)
        {
            previousTask.text = task.Text;
        }
        else
        {
            previousTask.text = "";
        }
    }

    private void PopulateCurrentTask()
    {
        EVATask task = activity.GetCurrentProcedure().GetCurrentTask();
        if (task != null)
        {
            currentTask.text = task.Text;
        }
        else
        {
            currentTask.text = "";
        }
    }

    private void PopulateNextTask()
    {
        EVATask task = activity.GetCurrentProcedure().GetNextTask();
        if(task != null)
        {
            nextTask.text = task.Text;
        }
        else
        {
            nextTask.text = "";
        }
    }
}
