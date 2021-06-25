using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SMokeTap : MonoBehaviour
{
    //public RectTransform[] _animSprites;
    //public RectTransform _currentSprite;
    public GameObject _smokeEffect;
    public Animator _smokeAnim;
    // Start is called before the first frame update
    public void Awake()
    {
        _smokeAnim = _smokeEffect.transform.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("mouse 0"))
        {
            Debug.Log("we work");
            //_currentSprite.Image.SourceImage = _animSprites()
            var prefab = Instantiate(_smokeEffect);
            prefab.transform.GetChild(0).transform.position = Input.mousePosition;
            //_smokeEffect.GetComponent<Animator>().Play("smokeTest");
            _smokeAnim.SetTrigger("click");
            
        }

        
    }

}
