using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using HoloToolkit.Unity;

public class TUI_TaskUIUpdate : MonoBehaviour {
    CommonData commonData = CommonData.GetInstance();
    TextToSpeech textToSpeech = new TextToSpeech();
    
    


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
        taskPanel.gameObject.SetActive(true);

        currentTask.text = "TASK ARRIVED";
<<<<<<< HEAD
=======
        textToSpeech.StartSpeaking("Task Arrived");

>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9
        if (commonData.startProcedure)
        {
            GameObject[] SceneHolograms = GameObject.FindGameObjectsWithTag("Hologram");
            foreach(GameObject h in SceneHolograms)
            {
                h.GetComponent<Renderer>().enabled = false;
                h.GetComponent<BoxCollider>().enabled = false;
            }


            if(bl_tasks.currentTask.holograms != "")
            {
                String[] holograms = bl_tasks.currentTask.holograms.Split(',');
                foreach(string h in holograms)
                {
                  GameObject hologram = GameObject.Find(bl_tasks.currentTask.holograms);
                    

                  hologram.GetComponent<Renderer>().enabled = true;
                }
                
            }


            previousTask.text = bl_tasks.previousTask.text;
            currentTask.text = bl_tasks.currentTask.text;
            //String voiceData = bl_tasks.currentTask.text;
            nextTask.text = bl_tasks.nextTask.text;
            imagePanel.gameObject.SetActive(true);
<<<<<<< HEAD
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
=======
            imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>(Convert.ToString(bl_tasks.currentTask.stepNumber));
            cautionPanel.gameObject.SetActive(false);
            textToSpeech.StartSpeaking(bl_tasks.currentTask.text);
            

            string warning = bl_tasks.currentTask.warning.ToString();
            string caution = bl_tasks.currentTask.caution.ToString();
            string images = bl_tasks.currentTask.images.ToString();


            if (warning != "")
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = new Color32(208,46,40,214);
                cautionText.text = bl_tasks.currentTask.warning;
            }
            if (caution != "")
            {
                cautionPanel.gameObject.SetActive(true);
                cautionPanel.GetComponent<Image>().color = new Color32(255,255,114,249);
                cautionText.text = bl_tasks.currentTask.caution;
            }
            
            
            if (commonData.nextStep)
            {
                bl_tasks.nextFunction(true);
                
>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                textToSpeech.StartSpeaking(bl_tasks.currentTask.text);
                imagePanel.gameObject.SetActive(true);
<<<<<<< HEAD
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
                commonData.nextStep = false;
                //cautionPanel.SetActive(false);
=======
                Debug.Log(bl_tasks.currentTask.stepNumber);
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>(Convert.ToString(bl_tasks.currentTask.stepNumber));
                commonData.nextStep = false;
                textToSpeech.StartSpeaking("");





>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9
            }
            textToSpeech.StartSpeaking("");

            if (commonData.previousStep)
            {
<<<<<<< HEAD
=======
                bl_tasks.previousFunction(true);
>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9
                previousTask.text = bl_tasks.previousTask.text;
                currentTask.text = bl_tasks.currentTask.text;
                nextTask.text = bl_tasks.nextTask.text;
                textToSpeech.StartSpeaking(bl_tasks.currentTask.text);
                imagePanel.gameObject.SetActive(true);
<<<<<<< HEAD
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>("key");
=======
                imagePanel.GetComponent<Image>().sprite = Resources.Load<Sprite>(Convert.ToString(bl_tasks.currentTask.stepNumber));
>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9
                commonData.previousStep = false;
                //cautionPanel.SetActive(false);
            }
            textToSpeech.StartSpeaking("");

        }
<<<<<<< HEAD
=======
     
>>>>>>> 156d387e287ead252de6f4b365f715d59a134ab9

    }

}
	

