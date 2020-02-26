using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour
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

    /*public bool ShieldActive;
    public bool YaActivo;
    public float TimeActiveShield;*/
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

        if (En_Inputs.B_Block)
        {
            /*if (!YaActivo)
            {
                Invoke("ActiveShield", TimeActiveShield);
            }*/


            //if (ShieldActive)
            //{
                //YaActivo = true;
                if (En_Inputs.B_Block && En_Inputs.B_GuardMid)
                {
                    Rayito = new Vector2(T_FrontMIDRay.position.x, T_FrontMIDRay.position.y);
                }
                if (En_Inputs.B_Block && En_Inputs.B_GuardUp)
                {
                    Rayito = new Vector2(T_FrontUPRay.position.x, T_FrontUPRay.position.y);
                }
                Picking();
                DrawRay();
            //}

            //TODO: Falta Control de block por atras. 
        }
        else
        {
            /*ShieldActive = false;
            YaActivo = false;*/
        }
        //default IdleShield
    }

    /*void BlockBack()
    {
        V_BackRay = new Vector2(T_BackRay.position.x, T_BackRay.position.y);
    }*/
    void Picking()
    {
        hit = Physics2D.Linecast(V_Centro, Rayito , 1 << LayerMask.NameToLayer("Action"));

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
    /*void ActiveShield()
    {
        ShieldActive = true;
    }*/
}
