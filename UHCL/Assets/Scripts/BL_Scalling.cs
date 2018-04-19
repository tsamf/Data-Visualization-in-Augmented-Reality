using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Scalling {

    public BL_Scalling()
    {
        commonData.SuitPressureMax = 20;
        commonData.SuitPressureMin = 0;

        commonData.SuitPressHiHiSP = 18.0f;
        commonData.SuitPressHiHiDB = 17.8f;

        commonData.SuitPressHiSP = 16.0f;
        commonData.SuitPressHiDB = 15.8f;

        commonData.SuitPressLoSP = 4.0f;
        commonData.SuitPressLoDB = 4.2f;

        commonData.SuitPressLoLoSP = 3.0f;
        commonData.SuitPressLoLoDB = 3.2f;
}

    private CommonData commonData = CommonData.GetInstance();


    //Sending out actual oxygen2
    public float actualOxygen2 ()
    {
        return commonData.OxygenTwoValue;
    }

    //Sending out actual suitpressure value
    public float actualSuitPressure ()
    {
        float num = commonData.SuitPressureValue / (commonData.SuitPressureMax - commonData.SuitPressureMin);
        return (num*4)/10 + 3.9f;
    }

    //Scaling from number to percentage
    public float ScalingFunction(
        )
    {
        commonData.SuitPressureValue = BLScalingLimiting(commonData.SuitPressureValue);
        float SuitPressure_normalize = (commonData.SuitPressureValue*100) / (commonData.SuitPressureMax - commonData.SuitPressureMin);
        return SuitPressure_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimiting(
        float DB_SuitPressure
        )
    {
        // This function is about to make sure that SuitPressure is between SuitPressureMax and SuitPressureMin
        if (DB_SuitPressure < commonData.SuitPressureMin)
            DB_SuitPressure = commonData.SuitPressureMin;
        if (DB_SuitPressure > commonData.SuitPressureMax)
            DB_SuitPressure = commonData.SuitPressureMax;
        return DB_SuitPressure;
    }

   
}
