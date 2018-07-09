using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIController : MonoBehaviour {


    Activity activity;
    TaskUIView taskUIView;

    //TODO where do these flags go
    enum ActivityState {  programStarted, acitvityLoaded, inProcedure }


	// Use this for initialization
	void Start () {
        activity = Activity.GetInstance();
        taskUIView = GameObject.FindObjectOfType<TaskUIView>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadActivity()
    {
        TaskDAC.LoadActivity();
        taskUIView.DisplayProcedures(activity);
    }

    public void StartPocedure()
    {
        taskUIView.DisplayTasks(activity.GetCurrentProcedure());
    }

    public void RepeatTask()
    {
      
    }

    public void PreviousTask()
    {
        activity.GetCurrentProcedure().PreviousTask();
        taskUIView.DisplayTasks(activity.GetCurrentProcedure());
    }

    public void NextTask()
    {
        activity.GetCurrentProcedure().NextTask();
        taskUIView.DisplayTasks(activity.GetCurrentProcedure());
    }
}
