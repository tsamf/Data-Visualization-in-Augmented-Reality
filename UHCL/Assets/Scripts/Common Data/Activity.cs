using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity {

    private static Activity _instance;
    private List<EVAProcedure> procedures;

    private int currentProcedure = 0;

    private Activity()
    {
        procedures = new List<EVAProcedure>();
    }

    public static Activity GetInstance()
    {
        if(_instance == null)
        {
            _instance = new Activity();
        }

        return _instance;
    }

    public void AddProcedure(EVAProcedure procedure)
    {
        procedures.Add(procedure);
    }

    public void SetProcedures(List<EVAProcedure> procedures)
    {
        this.procedures = procedures;
    }

    public EVAProcedure GetCurrentProcedure()
    {
        if (procedures.Count != 0)
        {
            return procedures[currentProcedure];
        }
        else
        {
            return null;
        }
    }

    public bool NextProcedure()
    {
        if (currentProcedure >= procedures.Count - 1)
        {
            return false;
        }
        else
        {
            currentProcedure++;
        }

        return true;
    }

    public int GetProcedureNumber()
    {
        return currentProcedure + 1;
    }
}
