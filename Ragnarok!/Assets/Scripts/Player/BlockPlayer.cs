using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    public Inputs En_Inputs;

    public Transform Pivot;
    public Transform Shield;

    Vector3 V_PositionShieldRest = new Vector3 (-0.306f,0.107f,0f);
    Quaternion Q_ShieldRotationRest = new Quaternion(0, 0, 0, 0);

    Vector3 V_PositionShieldOpen = new Vector3(-0.545f, 0.107f, 0);

    Quaternion Q_RotationShieldFrontMID = new Quaternion(0, 0, -180, 0);
    Quaternion Q_RotationShieldFrontUP = new Quaternion(0, 0, -154, 0);
    Quaternion Q_RotationShieldBackMID = new Quaternion(0, 0, 0, 0);
    Quaternion Q_RotationShieldBackUP = new Quaternion(0, 0, -19, 0);


    bool YaBlockFrontMID;
    bool YaBlockFrontUP;

    void Update()
    {
        if (En_Inputs.B_Block)
        {
            if (En_Inputs.B_PlayMode)
            {
                BlockGuard();
            }
            else
            {
                BlockFrontMID();
            }
        }
        else
        {
            Shield.transform.localPosition = V_PositionShieldRest;
            Pivot.transform.localRotation = Q_ShieldRotationRest;
            YaBlockFrontMID = false;
        }

    }
    void BlockGuard()
    {
        if (En_Inputs.B_GuardMid)
        {
            YaBlockFrontUP = false;
            BlockFrontMID();
        }
        if (En_Inputs.B_GuardUp)
        {
            YaBlockFrontMID = false;
            BlockFrontUP();
        }
    }
    void BlockFrontMID()
    {
        if (!YaBlockFrontMID)
        {
            Invoke("AnimationBlockFrontMID", 0.30f);
        }
    }
    void AnimationBlockFrontMID()
    {
        Shield.transform.localPosition = V_PositionShieldOpen;
        Pivot.transform.localRotation = Q_RotationShieldFrontMID;
        YaBlockFrontMID = true;
    }
    void BlockFrontUP()
    {
        if (!YaBlockFrontUP)
        {
            Invoke("AnimationBlockFrontUP", 0.30f);
        }
    }
    void AnimationBlockFrontUP()
    {
        Shield.transform.localPosition = V_PositionShieldOpen;
        Pivot.transform.localRotation = Q_RotationShieldFrontUP;
        YaBlockFrontUP = true;
    }
}
