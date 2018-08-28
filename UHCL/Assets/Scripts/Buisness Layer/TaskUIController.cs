using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIController : MonoBehaviour {

    public TextToSpeech textToSpeech;

    Activity activity;
    TaskUIView taskUIView;

    //TODO where do these flags go
    enum ActivityState {  programStarted, acitvityLoaded, inProcedure }


	// Use this for initialization
	void Start () {
        activity = Activity.GetInstance();
        taskUIView = GameObject.FindObjectOfType<TaskUIView>();
        LoadActivity();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadActivity()
    {
        TaskDAC.LoadActivity();
        taskUIView.DisplayProcedures(activity);
        textToSpeech.StartSpeaking("Activity loaded, say start procedure to continue.");
    }

    public void StartPocedure()
    {
        taskUIView.DisplayTasks(activity.GetCurrentProcedure());
        textToSpeech.StartSpeaking(activity.GetCurrentProcedure().GetCurrentTask().Text);
    }

    public void NextProcedure()
    {
        if(activity.GetCurrentProcedure().IsEndOfProcedure())
        {
            if(activity.NextProcedure())
            {
                taskUIView.DisplayTasks(activity.GetCurrentProcedure());
                textToSpeech.StartSpeaking(activity.GetCurrentProcedure().GetCurrentTask().Text);
            }
            else
            {
                textToSpeech.StartSpeaking("Activity complete.");
                taskUIView.DisplayEndOfActivity();
            }
        }
    }

    public void RepeatTask()
    {
        textToSpeech.StartSpeaking(activity.GetCurrentProcedure().GetCurrentTask().Text);
    }

    public void PreviousTask()
    {
        activity.GetCurrentProcedure().PreviousTask();
        taskUIView.DisplayTasks(activity.GetCurrentProcedure());
        textToSpeech.StartSpeaking(activity.GetCurrentProcedure().GetCurrentTask().Text);
    }

    public void NextTask()
    {
        if(activity.GetCurrentProcedure().NextTask())
        {
            taskUIView.DisplayTasks(activity.GetCurrentProcedure());
            textToSpeech.StartSpeaking(activity.GetCurrentProcedure().GetCurrentTask().Text);
        }
        else
        {
            taskUIView.DisplayEndOfProcedure();
            textToSpeech.StartSpeaking("Procedure complete, say next procedure to continue.");
        }
    }
}
