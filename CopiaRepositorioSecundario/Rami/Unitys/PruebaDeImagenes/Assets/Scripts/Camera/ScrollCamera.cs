using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    public Transform T_FinalPos;
    public float Speed;
    public float MaxSpeed;
    public float TimeToScroll;
    private bool onScroll;


    void Start()
    {
        Invoke("In_OnScroll", TimeToScroll);
    }

    // Update is called once per frame
    void Update()
    {


        if (onScroll)
        {
            if (Speed < MaxSpeed)
            {
                Speed += 0.1f * Time.deltaTime;
            }

            transform.position = Vector3.MoveTowards(transform.position, T_FinalPos.position, Speed * Time.deltaTime);
        }
    }
    void In_OnScroll()
    {
        onScroll = true;
    }
        
}
