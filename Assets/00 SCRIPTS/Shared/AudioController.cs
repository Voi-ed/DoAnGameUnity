using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SingleTon<AudioController>
{
    [SerializeField] AudioSource _audioChildPrefab;
    [SerializeField] List<AudioClip> _audioClips = new List<AudioClip>();
    List<AudioSource> _audioSources = new List<AudioSource>();
    bool isSound = true;
    private void Start()
    {
        isSound = PlayerPrefs.GetInt("SOUND", 1) ==1 ? true : false;
    }
    public void setSound(bool IsSound)
    {
        this.isSound = IsSound;
        PlayerPrefs.SetInt("SOUND", IsSound ? 1 : 0);
        if (!this.isSound)
        {
            foreach(AudioSource a in _audioSources)
            {
                a.Stop();
            }

        }
    }
    public  void playSound(string nameSound)
    {
        if (!isSound) return;
        AudioClip audioClip = null;
        foreach(AudioClip a in _audioClips)
        {
            if (a.name.ToLower().Equals(nameSound.ToLower()))
            {
                audioClip = a; break;
            }
        }
        if (audioClip == null)
        {
            Debug.LogError("Sound " + nameSound + " not exist");
            return;
        }
        AudioSource sourceSound = null;
        foreach (AudioSource Source in _audioSources)
        {
            if (Source.gameObject.activeSelf)
            {
                continue;
            }
            sourceSound = Source;
        }
       if(sourceSound == null)
        {
            sourceSound = Instantiate<AudioSource>(_audioChildPrefab, this.transform.position,
            Quaternion.identity, this.transform);
            _audioSources.Add(sourceSound);
        }
        sourceSound.gameObject.SetActive(false);
        sourceSound.clip = audioClip;
        sourceSound.gameObject.SetActive(true);
    } 
}
