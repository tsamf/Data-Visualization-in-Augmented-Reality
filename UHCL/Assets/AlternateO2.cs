using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlternateO2 : MonoBehaviour {

    // Use this for initialization
    public float fillAmount = 1.0f;
    public float intialSO2 = 1.0f;
    public Slider slider;
    public ColorCode ccSO;
    public CommonData commanData;
    public Image fillImage;

    void Start()
    {
        commanData = CommonData.GetInstance();

    }

    // Update is called once per frame
    void Update()
    {
        fillAmount = commanData.OxygenOneValue / 100;
        slider.value = fillAmount;

        if (fillAmount <= 0.9f)
        {

            if (fillAmount >= 0.80)
            {
                // Debug.Log("HH");
                ccSO.HHCol();
                fillImage.color = ccSO.HHColor;
            }
            else if (0.79f >= fillAmount && fillAmount >= 0.50f)
            {
                // Debug.Log("H");
                ccSO.HCol();
                fillImage.color = ccSO.HColor;
            }
            else if (0.49 >= fillAmount && fillAmount >= 0.25f)
            {
                //Debug.Log("L");
                ccSO.LCol();
                fillImage.color = ccSO.LColor;
            }

            else if (0.24 >= fillAmount && fillAmount >= 0.01f)
            {
                //Debug.Log("LL");
                ccSO.LLCol();
                fillImage.color = ccSO.LLColor;
            }

            //  else
            // Debug.Log("Secondary O2 Error");


            if (fillAmount >= 0.009f)
                fillImage.transform.localScale = new Vector3(fillAmount, fillAmount, 1.0f);
        }
    }
}
