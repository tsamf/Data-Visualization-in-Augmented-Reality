using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity : MonoBehaviour {

    private static Activity _instance;

    private List<EVAProcedure> procedures;
    private int currentProcedure = 0;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogWarning(gameObject.name + ": there can only be one activity per scene.");
            GameObject.Destroy(gameObject);
        }

        procedures = new List<EVAProcedure>();
    }

    private void Update()
    {
        if(procedures != null)
        {
            procedures[currentProcedure].GetCurrentTask().UpdateTime(Time.deltaTime);
        }
    }

    public void AddProcedure(EVAProcedure procedure)
    {
        procedures.Add(procedure);
    }

    public void SetProcedures(List<EVAProcedure> procedures)
    {
        this.procedures = procedures;
    }  
}
