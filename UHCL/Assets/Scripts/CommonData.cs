using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonData : MonoBehaviour {


    //The common data  (flags and alarm definitions will go here)

    private bool editMode = false;

	public bool EditMode { get { return editMode; } set { editMode = value; } }

}
