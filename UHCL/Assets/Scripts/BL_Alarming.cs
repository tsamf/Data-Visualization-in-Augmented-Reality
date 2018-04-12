using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Alarming {

    private CommonData commonData = CommonData.GetInstance();

    public bool SuitPressureHiStatus;
    public bool SuitPressureHiHiStatus;
    public bool SuitPressureLoStatus;
    public bool SuitPressureLoLoStatus;
    public double SuitPressure;
    public string alarmText;

    public BL_Alarming()
    {
        SuitPressure = commonData.SuitPressureValue;
    } 


    // Alarming function
    public void BLAlarming()
    {

        bool SuitPressureHiHiEn = false;
        bool SuitPressureHiEn = false;
        bool SuitPressureLoLoEn = false;
        bool SuitPressureLoEn = true;


        if (SuitPressure >= commonData.SuitPressureMin && SuitPressure <= commonData.SuitPressureMax)
        {

            // If SuitPressureHiHi enables, it will check how much suit pressure is and turn the alarm on or off, depends on suit pressure value
            if (SuitPressureHiHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiHiDB && SuitPressure <= commonData.SuitPressHiHiSP)
                {
                    SuitPressureHiHiStatus = true;
                }
            }

            if (SuitPressureHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
                {
                    SuitPressureHiStatus = true;
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
                {
                    SuitPressureLoStatus = true;
                    alarmText = "Low SuitPressure";
                }
            }

            if (SuitPressureLoLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
                {
                    SuitPressureLoLoStatus = true;
                }
            }

        }
        else
        {
            Debug.Log("Something wrong here!");
        }
    }

}
