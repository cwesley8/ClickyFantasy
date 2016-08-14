using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class Roster : MonoBehaviour
{
    public float rosterTitlePosX;
    public float rosterTitlePosY;

    //Detail Panel object positions
    public float adventurerNamePosX;
    public float adventurerNamePosY;
    public float adventurerLevelPosX;
    public float adventurerLevelPosY;
    public float adventurerRankPosX;
    public float adventurerRankPosY;
    public float adventurerExpPosX;
    public float adventurerExpPosY;
    public float adventurerTaskPosX;
    public float adventurerTaskPosY;

    public float adventurerCurHpPosX;
    public float adventurerCurHpPosY;
    public float adventurerMaxHpPosX;
    public float adventurerMaxHpPosY;
    public float adventurerAttPosX;
    public float adventurerAttPosY;
    public float adventurerMagPosX;
    public float adventurerMagPosY;
    public float adventurerDefPosX;
    public float adventurerDefPosY;
    public float adventurerResPosX;
    public float adventurerResPosY;
    public float adventurerSpdPosX;
    public float adventurerSpdPosY;

    public float taskChangePosX;
    public float taskChangePosY;

    public Vector2 scrollPosition = Vector2.zero;

    public bool charDetailPanelUp = false;

    //Quest stuff
    public List<Adventurer> Adventurers = new List<Adventurer>();

    public int selectedAdventurer;

    void OnGUI()
    {
        if (!charDetailPanelUp)
        {
            //Display title of new page
            GUI.Label(new Rect(Screen.width * rosterTitlePosX, Screen.height * rosterTitlePosY, Screen.width * .5f, Screen.height * .1f), "Roster");

            if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
            {
                //Return to root game screen
                SceneManager.LoadScene("RootGameScreen");
            }

            using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 30, 310, 390), scrollPosition, new Rect(0, 0, 310, Adventurers.Count * 100)))
            {
                scrollPosition = scrollScope.scrollPosition;

                //Populate quest list with current adventurers

                for (int i = 0; i < Adventurers.Count; i++)
                {

                    if (GUI.Button(new Rect(0, i * 100, 280, 100), AdventurerByID(i).Name + "\nClass: " + AdventurerByID(i).CharClass + "\nRank: " + AdventurerByID(i).CurRank + "\nTask: " + AdventurerByID(i).CurTask))
                    {
                        //Disable adventurer buttons
                        charDetailPanelUp = true;
                        //Add panel to display character info and task selection menu
                        setCharDetailPanel(AdventurerByID(i));
                        selectedAdventurer = i;
                    }

                }
            }
        }

        if(charDetailPanelUp)
        {
            GUI.contentColor = Color.black;
            //Details
            GUI.Label(new Rect(Screen.width * adventurerNamePosX, Screen.height * adventurerNamePosY, Screen.width * .5f, Screen.height * .1f),  AdventurerByID(selectedAdventurer).Name);
            GUI.Label(new Rect(Screen.width * adventurerLevelPosX, Screen.height * adventurerLevelPosY, Screen.width * .5f, Screen.height * .1f), "Level:     " + AdventurerByID(selectedAdventurer).CurLevel);
            GUI.Label(new Rect(Screen.width * adventurerRankPosX, Screen.height * adventurerRankPosY, Screen.width * .5f, Screen.height * .1f),   "Rank:      " + AdventurerByID(selectedAdventurer).CurRank);
            GUI.Label(new Rect(Screen.width * adventurerExpPosX, Screen.height * adventurerExpPosY, Screen.width * .5f, Screen.height * .1f),     "Exp:       " + AdventurerByID(selectedAdventurer).CurRank);
            GUI.Label(new Rect(Screen.width * adventurerTaskPosX, Screen.height * adventurerTaskPosY, Screen.width * .5f, Screen.height * .1f),   "Task:      " + AdventurerByID(selectedAdventurer).CurTask);
            GUI.Label(new Rect(Screen.width * adventurerCurHpPosX, Screen.height * adventurerCurHpPosY, Screen.width * .5f, Screen.height * .1f), "HP:      " + AdventurerByID(selectedAdventurer).CurHP);
            GUI.Label(new Rect(Screen.width * adventurerMaxHpPosX, Screen.height * adventurerMaxHpPosY, Screen.width * .5f, Screen.height * .1f), "/" + AdventurerByID(selectedAdventurer).TotalHP);
            GUI.Label(new Rect(Screen.width * adventurerAttPosX, Screen.height * adventurerAttPosY, Screen.width * .5f, Screen.height * .1f), "Attack:           " + AdventurerByID(selectedAdventurer).PAtk);
            GUI.Label(new Rect(Screen.width * adventurerMagPosX, Screen.height * adventurerMagPosY, Screen.width * .5f, Screen.height * .1f), "Magic:            " + AdventurerByID(selectedAdventurer).MAtk);
            GUI.Label(new Rect(Screen.width * adventurerDefPosX, Screen.height * adventurerDefPosY, Screen.width * .5f, Screen.height * .1f), "Defense:         " + AdventurerByID(selectedAdventurer).PDef);
            GUI.Label(new Rect(Screen.width * adventurerResPosX, Screen.height * adventurerResPosY, Screen.width * .5f, Screen.height * .1f), "Resistance:     " + AdventurerByID(selectedAdventurer).MDef);
            GUI.Label(new Rect(Screen.width * adventurerSpdPosX, Screen.height * adventurerSpdPosY, Screen.width * .5f, Screen.height * .1f), "Speed:            " + AdventurerByID(selectedAdventurer).Speed);

            //Change Task 
            if (GUI.Button(new Rect(Screen.width * taskChangePosX, Screen.height * taskChangePosY, Screen.width * .5f, Screen.height * .1f), "Change Task"))
            {
                print("Task change");
            }

            //Exit Detail mode
            if (GUI.Button(new Rect(Screen.width * 0.875f, Screen.height * 0f, 40, 40), "X"))
            {
                Destroy(GameObject.Find("Canvas"));
                charDetailPanelUp = false;
            }
        }
    }

    //TODO: Add funcitonality that converts new hires to adventurers
    void populateAdventurers()
    {
        //These are default adventurers you start the game with
        Adventurer Hector = new Adventurer(0, 1, 1, "Hector", "Axeman", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle");
        Adventurer Balmung = new Adventurer(1, 1, 1, "Balmung", "Swordsman", 100, 100, 0, 6, 9, 5, 7, 5, 7, "Idle");
        Adventurer Aeris = new Adventurer(2, 1, 1, "Aeris", "Cleric", 100, 100, 0, 4, 3, 6, 3, 9, 6, "Idle");
        Adventurer Jake = new Adventurer(3, 1, 1, "Jake", "Warhound", 100, 100, 0, 7, 10, 2, 3, 3, 10, "Idle");

        Adventurers.Add(Hector);
        Adventurers.Add(Balmung);
        Adventurers.Add(Aeris);
        Adventurers.Add(Jake);

        StaticData.numOfAdventurers = Adventurers.Count;
    }

    void Start()
    {
        populateAdventurers();
    }

    public Adventurer AdventurerByID(int id)
    {
        foreach (Adventurer adventurer in Adventurers)
        {
            if (adventurer.ID == id)
            {
                return adventurer;
            }
        }

        return null;
    }

    void setCharDetailPanel(Adventurer adventurer)
    {
        GameObject newCanvas = new GameObject("Canvas");
        Canvas c = newCanvas.AddComponent<Canvas>();
        c.renderMode = RenderMode.ScreenSpaceOverlay;
        newCanvas.AddComponent<CanvasScaler>();
        newCanvas.AddComponent<GraphicRaycaster>();
        
        //Bottom panel that everything will be placed on
        GameObject bgPanel = new GameObject("Background Panel");
        bgPanel.transform.localScale += new Vector3(3f, 4f, 0);
        bgPanel.AddComponent<CanvasRenderer>();
        Image bgPanelImage = bgPanel.AddComponent<Image>();
        bgPanelImage.color = Color.white;
        bgPanelImage.transform.SetParent(newCanvas.transform, false);

        //Character portrai will go here
        GameObject charPortraitPanel = new GameObject("Character Portrait Panel");
        charPortraitPanel.transform.localScale += new Vector3(.3f, .3f, 0);
        charPortraitPanel.transform.position = new Vector3(-85, 165, 0);
        charPortraitPanel.AddComponent<CanvasRenderer>();

        Image charPortraitImage = charPortraitPanel.AddComponent<Image>();
        string charPortraitName = adventurer.Name;
        charPortraitImage.sprite = Resources.Load(charPortraitName, typeof(Sprite)) as Sprite;
        charPortraitPanel.transform.SetParent(newCanvas.transform, false);
    }
}
