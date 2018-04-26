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
    public float intialSO2 = 1.0f;
    public ColorCode ccSO;
    public CommonData commonData;
    public BL_Main bl_main;
   
    void Start()
    {
        commonData = CommonData.GetInstance();
   
    }

    // Update is called once per frame
    void Update()
    {
        radius = bl_main.bl_scaling.scallingSeondaryOxygen() / 100;


        if (commonData.OxygenOneValue <= commonData.PrimaryOxygenMin)
        { 

            if (commonData.OxygenTwoValue > commonData.SecondaryOxygenHiDB)
            {
                // Debug.Log("HH");
                ccSO.HHCol();
                objSO2.color = ccSO.HHColor;
            }
            else if (commonData.SecondaryOxygenHiDB > commonData.OxygenTwoValue && commonData.OxygenTwoValue > commonData.SecondaryOxygenLoDB)
            {
                // Debug.Log("H");
                ccSO.HCol();
                objSO2.color = ccSO.HColor;
            }
            else if (commonData.SecondaryOxygenLoDB > commonData.OxygenTwoValue && commonData.OxygenTwoValue > commonData.SecondaryOxygenLoLoDB)
            {
                //Debug.Log("L");
                ccSO.LCol();
                objSO2.color = ccSO.LColor;
            }

            else if (commonData.OxygenTwoValue < commonData.SecondaryOxygenLoLoDB)
            {
                //Debug.Log("LL");
                ccSO.LLCol();
                objSO2.color = ccSO.LLColor;
              
            }

                objSO2.transform.localScale = new Vector3(radius, radius, 1.0f);
        }
    }
}

