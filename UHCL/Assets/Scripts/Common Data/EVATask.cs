using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVATask
{
    private float time = 0;
    private float estimatedTaskTime;

    //Make these private
    public int stepNumber;
    public string text = "";
    public string caution = "";
    public string warning = "";
    public string holograms = "";
    public string images = "";

    //TODO estimated time should be required and needs to be converted from seconds
    public EVATask(int stepNumber, float estimatedTaskTime = 0, string text = "",string caution = "", string warning = "", string holograms = "", string images = "")
    {
        this.stepNumber = stepNumber;
        this.text = text;
        this.caution = caution;
        this.warning = warning;
        this.holograms = holograms;
        this.images = images;
        this.estimatedTaskTime = estimatedTaskTime;
    }

    //TODO get rid of this once the objects are being created correctly
    public EVATask()
    {

    }

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
