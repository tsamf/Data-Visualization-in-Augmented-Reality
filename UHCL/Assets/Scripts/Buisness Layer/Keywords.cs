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
                        testText.text = "Reset Pressure";
                        pressure.ResetConsumable();
                        
                        //reset flags
                        bL_Alarming.suitPressureRedHigh = false;
                        bL_Alarming.suitPressureRedLow = false;
                        bL_Alarming.suitPressureYellowHigh = false;
                        bL_Alarming.suitPressureYellowLow = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset pressure not zoomed");
                        textToSpeech.StartSpeaking("tried reset pressure not zoomed");
                        testText.text = "tried reset pressure not zoomed";
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
                        testText.text = "Reset Heart Rate";
                        heartRate.ResetConsumable();

                        bL_Alarming.heartRateRedHigh = false;
                        bL_Alarming.heartRateRedLow = false;
                        bL_Alarming.heartRateYellowLow = false;
                        bL_Alarming.heartRateYellowHigh = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset heart rate not zoomed");
                        textToSpeech.StartSpeaking("tried reset heart rate not zoomed");
                        testText.text = "tried reset heart rate not zoomed";
                    }
                    break;
                }
            case "reset body temp":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset body temp");
                        testText.text = "Reset Body Temp";
                        bodyTemp.ResetConsumable();

                        bL_Alarming.bodyTemperatureRedHigh = false;
                        bL_Alarming.bodyTemperatureRedLow = false;
                        bL_Alarming.bodyTemperatureYellowLow = false;
                        bL_Alarming.bodyTemperatureYellowHigh = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset body temp not zoomed");
                        textToSpeech.StartSpeaking("tried reset body temp not zoomed");
                        testText.text = "tried reset body temp not zoomed";
                    }
                    break;
                }
            case "reset oxygen":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset oxygen");
                        testText.text = "Reset Oxygen";
                        oxygen.ResetConsumable();
                       
                        bL_Alarming.primaryOxygenRed = false;
                        bL_Alarming.primaryOxygenYellow = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset oxygen not zoomed");
                        textToSpeech.StartSpeaking("tried reset oxygen not zoomed");
                        testText.text = "tried reset oxygen not zoomed";
                    }
                    break;
                }
            case "reset water":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset water");
                        testText.text = "Reset Water";
                        water.ResetConsumable();

                        bL_Alarming.waterYellow = false;
                        bL_Alarming.waterRed = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset water not zoomed");
                        textToSpeech.StartSpeaking("tried reset water not zoomed");
                        testText.text = "tried reset water not zoomed";
                    }
                    break;
                }
            case "reset battery":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("reset battery");
                        testText.text = "Reset Battery";
                        battery.ResetConsumable();

                        bL_Alarming.batteryYellow = false;
                        bL_Alarming.batteryRed = false;
                    }
                    else
                    {
                        writeFile.WriteLine("tried reset battery not zoomed");
                        textToSpeech.StartSpeaking("tried reset battery not zoomed");
                        testText.text = "tried reset battery not zoomed";
                    }
                    break;
                }
            case "show details":
                {
                    if (!zoomed)
                    {
                        writeFile.WriteLine("show Details");
                        testText.text = "Show Details";
                        if (data.pieUI)
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
                    }
                    else
                    {
                        textToSpeech.StartSpeaking("Tried to show details while in show details.");
                        writeFile.WriteLine("Tried to show details while in show details.");
                        testText.text ="Tried to show details while in show details.";
                    }
                    
                    break;
                }
            case "view details":
                {
                    if (!zoomed)
                    {
                        writeFile.WriteLine("show Details");
                        testText.text = "Show Details";
                        if (data.pieUI)
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
                    }
                    else
                    {
                        textToSpeech.StartSpeaking("Tried to show details while in show details.");
                        writeFile.WriteLine("Tried to show details while in show details.");
                        testText.text = "Tried to show details while in show details.";
                    }

                    break;
                }
            case "close details":
                {
                    if (zoomed)
                    {
                        writeFile.WriteLine("Close details");
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
                    }
                    else
                    {
                        textToSpeech.StartSpeaking("Tried to close details while not in show details.");
                        writeFile.WriteLine("Tried to close details while not in show details.");
                        testText.text = "Tried to close details while not in show details.";
                    }

                    break;
                }
            case "continue":
                {
                    if(zoomed)
                    {
                        textToSpeech.StartSpeaking("Tried to continue while zoomed.");
                        writeFile.WriteLine("Tried to continue while zoomed.");
                        testText.text = "Tried to continue while zoomed.";
                    }
                    else if( holograms.activeSelf || taskUI.activeSelf)
                    {
                        textToSpeech.StartSpeaking("Tried to continue while task active. Did you mean next step?");
                        writeFile.WriteLine("Tried to continue while task active.");
                        testText.text = "Tried to continue while task active.";
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
                    if(data.currentState == FlagStore.GameState.playing)
                    {
                        if (!zoomed)
                        {
                            if(taskUI.activeSelf || holograms.activeSelf)
                            {
                                if (data.procedureStarted == false)
                                {
                                    data.procedureStarted = true;
                                    testText.text = "Start Procedure";
                                    taskUIController.StartPocedure();
                                    writeFile.WriteLine("Start procedure");
                                }
                                else
                                {
                                    testText.text = "The procedure is already started.";
                                    writeFile.WriteLine("The procedure is already started.");
                                    textToSpeech.StartSpeaking("The procedure is already started.");
                                }
                            }
                            else
                            {
                                testText.text = "Cant start procedure while task inactive";
                                writeFile.WriteLine("Cant start procedure while task inactive");
                                textToSpeech.StartSpeaking("Cant start procedure while task inactive say continue first.");
                            }
                        }
                        else
                        {
                            testText.text = "Cant start procedure while viewing details.";
                            writeFile.WriteLine("Cant start procedure while viewing details.");
                            textToSpeech.StartSpeaking("Cant start procedure while viewing details.");
                        }
                    }
                    else
                    {
                        testText.text = "Cant start procedure until the tutorial is over.";
                        writeFile.WriteLine("Started procedure before the tutorial was over.");
                        textToSpeech.StartSpeaking("Cant start procedure until the tutorial is over.");
                    }
                   
                    break;
                }
            case "next step":
                {

                    if(data.currentState == FlagStore.GameState.tutorial)
                    {
                        if (Activity.GetInstance().GetCurrentProcedure().GetCurrentTask().StepNumer == 21)
                        {
                            pressure.current = 4.29f;
                        }
                    }

                    if(!zoomed)
                    {
                        if (taskUI.activeSelf || holograms.activeSelf)
                        {
                            testText.text = "Next step";
                            taskUIController.NextTask();
                            writeFile.WriteLine("Next step");
                        }
                        else
                        {
                            testText.text = "Cant go to the next step while task inactive.";
                            writeFile.WriteLine("Cant go to the next step while task inactive.");
                            textToSpeech.StartSpeaking("Cant go to the next step while task inactive. Say continue to continue.");
                        }
                    }
                    else
                    {
                        testText.text = "Cant go to the next step while zoomed.";
                        writeFile.WriteLine("Cant go to the next step while zoomed.");
                        textToSpeech.StartSpeaking("Cant go to the next step while zoomed. Say Close details to continue.");
                    }

                    break;
                }
            case "repeat step":
                {
                    if (!zoomed)
                    {
                        if(taskUI.activeSelf || holograms.activeSelf)
                        {
                            testText.text = "Repeat step";
                            taskUIController.RepeatTask();
                            writeFile.WriteLine("Repeat step");
                        }
                       else
                        {
                            testText.text = "Cant repeat step while task inactive.";
                            writeFile.WriteLine("Cant repeat step while task inactive.");
                            textToSpeech.StartSpeaking("Cant repeat step while task inactive. Say continue to continue.");
                        }
                    }
                    else
                    {
                        testText.text = "Cant repeat step while zoomed.";
                        writeFile.WriteLine("Cant repeat step while zoomed.");
                        textToSpeech.StartSpeaking("Cant repeat step while zoomed. Say Close details to continue.");
                    }
                    
                    break;
                }
            case "previous step":
                {
                    if(!zoomed)
                    {
                        if(taskUI.activeSelf || holograms.activeSelf)
                        {
                            testText.text = "Previous step";
                            taskUIController.PreviousTask();
                            writeFile.WriteLine("Previous step");
                        }
                        else
                        {
                            testText.text = "Cant go to previous step while task inactive.";
                            writeFile.WriteLine("Cant go to previous step while task inactive.");
                            textToSpeech.StartSpeaking("Cant go to previous step while task inactive. Say continue to continue.");
                        }
                    }
                    else
                    {
                        testText.text = "Cant go to previous step while zoomed.";
                        writeFile.WriteLine("Cant go to previous step while zoomed.");
                        textToSpeech.StartSpeaking("Cant go to previous step while zoomed. Say Close details to continue.");
                    }

                    break;
                }
            case "next procedure":
                {
                    if (!zoomed)
                    {
                        if(taskUI.activeSelf || holograms.activeSelf)
                        {
                            if (Activity.GetInstance().GetCurrentProcedure().IsEndOfProcedure() && data.currentState == FlagStore.GameState.playing)
                            {
                                testText.text = "Next Procedure";
                                taskUIController.NextProcedure();
                                writeFile.WriteLine("Next Procedure");
                            }
                            else
                            {
                                testText.text = "Cant go to next procedure until the end of a procedure.";
                                writeFile.WriteLine("Cant go to next procedure until the end of a procedure.");
                                textToSpeech.StartSpeaking("Cant go to next procedure until the end of a procedure.");
                            }
                        }
                        else
                        {
                            testText.text = "Cant go to next procedure while task inactive.";
                            writeFile.WriteLine("Cant go to next procedure while task inactive.");
                            textToSpeech.StartSpeaking("Cant go to next procedure while task inactive. Say continue to continue.");
                        }
                    }
                    else
                    {
                        testText.text = "Cant go to next procedure while zoomed.";
                        writeFile.WriteLine("Cant go to next procedure while zoomed.");
                        textToSpeech.StartSpeaking("Cant go to next procedure while zoomed. Say Close details to continue.");
                    }

                    break;
                }
            case "start":
                {
                    if(data.currentState == FlagStore.GameState.tutorial)
                    {
                        testText.text = "Start";
                        writeFile.WriteLine("start");
                        data.currentState = FlagStore.GameState.playing;
                        Activity.GetInstance().SetProcedures(new List<EVAProcedure>());
                        taskUIController.LoadActivity();
                    }
                    else
                    {
                        testText.text = "Simulation already started.";
                        writeFile.WriteLine("Simulation already started.");
                        textToSpeech.StartSpeaking("Simulation already started.");
                    }

                    break;
                }
            default:
                writeFile.WriteLine("voice command failed");
                break;
        }
    }
}
