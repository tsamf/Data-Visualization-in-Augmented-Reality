using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EmergencyWindow : MonoBehaviour {

    public GameObject window;
    public Text messageField;

    //Show(string)
    // Displays the indicated emergency nessage in the pop-up window
    public void Show (string message)
    {
        //messageField.text = message;
       // window.SetActive(true);
    }

    // Hide Window
    //Closes the pop-up window
    /* public void Hide()
     * {
     * window.setActive(false);
     * } */
}
