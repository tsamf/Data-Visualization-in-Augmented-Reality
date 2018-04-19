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
                return alarms.alarms[index];
            }
        }
    }

    public Alarm GetPerviousAlarm
    {
        get{
            if(index == 0)
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
            if(index == alarms.alarms.Count -1)
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
    private bool SuitPressureHiHiEn = true;
    private bool SuitPressureHiEn = true;
    private bool SuitPressureLoLoEn = true;
    private bool SuitPressureLoEn = true;



    public BL_Alarming()
    {
        SuitPressure = commonData.SuitPressureValue;
    }

    //public void PreviousAlarmFunction()
    //{
    //    int num = CurrentAlarm.num - 1;

    //    if(num == 0)
    //    {
    //        //doing nothing
    //    }else
    //    {
    //        if(index == 1)
    //        {
    //            PreviousAlarm = alarms.alarms[num - 2];
    //            CurrentAlarm = alarms.alarms[num - 1];
    //            NextAlarm = null;
    //        }else
    //        {
    //            PreviousAlarm = alarms.alarms[num - 2];
    //            CurrentAlarm = alarms.alarms[num - 1];
    //            NextAlarm = alarms.alarms[num];
    //        }
    //    }
    //}

    //public void NextAlarmFunction()
    //{
    //    int num = CurrentAlarm.num -1;

    //    if(num == alarms.alarms.Count - 1)
    //    {
    //        PreviousAlarm = null;
    //        CurrentAlarm = null;
    //        NextAlarm = null;
    //    }else
    //    {
    //        if(num == alarms.alarms.Count - 2)
    //        {
    //            NextAlarm = null;
    //            PreviousAlarm = alarms.alarms[num];
    //            CurrentAlarm = alarms.alarms[num + 1];
    //        } else
    //        {
    //            PreviousAlarm = alarms.alarms[num];
    //            CurrentAlarm = alarms.alarms[num + 1];
    //            NextAlarm = alarms.alarms[num + 2];
    //        }
    //    }
    //}


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
        if(index > alarms.alarms.Count-1)
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
                        Alarm alarm = new Alarm(AlarmType.SuitPressureHiHiStatus,"HiHi Suit Pressure");
                        alarms.alarms.Insert(0,alarm);
           
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
                        alarms.alarms.Insert(0,alarm);
                    }
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
                {
                    if(alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureLoStatus) == null)
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

        if(GetCurrentAlarm != null)
        {
            Debug.Log("HI got thrown");
            Debug.Log(GetCurrentAlarm.message);
        }
    }

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
 SuitPressureHiStatus,
 SuitPressureHiHiStatus,
 SuitPressureLoStatus,
 SuitPressureLoLoStatus,
}

//public bool SuitPressureHiStatus;
//public bool SuitPressureHiHiStatus;
//public bool SuitPressureLoStatus;
//public bool SuitPressureLoLoStatus;