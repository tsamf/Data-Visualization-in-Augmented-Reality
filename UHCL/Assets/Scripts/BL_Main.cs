using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Main : MonoBehaviour
{
    [Tooltip("Tick speed in milliseconds")]
    public float tickSpeed = 0.05f;
    private float timeSinceLastTick = 0.0f;

    private CommonData commonData = CommonData.GetInstance();

    public double SuitPressure;
    public double SuitPressureDB;
    public bool SuitPressureHiStatus;
    public bool SuitPressureHiAlarm;

    //public double SuitPressureMax = 20;
   //public double SuitPressureMin = 0;

    public double SuitPressHiHiSP = 18;
    public double SuitPressHiHiDB = 17.8;

    public double SuitPressHiSP = 16;
    public double SuitPressHiDB = 15.8;

    public double SuitPressLoSP = 4;
    public double SuitPressLoDB = 4.2;

    public double SuitPressLoLoSP = 3;
    public double SuitPressLoLoDB = 3.2;

    //Scaling and limiting function
    private double BLScalingLimiting(
        double SuitPressureDB,
        double Suitpressure
        )
    {
        // This function is about to make sure that SuitPressure is between SuitPressureMax and SuitPressureMin
        SuitPressure = SuitPressureDB;
        if (SuitPressureDB < commonData.SuitPressureMin)
            SuitPressure = commonData.SuitPressureMin;
        if (SuitPressureDB > commonData.SuitPressureMin)
            SuitPressure = commonData.SuitPressureMin;
        return SuitPressure;
    }

    // Alarming function
    private void BLAlarming(
        bool SuitPressureHiStatus,
        bool SuitPressureHiHiStatus,
        bool SuitPressureLoStatus,
        bool SuitPressureLoLoStatus,
        double SuitPressure
        )
    {

        bool SuitPressureHiHiEn = false;
        bool SuitPressureHiEn = false;
        bool SuitPressureLoLoEn = false ;
        bool SuitPressureLoEn = false;


        if (SuitPressure >= commonData.SuitPressureMin && SuitPressure <= commonData.SuitPressureMax)
        {

            // If SuitPressureHiHi enables, it will check how much suit pressure is and turn the alarm on or off, depends on suit pressure value
            if (SuitPressureHiHiEn == true)
            {
                if (SuitPressure >= SuitPressHiHiDB && SuitPressure <= SuitPressHiHiSP)
                {
                    SuitPressureHiHiStatus = true;
                }
            }

            if (SuitPressureHiEn == true)
            {
                if (SuitPressure >= SuitPressHiDB && SuitPressure <= SuitPressHiSP)
                {
                    SuitPressureHiStatus = true;
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= SuitPressLoSP && SuitPressure <= SuitPressLoDB)
                {
                    SuitPressureLoStatus = true;
                }
            }

            if (SuitPressureLoLoEn == true)
            {
                if (SuitPressure >= SuitPressLoLoSP && SuitPressure <= SuitPressLoLoDB)
                {
                    SuitPressureLoLoStatus = true;
                }
            }

        }
        else
        {
            print("Something wrong here!");
        }
    }

    // Reseting function for Suit Pressure high only
    private bool BLResetingAcknow(
        bool SuitPressureHiStatus,
        bool SuitPressureHiHiStatus,
        bool SuitPressureLoStatus,
        bool SuitPressureLoLoStatus,
        double SuitPressure,
        bool AlarmAck,
        bool SuitPressureHiAlarm
    )
    {
        // If SuitPressureHiStatus and AlarmAck are both equal TRUE, SuitPressureHiAlarm returns true
        if (SuitPressureHiStatus == true && AlarmAck == true)
        {
            SuitPressureHiAlarm = true;
        }
        else
            SuitPressureHiAlarm = false;

        return SuitPressureHiAlarm;
    }

    // Use this for initialization
    void Start()
    {
       commonData.SuitPressureMax = 20;
       commonData.SuitPressureMin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastTick += Time.deltaTime;

        if(timeSinceLastTick > tickSpeed)
        {

            Debug.Log("Its been 50ms");

            timeSinceLastTick -= tickSpeed;
        }
    }
}

