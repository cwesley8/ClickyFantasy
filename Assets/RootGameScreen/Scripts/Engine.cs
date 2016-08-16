using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Engine : MonoBehaviour
{

    public Texture backgroundTexture;

    //Declare GUI object positions here
    public float goldButtonPosX;
    public float goldButtonPosY;
    public float goldLabelPosX;
    public float goldLabelPosY;
    public float gpsLabelPosX;
    public float gpsLabelPosY;

    /*public float warriorHirePosX;
    public float warriorHirePosY;

    public float rogueHirePosX;
    public float rogueHirePosY;
    */
    public float warriorUpgradePosX;
    public float warriorUpgradePosY;

    public float rogueUpgradePosX;
    public float rogueUpgradePosY;
    

    public float QuestBoardPosX;
    public float QuestBoardPosY;
    public float BlacksmithPosX;
    public float BlacksmithPosY;
    public float HireBoardPosX;
    public float HireBoardPosY;
    public float RosterPosX;
    public float RosterPosY;

    public int totalGold = 10;
    public int goldPerSecond = 0;

    //Adventurer info
    public float adventurerNamePosX;
    public float adventurerNamePosY;
    public float adventurerLevelPosX;
    public float adventurerLevelPosY;
    public float adventurerRankPosX;
    public float adventurerRankPosY;
    public float adventurerTaskPosX;
    public float adventurerTaskPosY;

    //List of income sources
    public int warriorLevel = 0;
    static public int warriorGPS = 1;
    static public int warriorPrice = 10;
    public string warriorStatus = "";
    public int warriorRank = 0;
    public bool warriorUpgrade = false;
    public bool rogueUpgrade = false;

    public int rogueLevel = 0;
    static public int rogueGPS = 10;
    static public int roguePrice = 100;
    public string rogueStatus = "";
    public int rogueRank = 0;

    public float goldUpdateTime = 1f;

    //Guild status and upgrades information
    public int guildLevel = 1;

    public System.Random ran = new System.Random();

    public List<Adventurer> Adventurers = new List<Adventurer>();

    public Vector2 scrollPosition = Vector2.zero;


    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //Display all income and hired mercenaries information
        GUI.Label(new Rect(Screen.width * goldLabelPosX, Screen.height * goldLabelPosY, Screen.width * .5f, Screen.height * .1f), "Gold:" + totalGold.ToString());
        GUI.Label(new Rect(Screen.width * gpsLabelPosX, Screen.height * gpsLabelPosY, Screen.width * .5f, Screen.height * .1f), "GPS: " + goldPerSecond.ToString());

        using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 10, 310, Screen.height * 0.33f), scrollPosition, new Rect(0, 0, 310, Adventurers.Count * 100)))
        {    
            scrollPosition = scrollScope.scrollPosition;
            for (int i = 0; i < Adventurers.Count; i++)
            { 
                if (AdventurerByID(i).Hired)
                {
                    GUI.Label(new Rect(Screen.width * adventurerNamePosX, Screen.height * adventurerNamePosY * (i + 1), Screen.width * .5f, Screen.height * .1f), AdventurerByID(i).Name);
                    GUI.Label(new Rect(Screen.width * adventurerLevelPosX, Screen.height * adventurerLevelPosY * (i + 1), Screen.width * .5f, Screen.height * .1f), "Level: " + AdventurerByID(i).CurLevel);
                    GUI.Label(new Rect(Screen.width * adventurerRankPosX, Screen.height * adventurerRankPosY * (i + 1), Screen.width * .5f, Screen.height * .1f), "Rank: " + AdventurerByID(i).CurRank);
                    GUI.Label(new Rect(Screen.width * adventurerTaskPosX, Screen.height * adventurerTaskPosY * (i + 1), Screen.width * .5f, Screen.height * .1f), "Task: " + AdventurerByID(i).CurTask);
                }
            }
        }

        //Purchase list
        //Press on the gold button to increment gold
        if (GUI.Button(new Rect(Screen.width * goldButtonPosX, Screen.height * goldButtonPosY, Screen.width * .5f, Screen.height * .1f), "Gold"))
        {
            totalGold = totalGold + 1;
        }

        //Press on the hire warrior to increment warrior count
        //Currenty just for tesing
        /*if (GUI.Button(new Rect(Screen.width * warriorHirePosX, Screen.height * warriorHirePosY, Screen.width * .5f, Screen.height * .1f),
            "Level Hector cost: " + warriorPrice))
        {
            if ( //TODO remove after testing totalGold >= warriorPrice && 
                AdventurerByID(0).CurLevel < 9)
            {
                AdventurerByID(0).CurLevel++;
                totalGold -= warriorPrice;
            }
        }*/
        if (GUI.Button(new Rect(Screen.width * warriorUpgradePosX, Screen.height * warriorUpgradePosY, Screen.width * .5f, Screen.height * .1f), "Upgrade Warrior"))
        {
            //Save current stats
            warriorUpgrade = true;
            saveStaticData();

            //Load upgrade screen
            SceneManager.LoadScene("UpgradeScreen");
        }
        /*if (GUI.Button(new Rect(Screen.width * rogueHirePosX, Screen.height * rogueHirePosY, Screen.width * .5f, Screen.height * .1f),
            "Level Balmung cost: " + roguePrice))
        {
            if (//TODO remove after testing totalGold >= roguePrice && 
                AdventurerByID(1).CurLevel < 9)
            {
                AdventurerByID(1).CurLevel++;
                totalGold -= roguePrice;
            }
        }*/
        if (GUI.Button(new Rect(Screen.width * rogueUpgradePosX, Screen.height * rogueUpgradePosY, Screen.width * .5f, Screen.height * .1f), "Upgrade Rogue"))
        {
            //Save current state
            rogueUpgrade = true;
            saveStaticData();

            //Load upgrade screen
            SceneManager.LoadScene("UpgradeScreen");
        }
        if (GUI.Button(new Rect(Screen.width * QuestBoardPosX, Screen.height * QuestBoardPosY, Screen.width * .5f, Screen.height * .1f), "Quest Board"))
        {
            //Save current state
            saveStaticData();

            //Load quest board
            SceneManager.LoadScene("QuestBoard");
        }
        if (GUI.Button(new Rect(Screen.width * BlacksmithPosX, Screen.height * BlacksmithPosY, Screen.width * .5f, Screen.height * .1f), "Blacksmith"))
        {
            //Save current state
            saveStaticData();

            //Load blacksmith scene
            SceneManager.LoadScene("Blacksmith");
        }
        if (GUI.Button(new Rect(Screen.width * HireBoardPosX, Screen.height * HireBoardPosY, Screen.width * .5f, Screen.height * .1f), "Hire Board"))
        {
            //Save current state
            saveStaticData();

            //Load hire board
            SceneManager.LoadScene("HireBoard");
        }

        if (GUI.Button(new Rect(Screen.width * RosterPosX, Screen.height * RosterPosY, Screen.width * .5f, Screen.height * .1f), "Roster"))
        {
            //Save current state
            saveStaticData();

            //Load roster scene
            SceneManager.LoadScene("Roster");
        }
    }

    // Use this for initialization
    void Start()
    {
        loadStaticData();        
        goldUpdateTime = 1f;      
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticData.firstEntry)
        {
            populateAdventurers();
            StaticData.firstEntry = false;
        }

        goldUpdateTime -= Time.deltaTime;
        if (goldUpdateTime <= 0)
        {
            goldUpdateTime = 1f;
            goldPerSecond = getGoldPerSecond();
            totalGold = totalGold + goldPerSecond;
        }
    }

    int getGoldPerSecond()
    {
        //Add up all the stuff you have
        if(AdventurerByID(0).CurTask == "Idle")
        {
            warriorRank = 0;
        }
        else
        {
            warriorRank = 1;
        }
        if (AdventurerByID(1).CurTask == "Idle")
        {
            rogueRank = 0;
        }
        else
        {
            rogueRank = 1;
        }
        goldPerSecond = AdventurerByID(0).CurLevel * warriorRank * warriorGPS + AdventurerByID(1).CurLevel * rogueRank * rogueGPS;

        return goldPerSecond;
    }

    void populateAdventurers()
    {
        //These are default adventurers you start the game with
        Adventurer Hector = new Adventurer(0, 1, 1, "Hector", "Axeman", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 0, true , 10, 9, 3, 9, 3, 6);
        Adventurer Balmung = new Adventurer(1, 1, 1, "Balmung", "Swordsman", 100, 100, 0, 6, 9, 5, 7, 5, 7, "Idle", 0, true, 6, 9, 5, 7, 5, 7);
        Adventurer Aeris = new Adventurer(2, 1, 1, "Aeris", "Cleric", 100, 100, 0, 4, 3, 6, 3, 9, 6, "Idle", 0, true, 4, 3, 6, 3, 9, 6);
        Adventurer Jake = new Adventurer(3, 1, 1, "Jake", "Warhound", 100, 100, 0, 7, 10, 2, 3, 3, 10, "Idle", 0, true, 7, 10, 2, 3, 3, 10);

        //Adventurers for hire
        Adventurer Ratatuille = new Adventurer(4, 1, 1, "Ratatuille", "Chef", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 1000, false, 10, 9, 3, 9, 3, 6);
        Adventurer Gerber = new Adventurer(5, 1, 1, "Gerber", "Baby", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 1500, false, 10, 9, 3, 9, 3, 6);
        Adventurer KingHunter = new Adventurer(6, 1, 1, "Kingpin", "Hunter", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 2000, false, 10, 9, 3, 9, 3, 6);
        Adventurer Gatherer = new Adventurer(7, 1, 1, "Gatherer", "Punk", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 2500, false, 10, 9, 3, 9, 3, 6);
        Adventurer DragonHunter = new Adventurer(8, 1, 1, "Drag Guy", "Knight", 100, 100, 0, 10, 9, 3, 9, 3, 6, "Idle", 3000, false, 10, 9, 3, 9, 3, 6);

        Adventurers.Add(Hector);
        Adventurers.Add(Balmung);
        Adventurers.Add(Aeris);
        Adventurers.Add(Jake);

        Adventurers.Add(Ratatuille);
        Adventurers.Add(Gerber);
        Adventurers.Add(KingHunter);
        Adventurers.Add(Gatherer);
        Adventurers.Add(DragonHunter);        
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

    int getGuildRank()
    {
        return guildLevel;
    }

    void saveStaticData()
    {
        StaticData.savedTotalGold = totalGold;
        StaticData.savedGoldPerSecond = goldPerSecond;
        StaticData.savedWarriorLevel = warriorLevel;
        StaticData.savedRogueLevel = rogueLevel;
        StaticData.warriorUpPressed = warriorUpgrade;
        StaticData.rogueUpPressed = rogueUpgrade;
        StaticData.savedWarriorRank = warriorRank;
        StaticData.savedRogueRank = rogueRank;
        StaticData.savedAdventurers = Adventurers;
        StaticData.numOfAdventurers = Adventurers.Count;
    }

    void loadStaticData()
    {
        totalGold = StaticData.savedTotalGold;
        goldPerSecond = StaticData.savedGoldPerSecond;
        warriorLevel = StaticData.savedWarriorLevel;
        rogueLevel = StaticData.savedRogueLevel;
        warriorRank = StaticData.savedWarriorRank;
        rogueRank = StaticData.savedRogueRank;
        warriorUpgrade = StaticData.warriorUpPressed;
        rogueUpgrade = StaticData.rogueUpPressed;
        Adventurers = StaticData.savedAdventurers;
    }

    /*void generateAdventurer()
    {
        //First pull random name from list and assign it to new adventurer object
        string randomName = "Bob";

        adventurer.name = randomName;

        //Generate adventurer level
        //Adventurer level depends on current guild level and buildings/enhancements
        //There should be a min and max adventurer level for any given guild state
        //For now, guild level is the only factor
        int luckyChance = ran.Next(1, 100);
        float minLevel = 0f;
        float maxLevel = 0f;

        //70% chance adventurer level will be same as guild level
        if (luckyChance < 70)
        {
            adventurer.curLevel = getGuildRank();
        }
        //20% chance lower than guild level
        else if (luckyChance < 90)
        {
            minLevel = getGuildRank() * 0.05f; 
            maxLevel = getGuildRank() * 0.09f;
        }
        else if (luckyChance < 95)
        //5% chance higher than guild level
        {
            minLevel = getGuildRank() * 1.05f;
            maxLevel = getGuildRank() * 1.10f;
        }

        //special case for when guild rank is 1
        if (getGuildRank() == 1)
        {
            minLevel = 1f;
        }

        adventurer.curLevel = ran.Next((int)minLevel, (int)maxLevel);

        //Next randomly choose character class
        string randomCharClass = "Freelancer";
        adventurer.charClass = randomCharClass;

        //Generate stats based on character class
        if (adventurer.charClass == "Freelancer")
        {
            //Base stats for freelancer
            int

        }

        //
        Adventurers.Add();
    }*/
}
