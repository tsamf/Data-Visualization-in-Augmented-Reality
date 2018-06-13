using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVATask
{
    private float time = 0;
    private float estimatedTaskTime;

    //TODO make all of these private
    public int stepNumber;
    public string text = "";
    public string caution = "";
    public string warning = "";
    public string holograms = "";
    public string images = "";

    //TODO add a constructor

    public float GetTime()
    {
        return time;
    }

    public float UpdateTime(float deltaTime)
    {
        time += deltaTime;
        return time;
    }
}
