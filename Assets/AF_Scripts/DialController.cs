using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialController : MonoBehaviour
{
    public int _dialState = 0;
    public GameObject _dialObj;
    private RectTransform dialTransform;
    public AudioClip _dialSound;
    public AudioSource _sndToPlay;
    public bool _isPlayActive = false;
    public GameObject _levelPanel;
    public GameObject _titleText;
    public GameObject _creditsText;

    [Header("levels")]
    public RectTransform[] Levels;
    //public RectTransform level1;
    //public RectTransform level2;
    //public RectTransform level3;
    //public RectTransform level4;
    //public RectTransform level5;
    //public RectTransform level6;

    public Color activeColor;
    public Color normalColor;

    private RectTransform lastActiveButton;

    // Update is called once per frame
    private void Start()
    {
        dialTransform = _dialObj.GetComponent<RectTransform>();
    }
    void Update()
    {   
        if (_levelPanel.activeInHierarchy == false)
            _isPlayActive = false;
    }
    public void OnPressPLay()
    {
        if(_isPlayActive == true)
        {
            if (_dialState == 0)
                SceneManager.LoadScene(1);
            else if (_dialState == 1)
                SceneManager.LoadScene(2);
            else if (_dialState == 2)
                SceneManager.LoadScene(3);
            else if (_dialState == 3)
                SceneManager.LoadScene(4);
            else if (_dialState == 4)
                SceneManager.LoadScene(5);
            else if (_dialState == 5)
                SceneManager.LoadScene(6);
        }
        else
        {
            _isPlayActive = !_isPlayActive;
        }

        if (_isPlayActive == true)
        {
            _levelPanel.SetActive(true);
            _titleText.SetActive(false);
            _creditsText.SetActive(false);
            SetButtonActive();
        }
    }
    
    public void DialControl(int _dialRot)
    {
        if(_dialState + _dialRot == 1)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }
        else if (_dialState + _dialRot == 2)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }
        else if (_dialState + _dialRot == 3)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }
        else if (_dialState + _dialRot == 4)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }
        else if (_dialState + _dialRot == 5)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }
        else if (_dialState + _dialRot == 6)
        {
            _dialState = 0;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z - 45));
            SetButtonActive();
        }

        _sndToPlay.clip = _dialSound;
        _sndToPlay.Play();
    }
    public void SetButtonActive()
    {
        Levels[_dialState].GetComponent<Image>().color = activeColor;
        if (lastActiveButton != null)
        {
            lastActiveButton.GetComponent<Image>().color = normalColor;
        }
        lastActiveButton = Levels[_dialState];
    }
}