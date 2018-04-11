using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SecondaryO2 : MonoBehaviour
{

    // Use this for initialization
    public float radius = 1.0f;
    public Image objSO2;
    public float currentSO2;
    public ColorCode ccSO;
    public CommonData commanData;
    void Start()
    {
        commanData = CommonData.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {

       
            radius = commanData.OxygenTwoValue / 100;


            if (currentSO2 >= 0.80)
            {
                // Debug.Log("HH");
                ccSO.HHCol();
                objSO2.color = ccSO.HHColor;
            }
            else if (0.79f >= currentSO2 && currentSO2 >= 0.50f)
            {
                // Debug.Log("H");
                ccSO.HCol();
                objSO2.color = ccSO.HColor;
            }
            else if (0.49 >= currentSO2 && currentSO2 >= 0.25f)
            {
                //Debug.Log("L");
                ccSO.LCol();
                objSO2.color = ccSO.LColor;
            }

            else if (0.24 >= currentSO2 && currentSO2 >= 0.01f)
            {
                //Debug.Log("LL");
                ccSO.LLCol();
                objSO2.color = ccSO.LLColor;
            }

          //  else
            // Debug.Log("Secondary O2 Error");


            if (currentSO2 >= 0.009f)
                objSO2.transform.localScale = new Vector3(radius, radius, 1.0f);
        }
    }

