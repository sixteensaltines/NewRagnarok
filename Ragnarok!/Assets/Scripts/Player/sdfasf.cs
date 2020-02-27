using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sdfasf : MonoBehaviour
{
    
    public Inputs En_Inputs;

    public Transform T_Centro;
    public Transform T_FrontMIDRay;
    public Transform T_FrontUPRay;
    public Transform T_BackRay;

    private Vector2 V_Centro;
    private Vector2 V_FrontMIDRay;
    private Vector2 V_FrontUPRay;
    private Vector2 V_BackRay;

    private Vector2 Rayito;

    public float CastDist;

    public RaycastHit2D hit;

    //ShieldFront
    public float CountHold;
    public bool ActiveCountDown;
    public float CountTimeDown;
    public bool FrontActive;

    //ShieldBack
    public bool FirstPush = true;
    public bool WaitSecondPush;
    public bool SecondPush;
    public bool BlockBack;

    private bool CountBackActive;
    public float CountTimeDownBack;
    public float CountTimeBack;
    private bool CancelShieldBack;

    void Update()
    {
        V_Centro = new Vector2(T_Centro.position.x, T_Centro.position.y);

        WhereIsShield();

        //EN CASO DE QUE LO STUNEEN (ROMPAN DEFENSA)
        /*void Update()
         * {
         *  * if(BreakDefense)
         *      {
         *      Stun.Stuned = true;
         *      En_Inputs.BlockButtons = true;
         *      invoke("Restore",1f)
         *      }
         * }
         * void Restore()
         * {
         *      Stun.Stuned=false;
         *      En_Inputs.BlockButtons = false;
         * }
        */
    }
    void WhereIsShield()
    {

        if (En_Inputs.BH_Block)
        {
            ActiveCountDown = true;

            if (SecondPush)
            {
                CountBackActive = false;

                if (!CancelShieldBack)
                {
                    BlockBack = true;

                    Rayito = new Vector2(T_BackRay.position.x, T_BackRay.position.y);

                    Picking();
                    DrawRay();
                }
            }

            CounterShield();

            if (FrontActive && !BlockBack)
            {
                if (En_Inputs.BH_Block && En_Inputs.B_GuardMid)
                {
                    Rayito = new Vector2(T_FrontMIDRay.position.x, T_FrontMIDRay.position.y);
                }
                if (En_Inputs.BH_Block && En_Inputs.B_GuardUp)
                {
                    Rayito = new Vector2(T_FrontUPRay.position.x, T_FrontUPRay.position.y);
                }
                Picking();
                DrawRay();
            }
        }
        else
        {
            CountTimeDown = CountHold;
            ActiveCountDown = false;
            FrontActive = false;

            //default IdleShield
        }
        if (En_Inputs.BD_Block)
        {
            if (FirstPush && En_Inputs.B_PlayMode)
            {
                WaitSecondPush = true;
                CountBackActive = true;
                CancelShieldBack = false;
                FirstPush = false;
                CountTimeDownBack = CountTimeBack;

            }
        }
        if (En_Inputs.BU_Block)
        {
            if (WaitSecondPush)
            {
                SecondPush = true;
                WaitSecondPush = false;
            }
            if (En_Inputs.BU_Block && BlockBack)
            {
                FirstPush = true;
                SecondPush = false;
                WaitSecondPush = false;
                BlockBack = false;
                CancelShieldBack = true;
            }

        }

    }
    void CounterShield()
    {
        //CounterFront
        if (ActiveCountDown)
        {
            CountTimeDown -= Time.deltaTime;
        }
        if (CountTimeDown <= 0)
        {
            FrontActive = true;
        }
        //CounterBack
        if (CountBackActive)
        {
            CountTimeDownBack -= Time.deltaTime;
        }
        if (CountTimeDownBack <= 0)
        {
            CancelShieldBack = true;
            CountBackActive = false;

            FirstPush = true;
            SecondPush = false;
            WaitSecondPush = false;
            BlockBack = false;

        }
    }
    void Picking()
    {
        hit = Physics2D.Linecast(V_Centro, Rayito, 1 << LayerMask.NameToLayer("Action"));

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Enemy"))
            {
                //AccionAGolpeEnemigo
            }
            else
            {
                //AccionAGolpeEnemigo
            }
        }
    }
    void DrawRay()
    {
        if (hit.collider != null)
        {
            Debug.DrawLine(T_Centro.position, hit.point, Color.green);
        }
        else
        {
            Debug.DrawLine(V_Centro, Rayito, Color.blue);
        }
    }
}

