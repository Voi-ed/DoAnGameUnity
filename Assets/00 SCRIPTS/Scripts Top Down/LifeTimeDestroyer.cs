using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroyer : MonoBehaviour
{
    public float time;
    void Start()
    {
        Destroy(gameObject,time);
    }

}
