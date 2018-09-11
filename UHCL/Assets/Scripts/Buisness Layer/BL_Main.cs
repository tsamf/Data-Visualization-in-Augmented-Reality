using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Main : MonoBehaviour
{
    [Tooltip("Tick speed in milliseconds")]
    public float tickSpeed = 0.05f;
    private float timeSinceLastTick = 0.0f;


    public BL_Alarming bl_alarming;
    public BL_Scalling bl_scaling;
    public BL_Tasks bl_task;
    public WriteFile writeFile;

    public BL_Alarming Bl_alarming { get { return bl_alarming; } }

    private void Awake()
    {
        bl_scaling = new BL_Scalling();
        bl_alarming = new BL_Alarming(writeFile);
        bl_task = new BL_Tasks();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTick += Time.deltaTime;

        if(timeSinceLastTick > tickSpeed)
        {

            bl_alarming.BLAlarmingFunction();
            timeSinceLastTick -= tickSpeed;
        }
    }
}

