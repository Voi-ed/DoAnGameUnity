using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T>: MonoBehaviour where T : MonoBehaviour
{
    private static T _instant = null;
    public static T Instant => _instant;

    private void Awake()
    {
        if(_instant == null)
        {
            _instant= this.GetComponent<T>();
            return;
        }
        if(_instant.gameObject.GetInstanceID()!= this.GetInstanceID())
        {
            Destroy(this.gameObject);
        }
    }
}
