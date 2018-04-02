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

    public GameObject commonData;
    private CommonData data;

    private void OnEnable()
    {
        InputManager.Instance.AddGlobalListener(gameObject);
    }

    void Awake()
    {
        data = CommonData.GetInstance();
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText.ToLower())
        {
            case "start edit mode":
                {
                    StartEditMode();
                    break;
                }
            case "stop edit mode":
                {
                    StopEditMode();
                    break;
                }
            case "view pie details":
                {
                    ViewPieDetails();
                    break;
                }
            case "close pie details":
                {
                    ClosePieDetails();
                    break;
                }
            case "view battery":
                {
                    ViewBattery();
                    break;
                }
            case "view primary o two":
                {
                    ViewPrimaryOTwo();
                    break;
                }
            case "view secondary o two":
                {
                    ViewSecondaryOTwo();
                    break;
                }
            case "view body temperature":
                {
                    ViewBodyTemperature();
                    break;
                }
            case "view pressure":
                {
                    ViewPressure();
                    break;
                }
            case "view h two o":
                {
                    ViewHTwoO();
                    break;
                }
            case "view heart rate":
                {
                    ViewHeartRate();
                    break;
                }
            case "close detail window":
                {
                    CloseDetailWindow();
                    break;
                }
            case "pin detail window":
                {
                    PinDetailWindow();
                    break;
                }
            case "close pinned windows":
                {
                    ClosePinnedWindows();
                    break;
                }
            case "view errors":
                {
                    ViewErrors();
                    break;
                }
            case "close errors":
                {
                    CloseErrors();
                    break;
                }
            case "next error":
                {
                    NextError();
                    break;
                }
            case "previous error":
                {
                    PreviousError();
                    break;
                }
            case "view warnings":
                {
                    ViewWarnings();
                    break;
                }
            case "close warnings":
                {
                    CloseWarnings();
                    break;
                }
            case "next warning":
                {
                    NextWarning();
                    break;
                }
            case "previous warning":
                {
                    PreviousWarning();
                    break;
                }
            case "start procedure":
                {
                    StartProcedure();
                    break;
                }
            case "next step":
                {
                    NextStep();
                    break;
                }
            case "previous step":
                {
                    PreviousStep();
                    break;
                }
            case "show step image":
                {
                    ShowStepImage();
                    break;
                }
            case "hide step image":
                {
                    HideStepImage();
                    break;
                }
            case "pin task list":
                {
                    PinTaskList();
                    break;
                }
            case "close task list":
                {
                    CloseTaskList();
                    break;
                }
    
            default:
                break;
        }
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

    private void HideStepImage()
    {
        testText.text = "Hide Step Image";
        data.hideStepImage = true;
    }

    private void ShowStepImage()
    {
        testText.text = "Show Step Image";
        data.showStepImage = true;
    }

    private void PreviousStep()
    {
        testText.text = "Previous Step";
        data.previousStep = true;
    }

    private void NextStep()
    {
        testText.text = "Next Step";
        data.nextStep = true;
    }

    private void StartProcedure()
    {
        testText.text = "Start Procedure";
        data.startProcedure = true;
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
