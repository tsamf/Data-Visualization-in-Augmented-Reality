using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class window : MonoBehaviour
{
    public Rect windowRect = new Rect(0, 0, 120, 60);
    void OnGUI()
    {
        windowRect = GUI.Window(0, windowRect, DoMyWindow, "TASK");
    }
    void DoMyWindow(int windowID)
    {
        GUI.DragWindow();
    }
}

