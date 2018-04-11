﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayDetails : MonoBehaviour
{
    List<string> names = new List<string>() { "Warning / Caution", "Oxygen Warning", "Battery Warning", "Pressure Warning" };

    public Dropdown dropdown;
    public Text selectedName;

    

    public void Dropdown_IndexChanged(int index)
    {
       if (index==1)
       {
       selectedName.text = "Warning: Check Oxygen";
       }
       else if(index == 2)
       {
       selectedName.text = "Warning: Check Battery";
       } 
       else if(index == 3)
       {
       selectedName.text = "Warning: Check Pressure";
       }
    }



    void Start()
    {
        PopulateList();
    }
  

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }


}