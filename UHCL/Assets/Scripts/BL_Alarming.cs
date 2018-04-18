using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BL_Alarming {

    private CommonData commonData = CommonData.GetInstance();
    private Alarms alarms = new Alarms();
    private Alarms alarmsHistory = new Alarms();

    public bool SuitPressureHiStatus;
    public bool SuitPressureHiHiStatus;
    public bool SuitPressureLoStatus;
    public bool SuitPressureLoLoStatus;
    public double SuitPressure;
    public string alarmText;

    public bool AcknowldegeFlag;

    public Alarm PreviousAlarm;
    public Alarm AcknowldegeAlarm;
    public Alarm NextAlarm;
    public Alarm CurrentAlarm;
    int index;

    public BL_Alarming()
    {
        SuitPressure = commonData.SuitPressureValue;

        index = alarms.alarms.Count;
    }

    public void PreviousAlarmFunction()
    {
        int num = CurrentAlarm.num - 1;

        if(num == 0)
        {
            //doing nothing
        }else
        {
            if(index == 1)
            {
                PreviousAlarm = alarms.alarms[num - 2];
                CurrentAlarm = alarms.alarms[num - 1];
                NextAlarm = null;
            }else
            {
                PreviousAlarm = alarms.alarms[num - 2];
                CurrentAlarm = alarms.alarms[num - 1];
                NextAlarm = alarms.alarms[num];
            }
        }
    }

    public void NextAlarmFunction()
    {
        int num = CurrentAlarm.num -1;

        if(num == alarms.alarms.Count - 1)
        {
            PreviousAlarm = null;
            CurrentAlarm = null;
            NextAlarm = null;
        }else
        {
            if(num == alarms.alarms.Count - 2)
            {
                NextAlarm = null;
                PreviousAlarm = alarms.alarms[num];
                CurrentAlarm = alarms.alarms[num + 1];
            } else
            {
                PreviousAlarm = alarms.alarms[num];
                CurrentAlarm = alarms.alarms[num + 1];
                NextAlarm = alarms.alarms[num + 2];
            }
        }
    }


    public void AcknowldegeAlarmFunction()
    {
        //Take Alarm from alarms
        //Put in alarm history 
        AcknowldegeFlag = true;
    }

    // Alarming function
    public void BLAlarming()
    {


        bool SuitPressureHiHiEn = true;
        bool SuitPressureHiEn = true;
        bool SuitPressureLoLoEn = true;
        bool SuitPressureLoEn = true;


        if (SuitPressure >= commonData.SuitPressureMin && SuitPressure <= commonData.SuitPressureMax)
        {

            if(index !=0)
            {
                CurrentAlarm = alarms.alarms[index];
            }

            // If SuitPressureHiHi enables, it will check how much suit pressure is and turn the alarm on or off, depends on suit pressure value
            if (SuitPressureHiHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiHiDB && SuitPressure <= commonData.SuitPressHiHiSP)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureHiHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureHiHiStatus, index+1, "HiHi Suit Pressure");
                        alarms.alarms.Add(alarm);
                        index++;
                    }
                }
            }

            if (SuitPressureHiEn == true)
            {
                if (SuitPressure >= commonData.SuitPressHiDB && SuitPressure <= commonData.SuitPressHiSP)
                {

                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureHiStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureHiStatus, index + 1, "Hi Suit Pressure");
                        alarms.alarms.Add(alarm);
                        index++;
                    }
                }
            }

            if (SuitPressureLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoSP && SuitPressure <= commonData.SuitPressLoDB)
                {
                    if(alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureLoStatus, index + 1, "Low Suit Pressure");
                        alarms.alarms.Add(alarm);
                        index++;
                    }
                }
            }

            if (SuitPressureLoLoEn == true)
            {
                if (SuitPressure >= commonData.SuitPressLoLoSP && SuitPressure <= commonData.SuitPressLoLoDB)
                {
                    if (alarms.alarms.FirstOrDefault(x => x.type == AlarmType.SuitPressureLoLoStatus) == null)
                    {
                        Alarm alarm = new Alarm(AlarmType.SuitPressureLoLoStatus, index + 1, "LowLow Suit Pressure");
                        alarms.alarms.Add(alarm);
                        index++;
                    }
                }
            }

        }
        else
        {
            Debug.Log("Something wrong here!");
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
    public Alarm(AlarmType type, int num, string message = "Message not set.")
    {
        this.type = type;
        this.message = message;
        timeCreated = DateTime.Now;
        active = true;
    }

    public AlarmType type;
    public string message;
    public int num;
    public bool active;
    public DateTime timeCreated;
    
}

public enum AlarmType
{
 SuitPressureHiStatus,
 SuitPressureHiHiStatus,
 SuitPressureLoStatus,
 SuitPressureLoLoStatus,
}