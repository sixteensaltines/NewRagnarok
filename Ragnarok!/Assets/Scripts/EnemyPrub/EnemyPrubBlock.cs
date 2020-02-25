using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyPrubBlock : MonoBehaviour
{
    public GameObject T_SwordLeftUP;
    public GameObject T_SwordLeftMID;

    public Transform PivotUP;
    public Transform PivotMID;

    void Start()
    {
        T_SwordLeftMID.SetActive(false);
        T_SwordLeftUP.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            T_SwordLeftUP.SetActive(true);
            Invoke("ATACKLEFTUP", 1f);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            T_SwordLeftMID.SetActive(true);
            Invoke("ATACKLEFTMID", 1f);
        }
    }
    void ATACKLEFTUP()
    {
        PivotUP.transform.localRotation = new Quaternion(0, 0,- 76.591f, 0);
        Invoke("OFFLEFTUP", 0.5f);
    }
    void OFFLEFTUP()
    {
        T_SwordLeftUP.SetActive(false);
        PivotUP.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
    void ATACKLEFTMID()
    {
        PivotMID.transform.localRotation = new Quaternion(0, 0, -124.459f, 0);
        Invoke("OFFLEFTMID", 0.5f);
    }
    void OFFLEFTMID()
    {
        T_SwordLeftMID.SetActive(false);
        PivotMID.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }
}
