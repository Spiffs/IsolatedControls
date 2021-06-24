//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public class ControlPanel : MonoBehaviour
//{
//    // character object
//    public GameObject Character;

//    // panel rotation management, decided by quadrent 
//    private int CurrentRotation = 1;
//    /*  
//        quadrents:
         
//    */

//    // parent control panel object 
//    [SerializeField]
//    private GameObject ControlPanelObject;

//    // list of buttons
//    private List<List<Transform>> Buttons;

//    // texture for each button color 
//    [SerializeField]
//    private Texture2D ButtonOff;

//    [SerializeField]
//    private Texture2D ButtonOn;

//    [SerializeField]
//    private Texture2D ButtonRed;

//    [SerializeField]
//    private Texture2D ButtonBlue;


//    void Start()
//    {
//        Buttons = new List<List<Transform>>();

//        for (int i = 0; i < ControlPanelObject.transform.childCount; i++)
//        {
//            Transform CurRow = ControlPanelObject.transform.GetChild(i);
//            for (int x = 0; x < CurRow.childCount; x++)
//            {
//                Transform curButon = CurRow.GetChild(x);
//                curButon.GetComponent<Button>().SetControlPanelBrain(transform.gameObject);
//                curButon.GetComponent<Button>().SetPanelPosition((char)(i + 65), (x + 1));
//                Buttons[i].Add(curButon);
//            }
//        }
//    }


//    void Update()
//    {
                
//    }
//}
