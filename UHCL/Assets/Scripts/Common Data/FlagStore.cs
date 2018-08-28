using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagStore {
    
    private static FlagStore _commonData;

    private FlagStore() { }

    public static FlagStore GetInstance()
    {
        if(_commonData == null)
        {
            _commonData = new FlagStore();
        }

        return _commonData;
    }

    public int userID = 1;
    public bool pieUI = false;

    //The common data  (flags and alarm definitions will go here)
    private bool editMode = false;
	public bool EditMode { get { return editMode; } set { editMode = value; } }

    public EVATask previousTask;
    public EVATask currentTask;
    public EVATask nextTask;
    public EVATask repeatTask;

    //public EVATask GetPreviousTask { get { return previousTask; } }
    //public EVATask GetCurrentTask { get { return currentTask; } }
    //public EVATask GetNextTask { get { return nextTask; } }
    //public EVATask GetRepeatTask { get { return repeatTask; } }


    public bool viewPieDetails = false;
    public bool closePieDetails = false;
    public bool viewBattery = false;
    public bool viewPrimaryOTwo = false;
    public bool viewSecondaryOTwo = false;
    public bool viewBodyTemperature = false;
    public bool viewPressure = false;
    public bool viewHTwoO = false;
    public bool viewHeartRate = false;
    public bool closeDetailWindow = false;
    public bool pinDetailWindow = false;
    public bool closePinnedWindows = false;
    public bool viewErrors = false;
    public bool closeErrors = false;
    public bool nextError = false;
    public bool previousError = false;
    public bool viewWarnings = false;
    public bool closeWarnings = false;
    public bool nextWarning = false;
    public bool previousWarning = false;

    public bool startProcedure = false;
    public bool repeatStep = false;
    public bool nextStep = false;
    public bool previousStep = false;
    public bool showStepImage = false;
    public bool hideStepImage = false;
    public bool pinTaskList = false;
    public bool closeTaskList = false;
    public bool loadTaskOne = false;
    public bool loadTaskTwo = false;
    internal bool warningAcknowledged = false;
    public static bool notgreen = false;
    public static bool green = false;


    //Health UI Values
    public float OxygenOneValue { get; set; }
    public float OxygenTwoValue { get; set; }
    public float HeartRateValue { get; set; }
    public float BodyTemperatureValue { get; set; }
    public float SuitPressureValue { get; set; }
    public float BatteryValue { get; set; }
    public float WaterValue { get; set; }

    //SuitPressure
    public float SuitPressureMax { get; set; }
    public float SuitPressureMin { get; set; }

    public float SuitPressHiHiSP { get; set; } 
    public float SuitPressHiHiDB { get; set; }

    public float SuitPressHiSP { get; set; }
    public float SuitPressHiDB { get; set; }

    public float SuitPressLoSP { get; set; }
    public float SuitPressLoDB { get; set; }

    public float SuitPressLoLoSP { get; set; }
    public float SuitPressLoLoDB { get; set; }

    // Heartrate 
    public float HeartRateMax { get; set; }
    public float HeartRateMin { get; set; }

    public float HeartRateHiHiSP { get; set; }
    public float HeartRateHiHiDB { get; set; }

    public float HeartRateHiSP { get; set; }
    public float HeartRateHiDB { get; set; }

    public float HeartRateLoSP { get; set; }
    public float HeartRateLoDB { get; set; }

    public float HeartRateLoLoSP { get; set; }
    public float HeartRateLoLoDB { get; set; }

    //Bodytemperature
    public float BodyTemperatureMax { get; set; }
    public float BodyTemperatureMin { get; set; }

    public float BodyTemperatureHiHiSP { get; set; }
    public float BodyTemperatureHiHiDB { get; set; }

    public float BodyTemperatureHiSP { get; set; }
    public float BodyTemperatureHiDB { get; set; }

    public float BodyTemperatureLoSP { get; set; }
    public float BodyTemperatureLoDB { get; set; }

    public float BodyTemperatureLoLoSP { get; set; }
    public float BodyTemperatureLoLoDB { get; set; }


    //PrimaryOxygen
    public float PrimaryOxygenMax { get; set; }
    public float PrimaryOxygenMin { get; set; }
    public float PrimaryOxygenLoDB { get; set; }


    //SecondaryOxygen
    public float SecondaryOxygenMax { get; set; }
    public float SecondaryOxygenMin { get; set; }
    public float SecondaryOxygenLoDB { get; set; }
    public float SecondaryOxygenLoLoDB { get; set; }


    //Water
    public float WaterMax { get; set; }
    public float WaterMin { get; set; }

    public float WaterLoDB { get; set; }

    public float WaterLoLoDB { get; set; }

    //Battery
    public float BatteryMax { get; set; }
    public float BatteryMin { get; set; }

    public float BatteryLoDB { get; set; }

    public float BatteryLoLoDB { get; set; }

    //Task UI Values
    public string[][] PREVIOUS { get; set; }
    public string[][] CURRENT { get; set; }
    public string[][] NEXT { get; set; }
    public string[][] REPEAT { get; set; }

    public string[][] TASK_TABLE { get; set; }
    public float SecondaryOxygenHiDB { get; internal set; }

    public bool getGreen()
    {
        return FlagStore.green;
    }
    public bool getNotGreen()
    {
        return FlagStore.notgreen;
    }

    public void setGreen(bool flag)
    {
        FlagStore.green = flag;
    }

    public void setNotGreen(bool flag)
    {
        FlagStore.notgreen = flag;
    }
}
