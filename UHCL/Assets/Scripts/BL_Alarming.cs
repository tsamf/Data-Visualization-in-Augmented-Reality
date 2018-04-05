using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Alarming : MonoBehaviour {

    private CommonData commonData = CommonData.GetInstance();

    // Alarming function
    public void BLAlarming(
        bool SuitPressureHiStatus,
        bool SuitPressureHiHiStatus,
        bool SuitPressureLoStatus,
        bool SuitPressureLoLoStatus,
        double SuitPressure
        )
    {

        bool SuitPressureHiHiEn = false;
        bool SuitPressureHiEn = false;
        bool SuitPressureLoLoEn = false;
        bool SuitPressureLoEn = false;


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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
