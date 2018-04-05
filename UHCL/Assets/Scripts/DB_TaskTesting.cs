using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_TaskTesting : MonoBehaviour {

    private Procedure procedure;

	void Awake () {
        procedure = new Procedure();
        UITask task1 = new UITask();
        task1.stepNumber = 1;
        task1.text = "On the RIGHT side of the EVA Kit, locate the PANEL ACCESS KEY.";
        task1.caution = "The keys are on a tension-spring cable.";
        task1.warning = " ";
        task1.holograms = " ";
        task1.images = " ";
        UITask task2 = new UITask();
        task2.stepNumber = 2 ;
        task2.text = "Use the PANEL ACCESS KEY to unlock the PANEL ACCESS DOOR LOCKS.";
        task2.caution = "";
        task2.warning = " ";
        task2.holograms = " ";
        task2.images = " ";
        UITask task3 = new UITask();
        task3.stepNumber = 3 ;
        task3.text = "Carefully return keys to the side of the EVA kit.";
        task3.caution = "";
        task3.warning = " ";
        task3.holograms = " ";
        task3.images = " ";
        UITask task4 = new UITask();
        task4.stepNumber = 4;
        task4.text = "Insert your fingers in the CENTER OPENING and secure the PANEL ACCESS DOOR in an OPEN position.";
        task4.caution = "";
        task4.warning = "Door can accidentally close ";
        task4.holograms = " ";
        task4.images = " ";
        UITask task5 = new UITask();
        task5.stepNumber = 5;
        task5.text = "On your belt, use the BLUE CARABINEER to securely tether to the TETHER CABLE inside the STORAGE.";
        task5.caution = "Notice the TETHER CABLE is adjustable";
        task5.warning = " ";
        task5.holograms = " ";
        task5.images = " ";






        procedure.tasks.Add(task1);
        procedure.tasks.Add(task2);
        procedure.tasks.Add(task3);
        procedure.tasks.Add(task4);
        procedure.tasks.Add(task5);
	}

    public Procedure GetProcedure()
    {
        return procedure;
    }
}

public class UITask
{
    public int stepNumber;
    public string text = "";
    public string caution = "";
    public string warning = "";
    public string holograms = "";
    public string images = "";
}

public class Procedure
{
    public List<UITask> tasks;

    public Procedure()
    {
        tasks = new List<UITask>();
    }
}

