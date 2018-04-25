using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Scalling {

    public BL_Scalling()
    {

        //Suit Pressure
        commonData.SuitPressureMax = 5.2f;
        commonData.SuitPressureMin = 3.9f;

        commonData.SuitPressHiHiSP = 5.2f;
        commonData.SuitPressHiHiDB = 5.0f;

        commonData.SuitPressHiSP = 4.99f;
        commonData.SuitPressHiDB = 4.8f;

        commonData.SuitPressLoSP = 4.1f;
        commonData.SuitPressLoDB = 4.3f;

        commonData.SuitPressLoLoSP = 3.9f;
        commonData.SuitPressLoLoDB = 4.09f;

        //Heart Rate
        commonData.HeartRateMax = 80.0f;
        commonData.HeartRateMin = 55.0f;

        commonData.HeartRateHiHiSP = 80.0f;
        commonData.HeartRateHiHiDB = 75.0f;

        commonData.HeartRateHiSP = 74.99f;
        commonData.HeartRateHiDB = 70.0f; 

        commonData.HeartRateLoSP = 60.0f;
        commonData.HeartRateLoDB = 64.99f; 

        commonData.HeartRateLoLoSP = 55.0f;
        commonData.HeartRateLoLoDB =  59.99f;

        //Body temprature
        commonData.BodyTemperatureMax = 110.0f;
        commonData.BodyTemperatureMin = 90.0f;

        commonData.BodyTemperatureHiHiSP = 110.0f;
        commonData.BodyTemperatureHiHiDB = 107.0f;

        commonData.BodyTemperatureHiSP = 106.99f;
        commonData.BodyTemperatureHiDB = 104.0f;

        commonData.BodyTemperatureLoSP = 93.0f;
        commonData.BodyTemperatureLoDB = 96.0f; 

        commonData.BodyTemperatureLoLoSP = 90.0f;
        commonData.BodyTemperatureLoLoDB = 92.99f; 


        //Primary Oxygen
        commonData.PrimaryOxygenMax = 850.0f;
        commonData.PrimaryOxygenMin = 0.85f;

        commonData.PrimaryOxygenLoDB = 255.0f;

        //Secondary Oxygen
        commonData.SecondaryOxygenMax = 3600.0f;
        commonData.SecondaryOxygenMin = 0.036f;

        commonData.SecondaryOxygenHiDB = 3550.0f;

        commonData.SecondaryOxygenLoDB = 1440.0f;

        commonData.SecondaryOxygenLoLoDB = 900.0f;

        //Water
        commonData.WaterMax = 7.0f;
        commonData.WaterMin = 0.07f;

        commonData.WaterLoDB = 2.1f;

        commonData.WaterLoLoDB = 1.4f;

        //Battery
        commonData.BatteryMax = 100.0f;
        commonData.BatteryMin = 1.0f;

        commonData.BatteryLoDB = 30.0f;

        commonData.BatteryLoLoDB = 15.0f;

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
        return commonData.SuitPressureValue;
    }

    //Scaling from number to percentage
    public float ScalingFunction(
        )
    {
        commonData.SuitPressureValue = BLScalingLimiting(commonData.SuitPressureValue);
        float SuitPressure_normalize = ((commonData.SuitPressureValue-commonData.SuitPressureMin)*100) / (commonData.SuitPressureMax - commonData.SuitPressureMin);
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
        float heartrate_normalize = ((commonData.HeartRateValue -commonData.HeartRateMin)* 100) / (commonData.HeartRateMax - commonData.HeartRateMin);
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
        float bodytemperature_normalize = ((commonData.BodyTemperatureValue - commonData.BodyTemperatureMin) * 100) / (commonData.BodyTemperatureMax - commonData.BodyTemperatureMin);
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


    //-------------------------------Primary Oxygen--------------------------

    //Sending out actual Primary Oxygen
    public float actualPrimaryOxygen()
    {
        return commonData.OxygenOneValue;
    }

    //Sending out scalling value
    public float scallingPrimaryOxygen()
    {
        commonData.OxygenOneValue = BLScalingLimitingPrimaryOxygen(commonData.OxygenOneValue);
        float primaryoxygen_normalize = ((commonData.OxygenOneValue-commonData.PrimaryOxygenMin) * 100) / (commonData.PrimaryOxygenMax - commonData.PrimaryOxygenMin);
        return primaryoxygen_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingPrimaryOxygen(
        float DB_PrimaryOxygen
        )
    {
        // This function is about to make sure that primary oxygen is between max and min
        if (DB_PrimaryOxygen < commonData.PrimaryOxygenMin)
            DB_PrimaryOxygen = commonData.PrimaryOxygenMin;
        if (DB_PrimaryOxygen > commonData.PrimaryOxygenMax)
            DB_PrimaryOxygen = commonData.PrimaryOxygenMax;
        return DB_PrimaryOxygen;
    }

    //-------------------------------Secondary Oxygen--------------------------

    //Sending out actual Secondary Oxygen
    public float actualSeondaryOxygen()
    {
        return commonData.OxygenTwoValue;
    }

    //Sending out scalling value
    public float scallingSeondaryOxygen()
    {
        commonData.OxygenTwoValue= BLScalingLimitingSecondaryOxygen(commonData.OxygenTwoValue);
        float secondaryoxygen_normalize = ((commonData.OxygenTwoValue-commonData.SecondaryOxygenMin) * 100) / (commonData.SecondaryOxygenMax - commonData.SecondaryOxygenMin);
        return secondaryoxygen_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingSecondaryOxygen(
        float DB_SecondaryOxygen
        )
    {
        // This function is about to make sure that secondary oxygen is between max and min
        if (DB_SecondaryOxygen < commonData.SecondaryOxygenMin)
            DB_SecondaryOxygen = commonData.SecondaryOxygenMin;
        if (DB_SecondaryOxygen > commonData.SecondaryOxygenMax)
            DB_SecondaryOxygen = commonData.SecondaryOxygenMax;
        return DB_SecondaryOxygen;
    }

    //-------------------------------Water--------------------------

    //Sending out actual water
    public float actualWater()
    {
        return commonData.WaterValue;
    }

    //Sending out scalling value
    public float scallingWater()
    {
        commonData.OxygenTwoValue = BLScalingLimitingWater(commonData.WaterValue);
        float water_normalize = ((commonData.WaterValue-commonData.WaterMin) * 100) / (commonData.WaterMax - commonData.WaterMin);
        return water_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingWater(
        float DB_Water
        )
    {
        // This function is about to make sure that water is between max and min
        if (DB_Water < commonData.WaterMin)
            DB_Water = commonData.WaterMin;
        if (DB_Water > commonData.WaterMax)
            DB_Water = commonData.WaterMax;
        return DB_Water;
    }

    //-------------------------------Battery--------------------------

    //Sending out actual Battery
    public float actualBattery()
    {
        return commonData.BatteryValue;
    }

    //Sending out scalling value
    public float scallingBattery()
    {
        commonData.BatteryValue = BLScalingLimitingBattery(commonData.BatteryValue);
        float battery_normalize = ((commonData.BatteryValue-commonData.BatteryMin) * 100) / (commonData.BatteryMax - commonData.BatteryMin);
        return battery_normalize;
    }

    //Scaling and limiting function
    public float BLScalingLimitingBattery(
        float DB_Battery
        )
    {
        // This function is about to make sure that Battery is between max and min
        if (DB_Battery <= commonData.BatteryMin)
            DB_Battery = commonData.BatteryMin;
        if (DB_Battery >= commonData.BatteryMax)
            DB_Battery = commonData.BatteryMax;
        return DB_Battery;
    }
}
