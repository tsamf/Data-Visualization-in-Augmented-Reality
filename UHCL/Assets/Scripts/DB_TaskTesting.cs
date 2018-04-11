using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DB_TaskTesting : MonoBehaviour {

    CommonData commonData = CommonData.GetInstance();

    private Procedure procedure;

	void Awake () {
        procedure = new Procedure();
        UITask task1 = new UITask();
        task1.stepNumber = 1;
        task1.text = "On the RIGHT side of the EVA Kit, locate the PANEL ACCESS KEY.";
        task1.caution = "";
        task1.warning = " tension-spring cable.";
        task1.holograms = " ";
        task1.images = " ";
        UITask task2 = new UITask();
        task2.stepNumber = 2; ;
        task2.text = "Use the PANEL ACCESS KEY to unlock the PANEL ACCESS DOOR LOCKS.";
        task2.caution = "The keys are on a tension-spring cable.";
        task2.warning = " ";
        task2.holograms = " ";
        task2.images = " ";
        UITask task3 = new UITask();
        task3.stepNumber = 3 ;
        task3.text = "Carefully return keys to the side of the EVA kit.";
        task3.caution = "Door can accidentally close";
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
        UITask task6 = new UITask();
        task6.stepNumber = 6;
        task6.text = "Locate the E-stop button and gently press down to temporarily disable the alarm";
        task6.warning = " ";
        task6.holograms = "E-Stop ";
        task6.images = " ";
        UITask task7 = new UITask();
        task7.stepNumber = 7;
        task7.text = "Locate the FUSIBLE DISCONNECT box";
        task7.warning = " ";
        task7.holograms = "FusibleDisconnectBox ";
        task7.images = " ";
        UITask task8 = new UITask();
        task8.stepNumber = 8;
        task8.text = "Tether the BLUE CARABINEER to the TETHER CABLE";
        task8.warning = " ";
        task8.holograms = " ";
        task8.images = " ";
        UITask task9 = new UITask();
        task9.stepNumber = 9;
        task9.text = "Remove the BLUE CARABINEER from the FUSIBLE DISCONNECT BOX";
        task9.warning = " ";
        task9.holograms = " ";
        task9.images = " ";
        UITask task10 = new UITask();
        task10.stepNumber = 10;
        task10.text = " Transfer the BLUE CARABINEER to STORAGE";
        task10.warning = " ";
        task10.holograms = " ";
        task10.images = " ";
        UITask task11 = new UITask();
        task11.stepNumber = 11;
        task11.text = " Open the FUSIBLE DISCONNECT box and secure the lid in the open position";
        task11.caution = " Pull the locking tab towards STORAGE with the thumb ";
        task11.warning = " ";
        task11.holograms = " ";
        task11.images = " ";
        UITask task12 = new UITask();
        task12.stepNumber = 12;
        task12.text = "Locate the BLACK DISCONNECT";
        task12.warning = " ";
        task12.holograms = " ";
        task12.images = " ";
        UITask task13 = new UITask();
        task13.stepNumber = 13;
        task13.text = " Tether it to the TETHER CABLE";
        task13.warning = " ";
        task13.holograms = " ";
        task13.images = " ";
        UITask task14 = new UITask();
        task14.stepNumber = 14;
        task14.text = "Remove the DISCONNECT";
        task14.caution = " Pull up with the index and middle fingers while pushing down on the FUSE ACCESS PANEL with the thumb ";
        task14.warning = " ";
        task14.holograms = " ";
        task14.images = " ";
        UITask task15 = new UITask();
        task15.stepNumber = 15;
        task15.text = "Place the DISCONNECT in the STORAGE";
        task15.warning = " ";
        task15.holograms = " ";
        task15.images = " ";
        UITask task16 = new UITask();
        task16.stepNumber = 16;
        task16.text = "Tether the FUSE ACCESS PANEL to the TETHER CABLE";
        task16.warning = " ";
        task16.holograms = " ";
        task16.images = " ";
        UITask task17 = new UITask();
        task17.stepNumber = 17;
        task17.text = "Remove the FUSE ACCESS PANEL by pulling straght up";
        task17.warning = " ";
        task17.holograms = " ";
        task17.images = " ";
        UITask task18 = new UITask();
        task18.stepNumber = 18;
        task18.text = "Place the FUSE ACCESS PANEL into STORAGE";
        task18.warning = " ";
        task18.holograms = " ";
        task18.images = " ";
        UITask task19 = new UITask();
        task19.stepNumber = 19;
        task19.text = " Tether the ALARM FUSE to the TETHER CABLE";
        task19.warning = " ";
        task19.holograms = " ";
        task19.images = " ";
        UITask task20 = new UITask();
        task20.stepNumber = 20;
        task20.text = "In Storage, locate the BLUE FUSE PULLER";
        task20.warning = " ";
        task20.holograms = " ";
        task20.images = " ";
        UITask task21 = new UITask();
        task21.stepNumber = 21;
        task21.text = "Use the BLUE FUSE PULLER to remove ONLY the ALARM FUSE";
        task21.caution = " Rock the ALARM FUSE with the FUSE PULLER when pulling up ";
        task21.holograms = " ";
        task21.images = " ";
        UITask task22 = new UITask();
        task22.stepNumber = 22;
        task22.text = "Return the ALARM FUSE and the FUSE PULLER to STORAGE";
        task22.warning = " ";
        task22.holograms = " ";
        task22.images = " ";
        UITask task23 = new UITask();
        task23.stepNumber = 23;
        task23.text = "Locate the E-stop button and gently press down to temporarily disable the alarm";
        task23.warning = " ";
        task23.holograms = " ";
        task23.images = " ";
        UITask task24 = new UITask();
        task24.stepNumber = 24;
        task24.text = "Reinstall it into the FUSIBLE DISCONNECT BOX";
        task24.warning = " ";
        task24.holograms = " FusibleDisconnectBox ";
        task24.images = " ";
        UITask task25 = new UITask();
        task25.stepNumber = 25;
        task25.text = "Remove the FUSE ACCESS PANEL tether from the TETHER CABLE and store inside";
        task25.warning = " All tethers are under  spring tension and can retract quickly";
        task25.caution = " ";
        task25.holograms = " ";
        task25.images = " ";
        UITask task26 = new UITask();
        task26.stepNumber = 26;
        task26.text = "In STORAGE, locate the DISCONNECT";
        task26.caution = "";
        task26.warning = " ";
        task26.holograms = "FusibleDisconnectBox ";
        task26.images = " ";
        UITask task27 = new UITask();
        task27.stepNumber = 27;
        task27.text = "Reinstall it into the DISCONNECT"; ;
        task27.caution = "The DISCONNECT must read ON in the upper right corner to restore Conductivity";
        task27.warning = " ";
        task27.holograms = "FusibleDisconnectBox ";
        task27.images = " ";
        UITask task28 = new UITask();
        task28.stepNumber = 28;
        task28.text = " Remove the DISCONNECT tether from the TETHER CABLE";
        task28.caution = "";
        task28.warning = " tension-spring cable.";
        task28.holograms = " ";
        task28.images = " ";



        procedure.tasks.Add(task1);
        procedure.tasks.Add(task2);
        procedure.tasks.Add(task3);
        procedure.tasks.Add(task4);
        procedure.tasks.Add(task5);
        procedure.tasks.Add(task6);
        procedure.tasks.Add(task7);
        procedure.tasks.Add(task8);
        procedure.tasks.Add(task9);
        procedure.tasks.Add(task10);
        procedure.tasks.Add(task11);
        procedure.tasks.Add(task12);
        procedure.tasks.Add(task13);
        procedure.tasks.Add(task14);
        procedure.tasks.Add(task15);
        procedure.tasks.Add(task16);
        procedure.tasks.Add(task17);
        procedure.tasks.Add(task18);
        procedure.tasks.Add(task19);
        procedure.tasks.Add(task20);
        procedure.tasks.Add(task21);
        procedure.tasks.Add(task22);
        procedure.tasks.Add(task23);
        procedure.tasks.Add(task24);
        procedure.tasks.Add(task25);
        procedure.tasks.Add(task26);

        CommonData.GetInstance().previousTask =task6 ;
        CommonData.GetInstance().currentTask = task7;
        CommonData.GetInstance().nextTask = task8;


 



    }

    public Procedure GetProcedure()
    {
        return procedure;
    }
    
}


