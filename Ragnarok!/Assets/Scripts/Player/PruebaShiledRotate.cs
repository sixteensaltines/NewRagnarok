using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaShiledRotate : MonoBehaviour
{
    public Inputs En_Inputs;
    private void Update()
    {
        if (!En_Inputs.B_PlayMode)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }

    }

}
