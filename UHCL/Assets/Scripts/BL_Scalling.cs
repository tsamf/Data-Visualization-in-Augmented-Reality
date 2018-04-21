using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Scalling {

    public BL_Scalling()
    {

        //Suit Pressure
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

        //Heart Rate
        commonData.HeartRateMax = 80.0f;
        commonData.HeartRateMin = 55.0f;

        commonData.HeartRateHiHiSP = 80.0f;
        commonData.HeartRateHiHiDB = 76.0f;

        commonData.HeartRateHiSP = 71.0f;
        commonData.HeartRateHiDB = 75.0f;

        commonData.HeartRateLoSP = 61.0f;
        commonData.HeartRateLoDB = 58.0f;

        commonData.HeartRateLoLoSP = 57.0f;
        commonData.HeartRateLoLoDB = 55.0f;

        //Body temprature
        commonData.BodyTemperatureMax = 110.0f;
        commonData.BodyTemperatureMin = 90.0f;

        commonData.BodyTemperatureHiHiSP = 110.0f;
        commonData.BodyTemperatureHiHiDB = 108.0f;

        commonData.BodyTemperatureHiSP = 107.0f;
        commonData.BodyTemperatureHiDB = 104.0f;

        commonData.BodyTemperatureLoSP = 94.0f;
        commonData.BodyTemperatureLoDB = 92.0f;

        commonData.BodyTemperatureLoLoSP = 92.0f;
        commonData.BodyTemperatureLoLoDB = 90.0f;

    }

    private CommonData commonData = CommonData.GetInstance();


    //Sending out actual oxygen2
    public float actualOxygen2 ()
    {
        return commonData.OxygenTwoValue;
    }


    //-------------------------------Suit Pressure--------------------------

    //Sending out actual suitpressure value
    public float actualSuitPressure ()
    {
        float num = commonData.SuitPressureValue / (commonData.SuitPressureMax - commonData.SuitPressureMin);
        return (num*12)/10 + 3.9f;
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

    //-------------------------------Heart Rate--------------------------

    //Sending out actual Heart Rate
    public float actualHearRate()
    {
        return commonData.HeartRateValue;
    }

    //Sending out scalling value
    public float scallingHeartRate()
    {
        commonData.HeartRateValue = BLScalingLimitingHeartRate(commonData.HeartRateValue);
        float heartrate_normalize = (commonData.HeartRateValue * 100) / (commonData.HeartRateMax - commonData.HeartRateMin);
        return heartrate_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingHeartRate(
        float DB_HeartRate
        )
    {
        // This function is about to make sure that SuitPressure is between SuitPressureMax and SuitPressureMin
        if (DB_HeartRate < commonData.HeartRateMin)
            DB_HeartRate = commonData.HeartRateMin;
        if (DB_HeartRate > commonData.HeartRateMax)
            DB_HeartRate = commonData.HeartRateMax;
        return DB_HeartRate;
    }

    //-------------------------------Body Temperature--------------------------

    //Sending out actual Body Temperature
    public float actualBodyTemperature()
    {
        return commonData.BodyTemperatureValue;
    }

    //Sending out scalling value
    public float scallingBodyTemperature()
    {
        commonData.BodyTemperatureValue = BLScalingLimitingBodyTemperature(commonData.BodyTemperatureValue);
        float bodytemperature_normalize = (commonData.BodyTemperatureValue * 100) / (commonData.BodyTemperatureMax - commonData.BodyTemperatureMin);
        return bodytemperature_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingBodyTemperature(
        float DB_BodyTemperature
        )
    {
        // This function is about to make sure that body temperature is between max and min
        if (DB_BodyTemperature < commonData.BodyTemperatureMin)
            DB_BodyTemperature = commonData.BodyTemperatureMin;
        if (DB_BodyTemperature > commonData.BodyTemperatureMax)
            DB_BodyTemperature = commonData.BodyTemperatureMax;
        return DB_BodyTemperature;
    }

}
