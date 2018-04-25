using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BL_Alarming {

    private CommonData commonData = CommonData.GetInstance();
    private Alarms alarms = new Alarms();
    private Alarms alarmsHistory = new Alarms();
  
    public double SuitPressure;
    public double HeartRate;
    public double BodyTemperature;
    public double PrimaryOxygen;
    public double SecondaryOxygen;
    public double Water;
    public double Battery;

    int index = 0;

    public Alarm GetCurrentAlarm
    {
        get {
            if (alarms.alarms.Count == 0)
            {
                return null;
            }
            else
            {
                return alarms.alarms[0];
            }
        }
    }

    public Alarm GetPerviousAlarm
    {
        get{
            if(index <= 0)
            {
                return null;
            }
            else
            {
                return alarms.alarms[index - 1];
            }
        }
    }

    public Alarm GetNextAlarm
    {
        get
        {
            if(index >= alarms.alarms.Count -1)
            {
                return null;
            }
            else
            {
                return alarms.alarms[index + 1];
            }
        }
    }

    //Turn flag checking on and off

    //Suit Pressure
    private bool SuitPressureHiHiEn = true;
    private bool SuitPressureHiEn = true;
    private bool SuitPressureLoLoEn = true;
    private bool SuitPressureLoEn = true;

    //HearRate
    private bool HeartRateHiHiEn = true;
    private bool HeartRateHiEn = true;
    private bool HeartRateLoLoEn = true;
    private bool HeartRateLoEn = true;

    //BodyTemperature
    private bool BodyTemperatureHiHiEn = true;
    private bool BodyTemperatureHiEn = true;
    private bool BodyTemperatureLoLoEn = true;
    private bool BodyTemperatureLoEn = true;

    //PrimaryOxygen
    private bool PrimaryOxygenLoEn = true;

    //SecondaryOxygen
    private bool SecondaryOxygenLoEn = true;
    private bool SecondaryOxygenLoLoEn = true;

    //Water
    private bool WaterLoEn = true;
    private bool WaterLoLoEn = true;

    //Battery
    private bool BatteryLoEn = true;
    private bool BatteryLoLoEn = true;

    //Constructor
    public BL_Alarming()
    {
        //SuitPressure = commonData.SuitPressureValue;
        //HeartRate = commonData.HeartRateValue;
        //BodyTemperature = commonData.BodyTemperatureValue;
        //PrimaryOxygen = commonData.OxygenOneValue;
        //SecondaryOxygen = commonData.OxygenTwoValue;
        //Water = commonData.WaterValue;
        //Battery = commonData.BatteryValue;
    }

    public void AcknowldegeAlarmFunction()
    {
        //Put alarm in temp variable and remove from alarms
        Alarm ackAlarm = alarms.alarms[index];
        alarms.alarms.RemoveAt(index);

        //Set Acknowleged time
        ackAlarm.timeAcknowledged = DateTime.Now;

        //Insert into History
        alarmsHistory.alarms.Insert(0, ackAlarm);

        //if we clear the last alarm we have to shrink the index
        if(index > alarms.alarms.Count-1 && index != 0)
        {
            index--;
        }
        
    }

    public void NextAlarmFunction()
    {
        if(alarms.alarms.Count()-1 > index)
        {
            index++;
        }
    }

    public void PreviousAlarmFunction()
    {
        if(index > 0)
        {
            index--;
        }
    }

    // Alarming function
    public void BLAlarmingFunction()
    {
        ProcessVoiceCommands();
        ProcessPressure();
        ProcessHeartRate();
        ProcessPrimaryOxygen();
        ProcessSecondaryOxygen();
        ProcessWater();
        ProcessBattery();
    }

    //SuitPressure
    private void ProcessPressure()
    {
        SuitPressure = commonData.SuitPressureValue;
        if (SuitPressure >= commonData.SuitPressureMin && SuitPressure <= commonData.SuitPressureMax)
        {

            // If SuitPressureHiHi enables, it will check how much suit pressure is and turn the alarm on or off, depends on suit pressure value
            if (SuitPressureHiHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiHiDB && SuitPressure <= commonData.SuitPressHiHiSP)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureHiHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureHiHiStatus, "HiHi Suit Pressure");
                        alarms.alarms.Insert(0, alarm);

                    }
                }
            }

            if (SuitPressureHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
                {

                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureHiStatus, "Hi Suit Pressure");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureLoStatus, "Low Suit Pressure");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (SuitPressureLoLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureLoLoStatus, "LowLow Suit Pressure");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Something wrong here!");
        }
    }

    //HearRate
    private void ProcessHeartRate ()
    {
        HeartRate = commonData.HeartRateValue;
        if (HeartRate >= commonData.HeartRateMin && HeartRate <= commonData.HeartRateMax)
        {

            // If HearRateHiHi enables, it will check how much hear rate is and turn the alarm on or off, depends on heart rate value
            if (HeartRateHiHiEn == true)
            {
                if (HeartRate >= commonData.HeartRateHiHiDB && HeartRate <= commonData.HeartRateHiHiSP)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.HeartRateHiHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.HeartRateHiHiStatus, "HiHi Heart rate");
                        alarms.alarms.Insert(0, alarm);

                    }
                }
            }

            if (HeartRateHiEn == true)
            {
                if (HeartRate >= commonData.HeartRateHiDB && HeartRate <= commonData.HeartRateHiSP)
                {

                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.HeartRateHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.HeartRateHiStatus, "Hi Heart Rate");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (HeartRateLoEn == true)
            {
                if (HeartRate >= commonData.HeartRateLoSP && HeartRate <= commonData.HeartRateLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.HeartRateLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.HeartRateLoStatus, "Low Heart Rate");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (HeartRateLoLoEn == true)
            {
                if (HeartRate >= commonData.HeartRateLoLoSP && HeartRate <= commonData.HeartRateLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.HeartRateLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.HeartRateLoLoStatus, "LowLow Heart Rate");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
        }
    }

    //BodyTemperature
    private void ProcessBodyTemperature()
    {
        BodyTemperature = commonData.BodyTemperatureValue;
        if (BodyTemperature >= commonData.BodyTemperatureMin && BodyTemperature <= commonData.BodyTemperatureMax)
        {

            // If BodyTemperatureHiHi enables, it will check how much body temperature is and turn the alarm on or off, depends on body temperature value
            if (BodyTemperatureHiHiEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureHiHiDB && BodyTemperature <= commonData.BodyTemperatureHiHiSP)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BodyTemperatureHiHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BodyTemperatureHiHiStatus, "HiHi Body Temperature");
                        alarms.alarms.Insert(0, alarm);

                    }
                }
            }

            if (BodyTemperatureHiEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureHiDB && BodyTemperature <= commonData.BodyTemperatureHiSP)
                {

                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BodyTemperatureHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BodyTemperatureHiStatus, "Hi Body Temperature");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (BodyTemperatureLoEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureLoSP && BodyTemperature <= commonData.BodyTemperatureLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BodyTemperatureLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BodyTemperatureLoStatus, "Low Body Temperature");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (BodyTemperatureLoLoEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureLoLoSP && BodyTemperature <= commonData.BodyTemperatureLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BodyTemperatureLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BodyTemperatureLoLoStatus, "Low Low Body Temperature");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
            Debug.Log("Body Temperature Something wrong here!");
        }
    }

    //PrimaryOxygen
    private void ProcessPrimaryOxygen()
    {
        PrimaryOxygen = commonData.OxygenOneValue;
        if (PrimaryOxygen >= commonData.PrimaryOxygenMin && PrimaryOxygen <= commonData.PrimaryOxygenMax)
        {

            if (PrimaryOxygenLoEn == true)
            {
                if (PrimaryOxygen <= commonData.PrimaryOxygenLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.PrimaryOxygenLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.PrimaryOxygenLoStatus, "Low Primary Oxygen");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
           
        }
    }

    //SecondaryOxygen
    private void ProcessSecondaryOxygen()
    {
        SecondaryOxygen = commonData.OxygenTwoValue;
        if (SecondaryOxygen >= commonData.SecondaryOxygenMin && SecondaryOxygen <= commonData.SecondaryOxygenMax)
        {
            if (SecondaryOxygenLoEn == true)
            {
                if (SecondaryOxygen <= commonData.SecondaryOxygenLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SecondaryOxygenLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SecondaryOxygenLoStatus, "Low Secondary Oxygen");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (SecondaryOxygenLoLoEn == true)
            {
                if (SecondaryOxygen <= commonData.SecondaryOxygenLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SecondaryOxygenLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SecondaryOxygenLoLoStatus, "Low Low Secondary Oxygen");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
            
        }
    }

    //Water
    private void ProcessWater()
    {
        Water = commonData.WaterValue;
        if (Water >= commonData.WaterMin && Water <= commonData.WaterMax)
        {
            if (WaterLoEn == true)
            {
                if (Water <= commonData.WaterLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.WaterLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SecondaryOxygenLoStatus, "Low Water");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (WaterLoLoEn == true)
            {
                if (Water <= commonData.WaterLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.WaterLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.WaterLoLoStatus, "Low Low Water");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
      
        }
    }

    //Battery
    private void ProcessBattery()
    {
        Battery = commonData.BatteryValue;
        if (Battery >= commonData.BatteryMin && Battery <= commonData.BatteryMax)
        {
            if (BatteryLoEn == true)
            {
                if (Battery <= commonData.BatteryLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BatteryLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BatteryLoStatus, "Low Battery");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }

            if (BatteryLoLoEn == true)
            {
                if (Battery <= commonData.BatteryLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.BatteryLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.BatteryLoLoStatus, "Low Low Battery");
                        alarms.alarms.Insert(0, alarm);
                    }
                }
            }
        }
        else
        {
          
        }
    }

    //Voice Commands
    private void ProcessVoiceCommands()
    {
       if(commonData.nextWarning)
        {
            NextAlarmFunction();
            commonData.nextWarning = false;
        }

       if(commonData.previousWarning)
        {
            PreviousAlarmFunction();
            commonData.previousWarning = false;
        }

       if(commonData.warningAcknowledged)
        {
            AcknowldegeAlarmFunction();
            commonData.warningAcknowledged = false;
        }
    }
}

//Alarms class
public class Alarms {

    public Alarms()
    {
        alarms = new List<Alarm>();
    }

    public List<Alarm> alarms;
    }

public class Alarm
{
    public Alarm(AlarmType type, string message = "Message not set.")
    {
        this.type = type;
        this.message = message;
        timeCreated = DateTime.Now;
        active = true;
    }

    public AlarmType type;
    public string message;
    public bool active;
    public DateTime timeCreated;
    public DateTime timeAcknowledged;
    
}

public enum AlarmType
{
 //SuitPressure
 SuitPressureHiStatus,
 SuitPressureHiHiStatus,
 SuitPressureLoStatus,
 SuitPressureLoLoStatus,

 //HeartRate
HeartRateHiStatus,
HeartRateHiHiStatus,
HeartRateLoStatus,
HeartRateLoLoStatus,

//BodyTemperature
BodyTemperatureHiStatus,
BodyTemperatureHiHiStatus,
BodyTemperatureLoStatus,
BodyTemperatureLoLoStatus,

//Primary Oxygen
PrimaryOxygenLoStatus,

//Secondary Oxygen
SecondaryOxygenLoStatus,
SecondaryOxygenLoLoStatus,

//Water
WaterLoStatus,
WaterLoLoStatus,

//Battery
BatteryLoStatus,
BatteryLoLoStatus,
}
