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

    public float CastDist;

    public RaycastHit2D hit;
    private void Start()
    {

    }
    void Update()
    {
        WhereIsShield();
        Picking();
        DrawRay();

    }
    void WhereIsShield()
    {
        if (En_Inputs.B_Block)
        {
            if (En_Inputs.B_Block && En_Inputs.B_GuardMid)
            {
                BlockMid();              
            }
            if (En_Inputs.B_Block && En_Inputs.B_GuardUp)
            {
                BlockUp();
            }
            //TODO: Falta Control de block por atras. 
        }
        //default IdleShield
    }
    void BlockMid()
    {
        
    }
    void BlockUp()
    {
        
    }
    void BlockBack()
    {
        
    }
    void Picking()
    {
        V_Centro = new Vector2(T_Centro.position.x, T_Centro.position.y);
        V_FrontMIDRay = new Vector2(T_FrontMIDRay.position.x, T_FrontMIDRay.position.y);
        V_FrontUPRay = T_FrontUPRay.position;
        V_BackRay = T_BackRay.position;

        hit = Physics2D.Linecast(V_Centro, V_FrontMIDRay , 1 << LayerMask.NameToLayer("Action"));

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
            Debug.DrawLine(V_Centro, V_FrontMIDRay, Color.blue);
        }
    }
}
