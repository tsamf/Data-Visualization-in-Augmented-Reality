using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpdateSettings : MonoBehaviour {


    public Text dropDownText;
    public Toggle uiToggle;
    FlagStore store = FlagStore.GetInstance();

	public void UpdateAndChangeScenes()
    {
        store.userID = int.Parse(dropDownText.text);
        store.pieUI = uiToggle.isOn;

        SceneManager.LoadScene(1);
    }
}
