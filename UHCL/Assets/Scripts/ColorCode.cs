using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCode : MonoBehaviour {

    // Use this for initialization
    public Color HHColor;
    public Color HColor;
    public Color LColor;
    public Color LLColor;

    private void Start()
    {
        HHColor = new Color(0.39f, 0.58f, 0.93f, 1.0f);
        HColor = new Color(0.49f, 0.98f, 0.6f, 1.0f);
        LColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
        LLColor = new Color(1.0f, 0.39f, 0.28f, 1.0f);
    }


    public void HHCol ()
    {
        HHColor = new Color(0.39f, 0.58f, 0.93f, 1.0f);
    }
    
    public void HCol()
    {
        HColor = new Color(0.49f, 0.98f, 0.6f, 1.0f);
    }


    public void LCol()
    {
        LColor = new Color(1.0f, 1.0f, 0.0f, 1.0f);
    }

    public void LLCol()
    {
        LLColor = new Color(1.0f, 0.39f, 0.28f, 1.0f);
    }
}
