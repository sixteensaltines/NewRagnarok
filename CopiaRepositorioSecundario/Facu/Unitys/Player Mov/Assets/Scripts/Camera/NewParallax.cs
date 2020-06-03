using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParallax : MonoBehaviour
{
    [SerializeField]
    private Vector2 v_ParallaxMultipler;

    public Transform T_CameraTransform;

    private Vector3 v_LastCameraPosition;

    private void Start()
    {
        v_LastCameraPosition = T_CameraTransform.position;
    }
    void LateUpdate()
    {
        Vector3 v_DeltaMovement = T_CameraTransform.position - v_LastCameraPosition;
        transform.position += new Vector3(v_DeltaMovement.x * v_ParallaxMultipler.x, v_DeltaMovement.y * v_ParallaxMultipler.y);
        v_LastCameraPosition = T_CameraTransform.position;
    }
}
