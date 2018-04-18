using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUI_WarningWindow : MonoBehaviour {

    public GameObject bl_main;
    public GameObject warningDetailPanel;
    public Text prevwarning;
    public Text currentwarning;
    public Text nextwarning;
  


	// Use this for initialization
	void Start () {

        warningDetailPanel.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
