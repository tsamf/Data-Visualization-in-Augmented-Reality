using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIUpdates : MonoBehaviour {

    public GameObject detailedPie;
    CommonData commonData = CommonData.GetInstance();

    // Use this for initialization
    void Start () {
        detailedPie.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        UpdateDetailPiePanel();
    }

    void UpdateDetailPiePanel()
    {
        if (commonData.viewPieDetails)
        {
            detailedPie.SetActive(true);
        }
    }
}
