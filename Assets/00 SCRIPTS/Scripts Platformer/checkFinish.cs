using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkFinish : MonoBehaviour
{
    [SerializeField] GameObject uIFinish;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uIFinish.SetActive(true);
            collision.gameObject.SetActive(false);
        }
    }
}
