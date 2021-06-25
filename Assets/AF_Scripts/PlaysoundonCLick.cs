using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaysoundonCLick : MonoBehaviour
{
    public AudioClip[] _sound;
    public AudioSource _sndToPlay;

    public void OnObjectClick()
    {
        _sndToPlay.clip = _sound[Random.Range(0, _sound.Length)];
        _sndToPlay.Play();
    }
}
