using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChild : MonoBehaviour
{
    AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        StartCoroutine(waitSoundDone());
    }
    IEnumerator waitSoundDone()
    {
        yield return new WaitUntil(() =>!_audioSource.isPlaying);
        gameObject.SetActive(false);
    }
}
