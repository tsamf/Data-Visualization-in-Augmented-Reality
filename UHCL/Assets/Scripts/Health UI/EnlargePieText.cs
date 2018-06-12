using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnlargePieText : MonoBehaviour
{

    // Use this for initialization

    public Text PO2Text;
    public Text SO2Text;
    public Text HeartText;
    public Text BatteryText;
    public Text PressureText;
    public Text WaterText;
    public Text TemperatureText;
    public BL_Main bl_main;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PO2Text.text = ("P-O2: " + (Mathf.Round(bl_main.bl_scaling.scallingPrimaryOxygen() * 100f) / 100) + "%");
        SO2Text.text = ("S-O2: " + (Mathf.Round(bl_main.bl_scaling.scallingSeondaryOxygen() * 100f) / 100) + "%");
        HeartText.text = ("Heart: " + (int)(Mathf.Round(bl_main.bl_scaling.actualHearRate() * 100f) / 100) + "bpm");
        BatteryText.text = ("Battery: " + (Mathf.Round(bl_main.bl_scaling.scallingBattery() * 100f) / 100) + "%");
        PressureText.text = ("Pressure: " + (Mathf.Round(bl_main.bl_scaling.actualSuitPressure() * 100f) / 100) + "psi");
        WaterText.text = ("Water: " + (Mathf.Round(bl_main.bl_scaling.scallingWater() * 100f) / 100) + "%");
        TemperatureText.text = ("Temperature: " + (int)(Mathf.Round(bl_main.bl_scaling.actualBodyTemperature() * 100f) / 100) + "F");
    }
}
