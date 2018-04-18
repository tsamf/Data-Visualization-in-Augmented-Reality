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

            cautionPanel.gameObject.SetActive(false);

            string warning = bl_tasks.currentTask.warning.ToString();
            string caution = bl_tasks.currentTask.caution.ToString();

            if (warning != "" )
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = Color.red;
                cautionText.text = bl_tasks.currentTask.warning;
            } 
            if( caution != "")
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = Color.yellow;
                cautionText.text = bl_tasks.currentTask.caution;
            }
            

            if (commonData.nextStep)
            {
                bl_tasks.nextFunction(true);
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                imagePanel.gameObject.SetActive(true);
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
                commonData.nextStep = false;
                //cautionPanel.SetActive(false);
            }

            if (commonData.previousStep)
            {
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                imagePanel.gameObject.SetActive(true);
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
                commonData.previousStep = false;
                //cautionPanel.SetActive(false);
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