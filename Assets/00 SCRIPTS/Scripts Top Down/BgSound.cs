using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgSound : MonoBehaviour
{
    private void Start()
    {
        AudioController.Instant.playSound("BGM_01");
        StartCoroutine(SoundBg());
    }
    IEnumerator SoundBg()
    {
       
        yield return new WaitForSeconds(69);
        AudioController.Instant.playSound("BGM_01");
    }
}
       
