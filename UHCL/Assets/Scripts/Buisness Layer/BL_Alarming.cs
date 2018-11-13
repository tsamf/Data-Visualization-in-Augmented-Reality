﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BL_Alarming {

    private FlagStore commonData = FlagStore.GetInstance();
    private Alarms alarms = new Alarms();
    private Alarms alarmsHistory = new Alarms();
  
    public double SuitPressure;
    public double HeartRate;
    public double BodyTemperature;
    public double PrimaryOxygen;
    public double SecondaryOxygen;
    public double Water;
    public double Battery;

    public WriteFile writeFile;

    public bool suitPressureYellowLow;
    public bool suitPressureYellowHigh;
    public bool suitPressureRedLow;
    public bool suitPressureRedHigh;

    public bool heartRateYellowLow;
    public bool heartRateYellowHigh;
    public bool heartRateRedLow;
    public bool heartRateRedHigh;

    public bool bodyTemperatureYellowLow;
    public bool bodyTemperatureYellowHigh;
    public bool bodyTemperatureRedLow;
    public bool bodyTemperatureRedHigh;

    public bool primaryOxygenYellow;
    public bool primaryOxygenRed;

    public bool waterYellow;
    public bool waterRed;

    public bool batteryYellow;
    public bool batteryRed;


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
    public BL_Alarming(WriteFile writeFile)
    {
        this.writeFile = writeFile;
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
                   

                        if (!suitPressureRedHigh)
                        {
                            writeFile.WriteLine("Suit Pressure High Red");
                            suitPressureRedHigh = true;
                        }
                    
                }
            }

            if (SuitPressureHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
                {

                   

                        if(!suitPressureYellowHigh)
                        {
                            writeFile.WriteLine("suit Pressure High Yellow");
                            suitPressureYellowHigh = true;
                        }
                    
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
                {
                   
                        if (!suitPressureYellowLow)
                        {
                            writeFile.WriteLine("suit Pressure Low Yellow");
                            suitPressureYellowLow = true;
                        }
                    
                }
            }

            if (SuitPressureLoLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
                {
                    

                        if(!suitPressureRedLow)
                        {
                            writeFile.WriteLine("Suit Pressure Low Red");
                            suitPressureRedLow = true;
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
                   

                        if(!heartRateRedHigh)
                        {
                            writeFile.WriteLine("Heart Rate Red High");
                            heartRateRedHigh = true;
                        }
                    
                }
            }

            if (HeartRateHiEn == true)
            {
                if (HeartRate >= commonData.HeartRateHiDB && HeartRate <= commonData.HeartRateHiSP)
                {

                   
                        if(!heartRateYellowHigh)
                        {
                            writeFile.WriteLine("Heart Rate Yellow High");
                            heartRateYellowHigh = true;
                        }
                    
                }
            }

            if (HeartRateLoEn == true)
            {
                if (HeartRate >= commonData.HeartRateLoSP && HeartRate <= commonData.HeartRateLoDB)
                {
                    

                        if(!heartRateYellowLow)
                        {
                            writeFile.WriteLine("Heart Rate Yellow Low");
                            heartRateYellowLow = true;
                        }
                    
                }
            }

            if (HeartRateLoLoEn == true)
            {
                if (HeartRate >= commonData.HeartRateLoLoSP && HeartRate <= commonData.HeartRateLoLoDB)
                {
                   

                        if(!heartRateRedLow)
                        {
                            writeFile.WriteLine("Heart Rate Red Low");
                            heartRateRedLow = true;
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
                    

                        if(!bodyTemperatureRedHigh)
                        {
                            writeFile.WriteLine("Body Temperature Red High");
                            bodyTemperatureRedHigh = true;
                        }
                    
                }
            }

            if (BodyTemperatureHiEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureHiDB && BodyTemperature <= commonData.BodyTemperatureHiSP)
                {

                    

                        if(!bodyTemperatureYellowHigh)
                        {
                            writeFile.WriteLine("Body Temperature Yellow High");
                            bodyTemperatureYellowHigh = true;
                        }
                    
                }
            }

            if (BodyTemperatureLoEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureLoSP && BodyTemperature <= commonData.BodyTemperatureLoDB)
                {
                   

                        if(!bodyTemperatureYellowLow)
                        {
                            writeFile.WriteLine("Body Temperature Yellow Low");
                            bodyTemperatureYellowLow = false;
                        }
                    
                }
            }

            if (BodyTemperatureLoLoEn == true)
            {
                if (BodyTemperature >= commonData.BodyTemperatureLoLoSP && BodyTemperature <= commonData.BodyTemperatureLoLoDB)
                {
                    

                        if(!bodyTemperatureRedLow)
                        {
                            writeFile.WriteLine("Body Temperature Red Low");
                            bodyTemperatureRedLow = false;
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
                    

                        if(!primaryOxygenYellow)
                        {
                            writeFile.WriteLine("Oxygen Low Yellow");
                            primaryOxygenYellow = true;
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
                    
                }
            }

            if (SecondaryOxygenLoLoEn == true)
            {
                if (SecondaryOxygen <= commonData.SecondaryOxygenLoLoDB)
                {
                    
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
                   

                        if(!waterYellow)
                        {
                            writeFile.WriteLine("Water Low Yellow");
                            waterYellow = true;
                        }
                    
                }
            }

            if (WaterLoLoEn == true)
            {
                if (Water <= commonData.WaterLoLoDB)
                {
                    

                        if(!waterRed)
                        {
                            writeFile.WriteLine("Water Low Red");
                            waterRed = true;
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
                    

                        if(!batteryYellow)
                        {
                            writeFile.WriteLine("Battery Low yellow");
                            batteryYellow = true;
                        }
                    
                }
            }

            if (BatteryLoLoEn == true)
            {
                if (Battery <= commonData.BatteryLoLoDB)
                {
                    

                        if(!batteryRed)
                        {
                            writeFile.WriteLine("Battery Low Red");
                            batteryRed = true;
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
