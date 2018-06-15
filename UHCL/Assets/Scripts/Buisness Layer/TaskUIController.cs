using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskUIController : MonoBehaviour {


    Activity activity;

	// Use this for initialization
	void Start () {
        activity = Activity.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LoadActivity()
    {
        TaskDAC.LoadActivity();
    }

    public void RepeatTask()
    {
      
    }

    public void PreviousTask()
    {
        activity.GetCurrentProcedure().PreviousTask();
    }

    public void NextTask()
    {
        activity.GetCurrentProcedure().NextTask();
    }

}
