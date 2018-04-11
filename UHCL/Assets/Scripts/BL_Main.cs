using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Main : MonoBehaviour
{
    [Tooltip("Tick speed in milliseconds")]
    public float tickSpeed = 0.05f;
    private float timeSinceLastTick = 0.0f;

    private BL_Scalling bl_scalling;

    // Use this for initialization
    void Start()
    {
        bl_scalling = new BL_Scalling();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTick += Time.deltaTime;

        if(timeSinceLastTick > tickSpeed)
        {

      

            timeSinceLastTick -= tickSpeed;
        }
    }
}

