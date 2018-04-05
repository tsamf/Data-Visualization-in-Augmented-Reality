using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BL_Tasks : MonoBehaviour {

    private CommonData commonData = CommonData.GetInstance();

    public string[] PREVIOUS;
    public string[] CURRENT;
    public string[] NEXT;
    public int index;
    public int count;

    public void DisablingAlarmingNext(
        string[] PREVIOUS,
        string[] CURRENT,
        string[] NEXT,
        bool Flag,
        int index
        )
    {

        if (index <= count)
        {
            if (Flag == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    PREVIOUS[i] = CURRENT[i];
                    CURRENT[i] = NEXT[i];
                    NEXT[i] = commonData.TASK_TABLE[index + 1][i];
                }
                index = int.Parse(CURRENT[0]);
            }
        }
        else
        {
            Debug.Log("NO MORE NEXT STEP");
        }
    }

    public void DisablingAlarmingPrevious(
        string[] PREVIOUS,
        string[] CURRENT,
        string[] NEXT,
        bool Flag,
        int index
        )
    {

        if (index >= 0)
        {
            if (Flag == true)
            {
                for (int i = 0; i < 5; i++)
                {
                    NEXT[i] = CURRENT[i];
                    CURRENT[i] = PREVIOUS[i];
                    PREVIOUS[i] = commonData.TASK_TABLE[index - 1][i];
                }
                index = int.Parse(CURRENT[0]);
            }
        }
        else
        {
            Debug.Log("NO MORE PREVIOUS STEP");
        }
    }



    // Use this for initialization
    void Start()
    {

        count = commonData.TASK_TABLE.Length;

        for (int i = 0; i < 6; i++)
        {
            PREVIOUS[i] = "";
            CURRENT[i] = commonData.TASK_TABLE[0][i];
            NEXT[i] = commonData.TASK_TABLE[1][i];
        }
        index = int.Parse(CURRENT[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
