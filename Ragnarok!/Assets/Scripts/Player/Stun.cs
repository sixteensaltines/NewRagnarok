using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    public float TimeNoStuned;

    public Inputs En_Inputs;

    public void StunAction()
    {
            En_Inputs.BlockButtons = true;
            Invoke("NoStuned", TimeNoStuned);
    }
    public void NoStuned()
    {
        En_Inputs.BlockButtons = false;
    }
}
