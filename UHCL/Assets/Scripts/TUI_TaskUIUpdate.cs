using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TUI_TaskUIUpdate : MonoBehaviour {
    CommonData commonData = CommonData.GetInstance();


    public Text previousTask;
    public Text currentTask;
    public Text nextTask;
    public GameObject imagePanel;
    public Text  cautionText;
    public GameObject taskPanel;
    public GameObject cautionPanel;
    public Image cautionImage;

    public BL_Tasks bl_tasks;


	// Use this for initialization
	void Start () {
        bl_tasks = new BL_Tasks();
        taskPanel.gameObject.SetActive(false);
        cautionPanel.gameObject.SetActive(false);
        imagePanel.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update ()
    {

        currentTask.text = "TASK ARRIVED";

        if (commonData.startProcedure)
        {
            taskPanel.gameObject.SetActive(true);
            previousTask.text = bl_tasks.previousTask.text;
            currentTask.text = bl_tasks.currentTask.text;
            nextTask.text = bl_tasks.nextTask.text;
            imagePanel.gameObject.SetActive(true);
            imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
            cautionText.text = bl_tasks.currentTask.caution;
            if (cautionText.text != null)
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = Color.yellow;
               //cautionPanel.GetComponent<Image>().

            }

            if (commonData.nextStep)
            {
                bl_tasks.nextFunction(true);
                //nextTask.color = Color.white;
                //nextTask.fontSize = 16;

                //imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("3");

                //cautionText.text = commonData.GetNextTask.caution;
                //cautionPanel.GetComponent<Image>().color = Color.yellow;
                //previousTask.color = new Color32(93, 226, 238, 255);
                //previousTask.fontSize = 14;
                //currentTask.color = new Color32(93, 226, 238, 255);
                //currentTask.fontSize = 14;
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                imagePanel.gameObject.SetActive(true);
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
                cautionText.text = bl_tasks.currentTask.caution;
                commonData.nextStep = false;


            }

            if (commonData.previousStep)
            {
                bl_tasks.previousFunction(true);
                //previousTask.color = Color.white;
                //previousTask.fontSize = 16;

                //imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("4");

                //cautionText.text = commonData.GetPreviousTask.warning;
                //cautionPanel.GetComponent<Image>().color = Color.red;
                //currentTask.color = new Color32(93,226,238,255);
                //currentTask.fontSize = 14;
                //nextTask.color = new Color32(93, 226, 238, 255);
                //nextTask.fontSize = 14;
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                imagePanel.gameObject.SetActive(true);
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
                cautionText.text = bl_tasks.currentTask.caution;
                commonData.previousStep = false;

            }
         
        }
     






    }

}
	


/*  
    taskPanel.gameObject.SetActive(true);
     currentTask.text = commonData.GetCurrentTask.text;
               nextTask.text = commonData.GetNextTask.text;
               cautionText.text = commonData.GetCurrentTask.caution;
           if (cautionText.text != null)
           {
               cautionPanel.gameObject.SetActive(true);
               cautionPanel.GetComponent<Image>(). }
 */