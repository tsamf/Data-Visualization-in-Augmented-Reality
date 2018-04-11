using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculate : MonoBehaviour {
    public Text amount;
    public Text price;
    public Text total;
    public Dropdown state;
    public Text Tax;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void calc()
    {
       
        float totalCalc = float.Parse(amount.text) * float.Parse(price.text);
        
        int indexdd = state.value;
        
        string ddtext = state.options[indexdd].text;


        if(totalCalc >= 50000f)
        {
            totalCalc -= .15f * totalCalc;
        }
        else if ( totalCalc  >= 10000f)
        {
            totalCalc -= .10f * totalCalc;
        }
        else if (totalCalc >= 7000f)
        {
            totalCalc -= .07f * totalCalc;
        }
        else if (totalCalc >= 5000f)
        {
            totalCalc -= .05f * totalCalc;
        }
        else if (totalCalc >= 1000f)
        {
            totalCalc -= .03f * totalCalc;
        }


        switch (ddtext)
        {
            case "UT":
                {
                    Tax.text = (totalCalc * .0685f).ToString();
                    totalCalc = totalCalc + totalCalc * .0685f;
                    break;
                }
            case "NV":
                {
                    Tax.text = (totalCalc * .08f).ToString();
                    totalCalc = totalCalc + totalCalc * .08f;
                    break;
                }
            case "TX":
                {
                    Tax.text = (totalCalc * .0625f).ToString();
                    totalCalc = totalCalc + totalCalc * .0625f;
                    break;
                }
            case "AL":
                {
                    Tax.text = (totalCalc * .04f).ToString();
                    totalCalc = totalCalc + totalCalc * .04f;
                    break;
                }
            case "CA":
                {
                    Tax.text = (totalCalc * .0825f).ToString();
                    totalCalc = totalCalc + totalCalc * .0825f;
                    break;
                }
            case "AK":
                {
                    Tax.text = (0.0).ToString();
                    break;
                }
            case "AR":
                {
                    Tax.text = (totalCalc * .065f).ToString();
                    totalCalc = totalCalc + totalCalc * .065f;
                    break;
                }
            case "AZ":
                {
                    Tax.text = (totalCalc * .056f).ToString();
                    totalCalc = totalCalc + totalCalc * .056f;
                    break;
                }
            case "CO":
                {
                    Tax.text = (totalCalc * .029f).ToString();
                    totalCalc = totalCalc + totalCalc * .029f;
                    break;
                }
            case "CT":
                {
                    Tax.text = (totalCalc * .029f).ToString();
                    totalCalc = totalCalc + totalCalc * .029f;
                    break;
                }
        }

       

        total.text = totalCalc.ToString();
    } 
}
