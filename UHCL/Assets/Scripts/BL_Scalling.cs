using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Scalling : MonoBehaviour {

    private CommonData commonData = CommonData.GetInstance();

    //Scaling from number to percentage
    public double ScalingFunction(
        double SuitPressure
        )
    {
        SuitPressure = (SuitPressure * 100) / (commonData.SuitPressureMax - commonData.SuitPressureMin);
        return SuitPressure;
    }

    //Scaling and limiting function
    public double BLScalingLimiting(
        double DB_SuitPressure,
        double SuitPressure
        )
    {
        // This function is about to make sure that SuitPressure is between SuitPressureMax and SuitPressureMin
        SuitPressure = DB_SuitPressure;
        if (DB_SuitPressure < commonData.SuitPressureMin)
            SuitPressure = commonData.SuitPressureMin;
        if (DB_SuitPressure > commonData.SuitPressureMin)
            SuitPressure = commonData.SuitPressureMin;
        return ScalingFunction(SuitPressure);
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

    }
}
