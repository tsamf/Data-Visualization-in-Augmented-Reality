using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;
using HoloToolkit.Unity;

public class Keywords : MonoBehaviour,ISpeechHandler {

    ///This script is where voice command functionality is defined 
    ///The buisness layer will recieve voice commands and resolve them

    //Need Instance of buisnees layer 
    public bool IsGlobalListener = true;
    public TextMesh testText;
    public GameObject alternatePIEUI;
    public GameObject pieUI;
    public GameObject holograms;
    public GameObject taskUI;
    public TextToSpeech textToSpeech;

    public DB_GenerateData pressure;
    public DB_GenerateData heartRate;
    public DB_GenerateData bodyTemp;
    public DB_GenerateData oxygen;
    public DB_GenerateData water;
    public DB_GenerateData battery;

    public WriteFile writeFile;

    private BL_Alarming bL_Alarming;
    public BL_Main bl_Main;

    private FlagStore data;
    private TaskUIController taskUIController;

    private bool zoomed = false;

    private void OnEnable()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
        writeFile = GameObject.FindGameObjectWithTag("Insturmenting").GetComponent<WriteFile>();
    }

    void Awake()
    {
        bL_Alarming = bl_Main.Bl_alarming; 
        data = FlagStore.GetInstance();
        taskUIController = GameObject.FindObjectOfType<TaskUIController>();
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText.ToLower())
        {
            case "reset pressure":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset pressure");
                        pressure.ResetConsumable();
                        testText.text = "Reset Pressure";

                        bL_Alarming.suitPressureRedHigh = false;
                        bL_Alarming.suitPressureRedLow = false;
                        bL_Alarming.suitPressureYellowHigh = false;
                        bL_Alarming.suitPressureYellowLow = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset pressure not zoomed");
                    }

                    if (data.currentState == FlagStore.GameState.tutorial)
                    {
                        textToSpeech.StartSpeaking("Now that the values are reset the details need to be closed to continue. Say close details.");
                    }


                    break;
                }
            case "reset heart rate":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset heart rate");
                        heartRate.ResetConsumable();
                        testText.text = "Reset Heart Rate";

                        bL_Alarming.heartRateRedHigh = false;
                        bL_Alarming.heartRateRedLow = false;
                        bL_Alarming.heartRateYellowLow = false;
                        bL_Alarming.heartRateYellowHigh = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset heart rate not zoomed");
                    }
                    break;
                }
            case "reset body temp":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset body temp");
                        bodyTemp.ResetConsumable();
                        testText.text = "Reset Body Temp";

                        bL_Alarming.bodyTemperatureRedHigh = false;
                        bL_Alarming.bodyTemperatureRedLow = false;
                        bL_Alarming.bodyTemperatureYellowLow = false;
                        bL_Alarming.bodyTemperatureYellowHigh = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset body temp not zoomed");
                    }
                    break;
                }
            case "reset oxygen":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset oxygen");
                        oxygen.ResetConsumable();
                        testText.text = "Reset Oxygen";

                        bL_Alarming.primaryOxygenRed = false;
                        bL_Alarming.primaryOxygenYellow = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset oxygen not zoomed");
                    }
                    break;
                }
            case "reset water":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset water");
                        water.ResetConsumable();
                        testText.text = "Reset Water";

                        bL_Alarming.waterYellow = false;
                        bL_Alarming.waterRed = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset water not zoomed");
                    }
                    break;
                }
            case "reset battery":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset battery");
                        battery.ResetConsumable();
                        testText.text = "Reset Battery";

                        bL_Alarming.batteryYellow = false;
                        bL_Alarming.batteryRed = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset battery not zoomed");
                    }
                    break;
                }
            case "show details":
                {
                    writeFile.WriteLine("show Details");
                    testText.text = "Show Details";
                    if(data.pieUI)
                    {
                        pieUI.GetComponent<RectTransform>().localScale = new Vector3(.002f, .002f, .002f);
                        pieUI.GetComponent<RectTransform>().localPosition = new Vector3(.36f, .18f, 1);
                        zoomed = true;
                    }
                    else
                    {
                        alternatePIEUI.GetComponent<RectTransform>().localScale = new Vector3(.002f, .002f, .002f);
                        alternatePIEUI.GetComponent<RectTransform>().localPosition = new Vector3(.36f, .18f, 1);
                        zoomed = true;
                    }

                    holograms.SetActive(false);
                    taskUI.SetActive(false);

                    if (data.currentState == FlagStore.GameState.tutorial)
                    {
                        textToSpeech.StartSpeaking("A resource can be reset by saying reset and then the name. Say reset pressure to continue.");
                    }

                    break;
                }
            case "close details":
                {
                    writeFile.WriteLine("close details");
                    testText.text = "Close Details";
                    if (data.pieUI)
                    {
                        pieUI.GetComponent<RectTransform>().localScale = new Vector3(.001f, .001f, .001f);
                        pieUI.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
                        zoomed = false;
                    }
                    else
                    {
                        alternatePIEUI.GetComponent<RectTransform>().localScale = new Vector3(.001f, .001f, .001f);
                        alternatePIEUI.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 1);
                        zoomed = false;
                    }

                    if (data.currentState == FlagStore.GameState.tutorial)
                    {
                        textToSpeech.StartSpeaking("Now that the details are closed you must say continue to resume the activity. Say continue.");
                    }

                    break;
                }
            case "continue":
                {
                    if(zoomed)
                    {
                        textToSpeech.StartSpeaking("Tried to continue while zoomed.");
                        writeFile.WriteLine("Tried to continue while zoomed.");
                    }
                    else
                    {

                        writeFile.WriteLine("Continue");
                        testText.text = "continue";
                        holograms.SetActive(true);
                        taskUI.SetActive(true);

                        if(data.currentState == FlagStore.GameState.tutorial)
                        {
                            taskUIController.NextTask();
                        }
                        else
                        {
                            textToSpeech.StartSpeaking(Activity.GetInstance().GetCurrentProcedure().GetCurrentTask().Text);
                        }
                    }

                    break;
                }
            case "start procedure":
                {
                    data.procedureStarted = true;
                    testText.text = "Start Procedure";
                    taskUIController.StartPocedure();
                    writeFile.WriteLine("Start procedure");
                    break;
                }

                //TODO remove old references we arent calling methods in this class anymore
            case "next step":
                {
                    if(data.currentState == FlagStore.GameState.tutorial)
                    {
                        if (Activity.GetInstance().GetCurrentProcedure().GetCurrentTask().StepNumer == 21)
                        {
                            pressure.current = 4.29f;
                        }
                    }

                    testText.text = "Next step";
                    taskUIController.NextTask();
                    writeFile.WriteLine("Next step");
                    break;
                }
            case "repeat step":
                {
                    testText.text = "Repeat step";
                    taskUIController.RepeatTask();
                    writeFile.WriteLine("Repeat step");
                    break;
                }
            case "previous step":
                {
                    testText.text = "Previous step";
                    taskUIController.PreviousTask();
                    writeFile.WriteLine("Previous step");
                    break;
                }
            case "load activity":
                {
                    testText.text = "Load Activity";
                    taskUIController.LoadActivity();
                    writeFile.WriteLine("Load activity");
                    break;
                }
            case "next procedure":
                {
                    testText.text = "Next Procedure";
                    taskUIController.NextProcedure();
                    writeFile.WriteLine("Next Procedure");
                    break;
                }
            case "start":
                {

                    testText.text = "Start";
                    writeFile.WriteLine("start");

                    if (data.currentState == FlagStore.GameState.editMode)
                    {
                        data.currentState = FlagStore.GameState.playing;
                    }
                    else if(data.currentState == FlagStore.GameState.tutorial)
                    {
                        data.currentState = FlagStore.GameState.playing;
                        Activity.GetInstance().SetProcedures(new List<EVAProcedure>());
                        taskUIController.LoadActivity();
                    }

                    break;
                }
            default:
                writeFile.WriteLine("voice command failed");
                break;
        }
    }
}
