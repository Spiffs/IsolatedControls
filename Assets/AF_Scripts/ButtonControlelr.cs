using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlelr : MonoBehaviour
{
    public GameObject _creditsText;
    public GameObject _titleText;
    public bool _creditOn = false;
    public AudioClip[] _audButton;
    public AudioSource _sndToPlay;
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPress(int _btnPress)
    {
        if (_btnPress == 1)
            Application.Quit();
        if (_btnPress == 2 && _creditOn == false)
        {
            _creditsText.SetActive(true);
            _titleText.SetActive(false);
            _creditOn = true;
        }
        else if ((_btnPress == 2) && (_creditOn == true))
        {
           _creditsText.SetActive(false);
           _titleText.SetActive(true);
           _creditOn = false;
        }
        _sndToPlay.clip = _audButton[Random.Range(0, _audButton.Length)];
        _sndToPlay.Play();
    }
}
