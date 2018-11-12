using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public void CreateTutorial()
    {
        EVAProcedure tutorialProcedure = new EVAProcedure();

        EVATask task1 = new EVATask(1, 0, "Welcome to the EVA project tutorial. Say next step.", "You should be able to read this.", "", "", "");

        //Going over the UI
        EVATask task2 = new EVATask(2, 0, "First, we will go over the basics of the User Interface. Say next step.", "", "", "","");
        EVATask task3 = new EVATask(3, 0, "In the bottom left is the consumables display. This display needs to be monitored throughout the experiment.  Say next step.", "", "", "", "");
        EVATask task4 = new EVATask(4, 0, "In the bottom center there is a text display that will display the last recognized voice command or voice command error. Say next step.");
        EVATask task5 = new EVATask(5, 0, "In the center right of the screen is the step list. It displays the text of the previous, current, and next step. Say next step.");
        EVATask task6 = new EVATask(6, 0, "In the top right of the display is an image that corresponds to the current step. Say next step.","","","","2");
        EVATask task7 = new EVATask(7, 0, "In the top middle is the caution message for the step, it will appear in yellow. Say next step.", "Sample caution text");
        EVATask task8 = new EVATask(8, 0, "In the top middle there is also a warning message, it will appear in red. Say next step.", "", "Sample warning text");

        //Task commands
        EVATask task9 = new EVATask(9, 0, "Navigating the step list can be done with a series of voice commands. Say next step.");
        EVATask task10 = new EVATask(10, 0, "A step can be repeated by saying repeat step. Say repeat step. When done say next step to continue.");
        EVATask task11 = new EVATask(11, 0, "You can go back a step by saying previous step. Say next step.");

        //Holograms
        EVATask task12 = new EVATask(12, 0, "We will now go over each hologram in the EVA kit. You will be shown each hologram in the box. Say next step.");
        EVATask task13 = new EVATask(13, 0, "Locate the Auxilary power input hologram and then say next step.", "", "", "Aux_PowerInput");
        EVATask task14 = new EVATask(14, 0, "Locate the Bus Bars hologram and then say next step.", "", "", "BusBars");
        EVATask task15 = new EVATask(15, 0, "Locate the Indicator Box hologram and then say next step.", "", "", "IndicatorBox");
        EVATask task16 = new EVATask(16, 0, "Locate the Fusible Disconnect Box hologram and then say next step.", "", "", "FusibleDisconnectBox");
        EVATask task17 = new EVATask(17, 0, "Locate the Power Box hologram and then say next step.", "", "", "PowerBox");
        EVATask task18 = new EVATask(18, 0, "Locate the Power Output Box hologram and then say next step.", "", "", "PowerOutputBox");
        EVATask task19 = new EVATask(19, 0, "Locate the E Stop hologram and then say next step.", "", "", "E-Stop");

        //Clearing a warning
        EVATask task20 = new EVATask(20, 0, "Now we will walk through resetting an out of range value. Say next step.");
        EVATask task21 = new EVATask(21, 0, "It is important that you reset a value as soon as you see it go out of range to maintain your health. Say next step.");
        EVATask task22 = new EVATask(22, 0, "If you look in the bottom left the pressure value has gone out of range. Say Show Details.");
        EVATask task23 = new EVATask(23, 0, "Remember these values must be monitored closely. When out of range say show details, reset value name, close details, and then continue. Say next step.");
        EVATask task24 = new EVATask(24, 0, "This concludes the tutorial. If you have any questions ask now, otherwise, say next step.");

        EVATask task100 = new EVATask(100, 0, "Say start to begin the activity.", "", "", "", "");

        tutorialProcedure.AddTask(task1);

        //Going over the UI
        tutorialProcedure.AddTask(task2);
        tutorialProcedure.AddTask(task3);
        tutorialProcedure.AddTask(task4);
        tutorialProcedure.AddTask(task5);
        tutorialProcedure.AddTask(task6);
        tutorialProcedure.AddTask(task7);
        tutorialProcedure.AddTask(task8);

        //Task commands
        tutorialProcedure.AddTask(task9);
        tutorialProcedure.AddTask(task10);
        tutorialProcedure.AddTask(task11);

        //Holograms
        tutorialProcedure.AddTask(task12);
        tutorialProcedure.AddTask(task13);
        tutorialProcedure.AddTask(task14);
        tutorialProcedure.AddTask(task15);
        tutorialProcedure.AddTask(task16);
        tutorialProcedure.AddTask(task17);
        tutorialProcedure.AddTask(task18);
        tutorialProcedure.AddTask(task19);

        //Resetting out of range values
        tutorialProcedure.AddTask(task20);
        tutorialProcedure.AddTask(task21);
        tutorialProcedure.AddTask(task22);
        tutorialProcedure.AddTask(task23);
        tutorialProcedure.AddTask(task24);

        tutorialProcedure.AddTask(task100);

        Activity.GetInstance().SetProcedures(new List<EVAProcedure>() { tutorialProcedure });

    }
}
