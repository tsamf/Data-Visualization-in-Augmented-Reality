using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayDetails : MonoBehaviour
{
    public GameObject displaywindow;
    public Text title;
    public Text content;

    public void Display(string header, string values)
    {
        title.text = header;
        content.text = values;
        displaywindow.SetActive(true);
    }

    void Start()
    {
       // PopulateList();
    }

   /* void PopulateList()
    {
        dropdown.AddOptions(names);
    }*/
}
