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

    public class TextureStorageType
    {
        public Texture2D Active;
        public Texture2D Unactive;

        public TextureStorageType(Texture2D tActive, Texture2D tUnactive)
        {
            Active = tActive;
            Unactive = tUnactive;
        }
    }


    public class UIManager : MonoBehaviour
    {
        #region VARIABLES

        // character components
        [SerializeField]
        private GameObject Character;
        private RemoteControl CharacterComponent;

        // list of button object
        public List<GameObject> buttons = new List<GameObject>();

        // button textures
        [SerializeField] private Texture2D UpOn;
        [SerializeField] private Texture2D UpOff;
        [SerializeField] private Texture2D LeftOn;
        [SerializeField] private Texture2D LeftOff;
        [SerializeField] private Texture2D StopOn;
        [SerializeField] private Texture2D StopOff;
        [SerializeField] private Texture2D RightOn;
        [SerializeField] private Texture2D RightOff;
        [SerializeField] private Texture2D DownOn;
        [SerializeField] private Texture2D DownOff;
        [SerializeField] private Texture2D RedOn;
        [SerializeField] private Texture2D RedOff;
        [SerializeField] private Texture2D BlueOn;
        [SerializeField] private Texture2D BlueOff;
        [SerializeField] private Texture2D DefOn;
        [SerializeField] private Texture2D DefOff;

        // list of all textures to easily switch in a for loop
        private List<TextureStorageType> TSS; // Texture Switch Storage

        // zone profiles
        private List<Dictionary<ButtonID, bool>> ZoneProfiles; // Dicitonary<Color, Dictionary<ButtonID, Active?>>


        #endregion

        // Start is called before the first frame update
        void Start()
        {
            // get character control component
            CharacterComponent = Character.GetComponent<RemoteControl>();

            // texture storage filling 
            TSS = new List<TextureStorageType>();
            TSS.Add(new TextureStorageType(UpOn, UpOff));
            TSS.Add(new TextureStorageType(LeftOn, LeftOff));
            TSS.Add(new TextureStorageType(StopOn, StopOff));
            TSS.Add(new TextureStorageType(RightOn, RightOff));
            TSS.Add(new TextureStorageType(DownOn, DownOff));
            TSS.Add(new TextureStorageType(RedOn, RedOff));
            TSS.Add(new TextureStorageType(BlueOn, BlueOff));

            // zone profiles
            // yellow
            ZoneProfiles.Add(new Dictionary<ButtonID, bool>
            {
                {ButtonID.D1, false},
                {ButtonID.D2, true},
                {ButtonID.D3, true},
                {ButtonID.D4, true},
                {ButtonID.D5, false},
                {ButtonID.O1, true},
                {ButtonID.O2, true},
                {ButtonID.O3, false},
                {ButtonID.O4, false}
            });

            // orange
            ZoneProfiles.Add(new Dictionary<ButtonID, bool>
            {
                {ButtonID.D1, true},
                {ButtonID.D2, true},
                {ButtonID.D3, true},
                {ButtonID.D4, true},
                {ButtonID.D5, true},
                {ButtonID.O1, true},
                {ButtonID.O2, true},
                {ButtonID.O3, false},
                {ButtonID.O4, false}
            });

            // green
            ZoneProfiles.Add(new Dictionary<ButtonID, bool>
            {
                {ButtonID.D1, true},
                {ButtonID.D2, false},
                {ButtonID.D3, false},
                {ButtonID.D4, false},
                {ButtonID.D5, true},
                {ButtonID.O1, true},
                {ButtonID.O2, true},
                {ButtonID.O3, false},
                {ButtonID.O4, false}
            });

            //ZoneProfiles.Add(new Dictionary<ButtonID, bool>
            //{
            //    {ButtonID.D1, false},
            //    {ButtonID.D2, false},
            //    {ButtonID.D3, false},
            //    {ButtonID.D4, false},
            //    {ButtonID.D5, false},
            //    {ButtonID.O1, true},
            //    {ButtonID.O2, true},
            //    {ButtonID.O3, false},
            //    {ButtonID.O4, false}
            //});



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
                int iZone = CharacterComponent.GetIndex();

                switch (CurrentButton)
                {
                    case ButtonID.D1:
                        {
                            if (ZoneProfiles[iZone][ButtonID.D1] == true)
                                CharacterComponent.Up();
                            break;
                        }
                    case ButtonID.D2:
                        {
                            if (ZoneProfiles[iZone][ButtonID.D2] == true)
                                CharacterComponent.Left();
                            break;
                        }
                    case ButtonID.D3:
                        {
                            if (ZoneProfiles[iZone][ButtonID.D3] == true)
                                //CharacterComponent.
                                break;
                        }
                    case ButtonID.D4:
                        {
                            if (ZoneProfiles[iZone][ButtonID.D4] == true)
                                CharacterComponent.Right();
                            break;
                        }
                    case ButtonID.D5:
                        {
                            if (ZoneProfiles[iZone][ButtonID.D5] == true)
                                CharacterComponent.Down();
                            break;
                        }
                    case ButtonID.O1:
                        {
                            // TODO: DOOR SCRIPT
                            break;
                        }
                    case ButtonID.O2:
                        {
                            // TODO: DOOR SCRIPT
                            break;
                        }
                    case ButtonID.O3:
                        {
                            // TODO: OTHER
                            break;
                        }
                    case ButtonID.O4:
                        {
                            // TODO: OTHER
                            break;
                        }

                }
            }

        }
    }
}