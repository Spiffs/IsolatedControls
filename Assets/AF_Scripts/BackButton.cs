using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public GameObject _titleObj;
    public GameObject _creditsObj;
    public GameObject _levelsObj;
    public DialController _dialStateReset;
    // Start is called before the first frame update
    public void OnBButtonClick()
    {
        _titleObj.SetActive(true);
        _creditsObj.SetActive(false);
        _levelsObj.SetActive(false);
        _dialStateReset._dialState = 0;
    }
}
