using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using System;

public class Keywords : MonoBehaviour,ISpeechHandler {

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
        data = commonData.GetComponent<CommonData>();
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
            default:
                break;
        }
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
