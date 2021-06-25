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
        public Sprite Active;
        public Sprite Unactive;

        public TextureStorageType(Sprite tActive, Sprite tUnactive)
        {
            Active = tActive;
            Unactive = tUnactive;
        }

        public Sprite GetTexture(bool isActive)
        {
            if (isActive)
                return Active;
            else
                return Unactive;

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
        [SerializeField] private Sprite UpOn;
        [SerializeField] private Sprite UpOff;
        [SerializeField] private Sprite LeftOn;
        [SerializeField] private Sprite LeftOff;
        [SerializeField] private Sprite StopOn;
        [SerializeField] private Sprite StopOff;
        [SerializeField] private Sprite RightOn;
        [SerializeField] private Sprite RightOff;
        [SerializeField] private Sprite DownOn;
        [SerializeField] private Sprite DownOff;
        [SerializeField] private Sprite RedOn;
        [SerializeField] private Sprite RedOff;
        [SerializeField] private Sprite BlueOn;
        [SerializeField] private Sprite BlueOff;
        [SerializeField] private Sprite DefOn;
        [SerializeField] private Sprite DefOff;

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

            /* Label:
                    Level 1 
                        Yellow = 0
                        Orange = 1
                        Green = 3
                    Level 2
                        
    */
            ZoneProfiles = new List<Dictionary<ButtonID, bool>>();
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
            int iZone = CharacterComponent.GetIndex();
            int i = 0;
            
            // for each loop to check each button sprite and whether its pressed 
            foreach (GameObject eachobject in buttons)
            {
                Button cur = eachobject.GetComponent<Button>();
                
                // sprite correction
                if (ZoneProfiles[iZone][cur.GetButtonID()] == true)
                {
                    eachobject.GetComponent<SpriteRenderer>().sprite = TSS[i].GetTexture(true);
                }
                else
                    eachobject.GetComponent<SpriteRenderer>().sprite = TSS[i].GetTexture(false);

                // if button is pressed
                if (cur.GetPressed() == true)
                {
                    CurrentButton = cur.GetButtonID();
                }

                i++;
            }

            // which button is pressed
            if (CurrentButton != 0)
            {
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
                                CharacterComponent.Stop();
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
                            if (ZoneProfiles[iZone][ButtonID.O1] == true)
                                transform.GetComponent<DoorManager>().RedDoorActivate();
                            break;
                        }
                    case ButtonID.O2:
                        {
                            if (ZoneProfiles[iZone][ButtonID.O2] == true)
                                transform.GetComponent<DoorManager>().BlueDoorActivate();
                            break;
                        }
                }
            }
        }
    }
}