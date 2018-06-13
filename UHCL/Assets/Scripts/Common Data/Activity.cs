using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour {

    private List<EVAProcedure> procedures;
    private int currentProcedure = 0;

    private void Update()
    {
        if(procedures != null)
        {
            procedures[currentProcedure].GetCurrentTask().UpdateTime(Time.deltaTime);
        }
    }
}
