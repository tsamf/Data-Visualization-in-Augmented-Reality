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

    public bool IsEndOfProcedure()
    {
        if(currentTask == tasks.Count -1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int GetTaskCount()
    {
        return tasks.Count;
    }

    public bool NextTask()
    {
        if (currentTask >= GetTaskCount() - 1)
        {
            return false;
        }
        else
        {
            currentTask++;
        }

        return true;
    }

    public bool PreviousTask()
    {
        if (currentTask <= 0)
        {
            return false;
        }
        else
        {
            currentTask--;
        }

        return true;
    }
    

    public EVATask GetPreviousTask()
    {
        if (currentTask <= 0)
        {
            return null;
        }
        else
        {
            return tasks[currentTask - 1];
        }
    }

    public EVATask GetCurrentTask()
    {
        return tasks[currentTask];
    }

    public EVATask GetNextTask()
    {
        if(currentTask >= tasks.Count-1)
        {
            return null;
        }
        else
        {
            return tasks[currentTask + 1];
        }
    }
}
