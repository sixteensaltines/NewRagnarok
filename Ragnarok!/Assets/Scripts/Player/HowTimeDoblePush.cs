using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowTimeDoblePush : MonoBehaviour
{
    public float Counter = 0.0f;
    public bool DoublePush = false;
    public bool FirstPush = true;
    public bool IniciateCounter;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&&!DoublePush)
        {
            IniciateCounter = true;
            FirstPush = false;
        }
        if (IniciateCounter)
        {
            Counter += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.P) && !FirstPush)
        {
            DoublePush = true;
            IniciateCounter = false;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            DoublePush = false;
            Counter = 0f;
            FirstPush = true;

        }
    }
}
