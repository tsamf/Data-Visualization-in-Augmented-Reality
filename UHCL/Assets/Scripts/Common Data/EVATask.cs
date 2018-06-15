using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVATask
{
    private int stepNumber;
    private float totalTime = 0;
    private float estimatedTaskTime;
    private string text = "";
    private string caution = "";
    private string warning = "";
    private string holograms = "";
    private string images = "";


    public int StepNumer { get { return stepNumber; }}
    public float TotalTime { get { return TotalTime; }}
    public float EstimatedTaskTime { get { return estimatedTaskTime; } }
    public string Text { get { return text; } }
    public string Caution { get { return caution; } }
    public string Warning { get { return warning; } }
    public string Holograms { get { return holograms; } }
    public string Images { get { return images; } }
    


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

    public float UpdateTime(float deltaTime)
    {
        totalTime += deltaTime;
        return totalTime;
    }
}
