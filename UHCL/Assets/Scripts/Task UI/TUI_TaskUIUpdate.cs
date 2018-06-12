using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using HoloToolkit.Unity;

public class TUI_TaskUIUpdate : MonoBehaviour {
    CommonData commonData = CommonData.GetInstance();
    public TextToSpeech textToSpeech;

    


    public Text previousTask;
    public Text currentTask;
    public Text nextTask;
    public GameObject imagePanel;
    public Text  cautionText;
    public GameObject taskPanel;
    public GameObject cautionPanel;
    public Image cautionImage;

    public BL_Tasks bl_tasks;

    private int currentstep = 0;
    private bool spoke = false;

    private int num = 1;

    void Start () {
        bl_tasks = new BL_Tasks();
        taskPanel.gameObject.SetActive(false);
        cautionPanel.gameObject.SetActive(false);
        imagePanel.gameObject.SetActive(false);
       

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(commonData.loadTaskOne)
        {
            bl_tasks.LoadTaskOne();
            commonData.loadTaskOne = false;
            num = 1;
        }

        if(commonData.loadTaskTwo)
        {
            bl_tasks.LoadTaskTwo();
            commonData.loadTaskTwo = false;
            num = 2;
        }

        taskPanel.gameObject.SetActive(true);

        currentTask.text = "TASK ARRIVED";

        if (commonData.startProcedure)
        {
            GameObject[] SceneHolograms = GameObject.FindGameObjectsWithTag("Hologram");
            foreach (GameObject h in SceneHolograms)
            {
                h.GetComponent<Renderer>().enabled = false;
                h.GetComponent<BoxCollider>().enabled = false;
            }


            if (bl_tasks.currentTask.holograms != "")
            {
                String[] holograms = bl_tasks.currentTask.holograms.Split(',');
                foreach (string h in holograms)
                {
                    GameObject hologram = GameObject.Find(bl_tasks.currentTask.holograms);


                    hologram.GetComponent<Renderer>().enabled = true;
                }

            }


            previousTask.text = bl_tasks.previousTask.text;
            currentTask.text = bl_tasks.currentTask.text;
            //String voiceData = bl_tasks.currentTask.text;
            nextTask.text = bl_tasks.nextTask.text;
       
            
            cautionPanel.gameObject.SetActive(false);
            imagePanel.gameObject.SetActive(false);



            string warning = bl_tasks.currentTask.warning.ToString();
            string caution = bl_tasks.currentTask.caution.ToString();
            string images = bl_tasks.currentTask.images.ToString();


            if (images != "")
            {
                imagePanel.gameObject.SetActive(true);

                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>(Convert.ToString(bl_tasks.currentTask.images));

            }
            if (warning != "")
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = new Color32(208, 46, 40, 214);
                cautionText.text = bl_tasks.currentTask.warning;
            }
            if (caution != "")
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = new Color32(255, 255, 114, 249);
                cautionText.text = bl_tasks.currentTask.caution;
            }

            if (currentstep != commonData.currentTask.stepNumber)
            {
                spoke = false;
                currentstep = commonData.currentTask.stepNumber;
            }

           
            if (spoke == false)
            {
                textToSpeech.StartSpeaking(bl_tasks.currentTask.text);
                spoke = true;
            }
            
            if (commonData.nextStep)
            {
                if( num == 1 ) bl_tasks.nextFunction(true);
                if (num == 2) bl_tasks.nextFunction2(true);
                commonData.nextStep = false;
            }


            if (commonData.previousStep)
            {
                if(num ==1 ) bl_tasks.previousFunction(true);
                if (num == 2) bl_tasks.previousFunction2(true);
                commonData.previousStep = false;
            }
            if (commonData.repeatStep)
            {
                textToSpeech.StartSpeaking(bl_tasks.currentTask.text);
                commonData.repeatStep = false;

            }
        }
    }
}
	

