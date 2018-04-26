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
    public ColorCode ccSO;
    public CommonData commonData;
    public BL_Main bl_main;

    void Start()
    {
        commonData = CommonData.GetInstance();
        ccSO.HHCol();
        objSO2.color = ccSO.HHColor;
    }

    // Update is called once per frame
    void Update()
    {
        radius = (bl_main.GetComponent<BL_Main>().bl_scaling.scallingSeondaryOxygen());


      if (commonData.OxygenOneValue < 1.00f)
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

            objSO2.transform.localScale = new Vector3(radius/100, radius/100, 1.0f);
        }
    }
}

