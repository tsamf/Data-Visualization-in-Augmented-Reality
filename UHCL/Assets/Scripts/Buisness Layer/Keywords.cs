using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Keywords : MonoBehaviour,ISpeechHandler {

    ///This script is where voice command functionality is defined 
    ///The buisness layer will recieve voice commands and resolve them

    //Need Instance of buisnees layer 
    public bool IsGlobalListener = true;
    public TextMesh testText;
    public GameObject alternatePIEUI;
    public GameObject pieUI;

    public WriteFile writeFile;

    private FlagStore data;
    private TaskUIController taskUIController;

    private void OnEnable()
    {
        alternatePIEUI = GameObject.FindGameObjectWithTag("AlternatePieUI");
        pieUI = GameObject.FindGameObjectWithTag("PieUI");
        InputManager.Instance.AddGlobalListener(gameObject);
        writeFile = GameObject.FindGameObjectWithTag("Insturmenting").GetComponent<WriteFile>();
    }

    void Awake()
    {
        data = FlagStore.GetInstance();
        taskUIController = GameObject.FindObjectOfType<TaskUIController>();
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText.ToLower())
        {
            case "reset pressure":
                {
                    writeFile.WriteLine("reset pressure");
                    testText.text = "Reset Pressure";
                    break;
                }
            case "reset heart rate":
                {
                    writeFile.WriteLine("reset heart rate");
                    testText.text = "Reset Heart Rate";
                    break;
                }
            case "reset body temp":
                {
                    writeFile.WriteLine("reset body temp");
                    testText.text = "Reset Body Temp";
                    break;
                }
            case "reset oxygen":
                {
                    writeFile.WriteLine("reset oxygen");
                    testText.text = "Reset Oxygen";
                    break;
                }
            case "reset water":
                {
                    writeFile.WriteLine("reset water");
                    testText.text = "Reset Water";
                    break;
                }
            case "reset battery":
                {
                    writeFile.WriteLine("reset battery");
                    testText.text = "Reset Battery";
                    break;
                }
            case "show details":
                {
                    writeFile.WriteLine("show Details");
                    testText.text = "Show Details";
                    if(data.pieUI)
                    {
                        pieUI.GetComponent<RectTransform>().localScale = new Vector3(.002f, .002f, .002f);
                        pieUI.GetComponent<RectTransform>().position = new Vector3(.36f, .18f, 1);
                    }
                    else
                    {
                        alternatePIEUI.GetComponent<RectTransform>().localScale = new Vector3(.002f, .002f, .002f);
                        alternatePIEUI.GetComponent<RectTransform>().position = new Vector3(.36f, .18f, 1);
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
                        pieUI.GetComponent<RectTransform>().position = new Vector3(0, 0, 1);
                    }
                    else
                    {
                        alternatePIEUI.GetComponent<RectTransform>().localScale = new Vector3(.001f, .001f, .001f);
                        alternatePIEUI.GetComponent<RectTransform>().position = new Vector3(0, 0, 1);
                    }
                    break;
                }
            case "start procedure":
                {
                    testText.text = "Start Procedure";
                    taskUIController.StartPocedure();
                    writeFile.WriteLine("Start procedure");
                    break;
                }

                //TODO remove old references we arent calling methods in this class anymore
            case "next task":
                {
                    testText.text = "Next Task";
                    taskUIController.NextTask();
                    writeFile.WriteLine("Next task");
                    break;
                }
            case "repeat task":
                {
                    testText.text = "Repeat task";
                    taskUIController.RepeatTask();
                    writeFile.WriteLine("Repeat task");
                    break;
                }
            case "previous task":
                {
                    testText.text = "Previous Task";
                    taskUIController.PreviousTask();
                    writeFile.WriteLine("Previous Task");
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
            default:
                writeFile.WriteLine("voice command failed");
                break;
        }
    }
   


    private void NotGreen()
    {
        testText.text = "Not Green light";
        FlagStore.notgreen = true;
    }

    private void Green()
    {
        testText.text = "Green light";
        FlagStore.green = true;
    }

    private void WarningAcknowledged()
    {
        testText.text = "Warning acknowledged";
        data.warningAcknowledged = true;
    }

    private void LoadTaskTwo()
    {
        testText.text = "Load Task Two";
        data.loadTaskTwo = true;
    }

    private void LoadTaskOne()
    {
        testText.text = "Load Task One";
        data.loadTaskOne = true;
    }

    private void DisplayAlternate()
    {
        GameObject.FindGameObjectWithTag("PieUI").GetComponent<Canvas>().enabled = false;
        GameObject.FindGameObjectWithTag("AlternatePieUI").GetComponent<Canvas>().enabled = true;
    }

    private void DisplayPie()
    {
        GameObject.FindGameObjectWithTag("PieUI").GetComponent<Canvas>().enabled = true;
        GameObject.FindGameObjectWithTag("AlternatePieUI").GetComponent<Canvas>().enabled = false;

    }

    private void CloseTaskList()
    {
        testText.text = "Close Task List";
        data.closeTaskList = true;
    }

    private void PinTaskList()
    {
        testText.text = "Pin Task List";
        data.pinTaskList = true;
    }

    private void HideTaskImage()
    {
        testText.text = "Hide Step Image";
        data.hideStepImage = true;
    }

    private void PreviousWarning()
    {
        testText.text = "Previous Warning";
        data.previousWarning = true;
    }

    private void NextWarning()
    {
        testText.text = "Next Warning";
        data.nextWarning = true;
    }

    private void CloseWarnings()
    {
        testText.text = "Close Warnings";
        data.closeWarnings = true;
    }

    private void ViewWarnings()
    {
        testText.text = "View Warnings";
        data.viewWarnings = true;
    }

    private void PreviousError()
    {
        testText.text = "Previous Error";
        data.previousError = true;
    }

    private void NextError()
    {
        testText.text = "Next Error";
        data.nextError = true;
    }

    private void CloseErrors()
    {
        testText.text = "Close Errors";
        data.closeErrors = true;
    }

    private void ViewErrors()
    {
        testText.text = "View Errors";
        data.viewErrors = true;
    }

    private void ClosePinnedWindows()
    {
        testText.text = "Close Pinned Windows";
        data.closePinnedWindows = true;
    }

    private void PinDetailWindow()
    {
        testText.text = "Pin Detail Window";
        data.pinDetailWindow = true;
    }

    private void ViewPieDetails()
    {
        testText.text = "View Pie Details";
        data.viewPieDetails = true;
    }

    private void ClosePieDetails()
    {
        testText.text = "Close Pie Details";
        data.viewPieDetails = false;
        data.closePieDetails = true;
    }

    private void ViewBattery()
    {
        testText.text = "View Battery";
        data.viewBattery = true;
    }

    private void ViewPrimaryOTwo()
    {
        testText.text = "View Primary O Two";
        data.viewPrimaryOTwo = true;
    }

    private void ViewSecondaryOTwo()
    {
        testText.text = "View Secondary O Two";
        data.viewSecondaryOTwo = true;
    }

    private void ViewBodyTemperature()
    {
        testText.text = "View Body Temperature";
        data.viewBodyTemperature = true;
    }

    private void ViewPressure()
    {
        testText.text = "View Pressure";
        data.viewPressure = true;
    }

    private void ViewHTwoO()
    {
        testText.text = "View H Two O";
        data.viewHTwoO = true;
    }

    private void ViewHeartRate()
    {
        testText.text = "View Heart Rate";
        data.viewHeartRate = true;
    }

    private void CloseDetailWindow()
    {
        testText.text = "Close Detail Window";
        data.viewPressure = false;
        data.viewPrimaryOTwo = false;
        data.viewSecondaryOTwo = false;
        data.viewHeartRate = false;
        data.viewBattery = false;
        data.viewBodyTemperature = false;
        data.viewHTwoO = false;
        data.closeDetailWindow = true;
    }

    private void StopEditMode()
    {
        testText.text = "Stop edit mode.";
        data.EditMode = false;
    }

    private void StartEditMode()
    {
        testText.text = "Start edit mode.";
        data.EditMode = true;
    }
}
