using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableUpdater : MonoBehaviour {

    public float updateSpeed = .1f;
    public float timeSinceLastUpdate = 0;

    public DB_GenerateData pressure;
    public DB_GenerateData heartRate;
    public DB_GenerateData bodyTemp;
    public DB_GenerateData oxygen;
    public DB_GenerateData water;
    public DB_GenerateData battery;

    private int currentIndex = 0;
    private List<ConsumableLine> consumableLines;
    private FlagStore flagStore = FlagStore.GetInstance();

    // Use this for initialization
	void Start () {
        consumableLines = ConsumableDAC.LoadConsumables();
	}

    void Update () {
        if(flagStore.procedureStarted)
        {
            timeSinceLastUpdate += Time.deltaTime;

            if (timeSinceLastUpdate > updateSpeed)
            {
                //reset index when reaches end of file
                if (currentIndex >= consumableLines.Count - 1)
                {
                    currentIndex = 0;
                }

                pressure.current += consumableLines[currentIndex].pressure;
                heartRate.current += consumableLines[currentIndex].heartRate;
                bodyTemp.current += consumableLines[currentIndex].bodyTemp;
                oxygen.current += consumableLines[currentIndex].oxygen;
                water.current += consumableLines[currentIndex].water;
                battery.current += consumableLines[currentIndex].battery;

                timeSinceLastUpdate -= updateSpeed;
            }
        }
	}
}
