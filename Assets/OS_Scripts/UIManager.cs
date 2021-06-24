using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{
    public enum ButtonID
    {
        def,
        D1,
        D2,
        D3,
        D4,
        D5,
        O1,
        O2,
        O3,
        O4
    }

    public class UIManager : MonoBehaviour
    {
        public GameObject Character;
        private RemoteControl CharacterComponent;

        public List<GameObject> buttons = new List<GameObject>();

        // Start is called before the first frame update
        void Start()
        {
            CharacterComponent = Character.GetComponent<RemoteControl>();
        }

        // Update is called once per frame
        void Update()
        {
            ButtonID CurrentButton;
            CurrentButton = 0;

            foreach (GameObject eachobject in buttons)
            {
                Button cur = eachobject.GetComponent<Button>();
                if (cur.GetPressed() == true)
                {
                    CurrentButton = cur.GetButtonID();
                }
            }

            if (CurrentButton != 0)
            {
                switch (CurrentButton)
                {
                    case ButtonID.D1:
                        {
                            CharacterComponent.Up();
                            break;
                        }


                }
            }

        }
    }
}