using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EVAProcedure
{
    //TODO make private
    public List<EVATask> tasks;

    private int currentTask = 0;

    public EVAProcedure()
    {
        tasks = new List<EVATask>();
    }

    public void AddTask(EVATask task)
    {
        tasks.Add(task);
    }

    public EVATask GetCurrentTask()
    {
        return tasks[currentTask];
    }
}
