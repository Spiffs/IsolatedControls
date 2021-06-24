using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialController : MonoBehaviour
{
    public int _dialState = 0;
    public GameObject _dialObj;
    private RectTransform dialTransform;
    public AudioClip _dialSound;
    public AudioSource _sndToPlay;
    public bool _isPlayActive = false;
    public Sprite[] _levels;

    [Header("levels")]
    public GameObject Level1;
    
    // Update is called once per frame
    private void Start()
    {
        dialTransform = _dialObj.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (_isPlayActive == true)
        {

        }
        else if(_isPlayActive == false)
        {

        }
    }
    public void OnPressPLay()
    {
  
    }
    
    public void DialControl(int _dialRot)
    {
        if(_dialState + _dialRot == 1)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z + 45));
        }
        else if (_dialState + _dialRot == 2)
        {
            _dialState += 1;
            dialTransform.Rotate(new Vector3(0, 0, dialTransform.rotation.z + 45));
        }
        _sndToPlay.clip = _dialSound;
        _sndToPlay.Play();
    }
}
