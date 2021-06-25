using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject _titleObj;
    public GameObject _creditsObj;
    public GameObject _levelsObj;
    public DialController _dialStateReset;
    public AudioSource _sndToPlay;
    public AudioClip[] _audButton;
    // Start is called before the first frame update
    public void OnBButtonClick()
    {
        _titleObj.SetActive(true);
        _creditsObj.SetActive(false);
        _levelsObj.SetActive(false);
        _dialStateReset._dialState = 0;

        _sndToPlay.clip = _audButton[Random.Range(0, _audButton.Length)];
        _sndToPlay.Play();
    }
}
