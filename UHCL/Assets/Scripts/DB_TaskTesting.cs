using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB_TaskTesting : MonoBehaviour {

    private Procedure procedure;

	void Awake () {
        procedure = new Procedure();
        Task task1 = new Task();
        task1.stepNumber = 1;
        task1.text = "On the RIGHT side of the EVA Kit, locate the PANEL ACCESS KEY.";
        task1.caution = "The keys are on a tension-spring cable.";
        task1.warning = " ";
        task1.holograms = " ";
        task1.images = " ";
        Task task2 = new Task();
        task2.stepNumber = 2 ;
        task2.text = "Use the PANEL ACCESS KEY to unlock the PANEL ACCESS DOOR LOCKS.";
        task2.caution = "";
        task2.warning = " ";
        task2.holograms = " ";
        task2.images = " ";
        Task task3 = new Task();
        task3.stepNumber = 3 ;
        task3.text = "Carefully return keys to the side of the EVA kit.";
        task3.caution = "";
        task3.warning = " ";
        task3.holograms = " ";
        task3.images = " ";
        Task task4 = new Task();
        task4.stepNumber = 4;
        task4.text = "Insert your fingers in the CENTER OPENING and secure the PANEL ACCESS DOOR in an OPEN position.";
        task4.caution = "";
        task4.warning = "Door can accidentally close ";
        task4.holograms = " ";
        task4.images = " ";
        Task task5 = new Task();
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

public class Task
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
    public List<Task> tasks;

    public Procedure()
    {
        tasks = new List<Task>();
    }
}

