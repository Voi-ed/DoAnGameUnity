using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCotroller : MonoBehaviour
{
    Transform Target;
    Vector3 velocity = Vector3.zero;
    public Vector3 PositionOffset;
    [Range(0, 1)]
    public float smoothTime;
    [Header("Axis Limitaction")]
    public Vector2 XLimit;
    public Vector2 YLimit;
    
    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;


    }
    private void LateUpdate()
    {
        Vector3 TargetPosition = Target.position+PositionOffset;
        TargetPosition = new Vector3(Mathf.Clamp(TargetPosition.x, XLimit.x, XLimit.y), Mathf.Clamp(TargetPosition.y, YLimit.x, YLimit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position,TargetPosition,ref velocity,smoothTime);
    }
}
