using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_ResetingAcknow : MonoBehaviour {

    private CommonData commonData = CommonData.GetInstance();

    // Reseting function for High Suit Pressure only
    public bool BLResetingAcknow(
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
        //Setting up initial value

        commonData.SuitPressHiHiSP = 18;
        commonData.SuitPressHiHiDB = 17.8;

        commonData.SuitPressHiSP = 16;
        commonData.SuitPressHiDB = 15.8;

        commonData.SuitPressLoSP = 4;
        commonData.SuitPressLoDB = 4.2;

        commonData.SuitPressLoLoSP = 3;
        commonData.SuitPressLoLoDB = 3.2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
