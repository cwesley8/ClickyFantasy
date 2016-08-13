using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using UnityEngine.Audio;

public class Engine : MonoBehaviour {

    public Texture backgroundTexture;

    //Declare GUI object positions here
    public float goldButtonPosX;
    public float goldButtonPosY;
    public float goldLabelPosX;
    public float goldLabelPosY;
    public float gpsLabelPosX;
    public float gpsLabelPosY;
    public float warriorHirePosX;
    public float warriorHirePosY;
    public float warriorLevelPosX;
    public float warriorLevelPosY;
    public float warriorRankPosX;
    public float warriorRankPosY;
    public float warriorStatusPosX;
    public float warriorStatusPosY;
    public float warriorUpgradePosX;
    public float warriorUpgradePosY;
    public float rogueHirePosX;
    public float rogueHirePosY;
    public float rogueLevelPosX;
    public float rogueLevelPosY;
    public float rogueRankPosX;
    public float rogueRankPosY;
    public float rogueUpgradePosX;
    public float rogueUpgradePosY;
    public float rogueStatusPosX;
    public float rogueStatusPosY;
    public float QuestBoardPosX;
    public float QuestBoardPosY;

    public int totalGold = 10;
    public int goldPerSecond = 0;

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
    
    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
       
        //Display all income and hired mercenaries information
        GUI.Label(new Rect(Screen.width * goldLabelPosX, Screen.height * goldLabelPosY, Screen.width * .5f, Screen.height * .1f), "Gold:" + totalGold.ToString());
        GUI.Label(new Rect(Screen.width * gpsLabelPosX, Screen.height * gpsLabelPosY, Screen.width * .5f, Screen.height * .1f), "GPS: " + goldPerSecond.ToString());

        //Cases for warrior level and status
        if(warriorLevel > 0)
        {
            GUI.Label(new Rect(Screen.width * warriorLevelPosX, Screen.height * warriorLevelPosY, Screen.width * .5f, Screen.height * .1f), "Warrior Level: " + warriorLevel.ToString());
            GUI.Label(new Rect(Screen.width * warriorRankPosX, Screen.height * warriorRankPosY, Screen.width * .5f, Screen.height * .1f), "Rank: " + warriorRank.ToString());
            GUI.Label(new Rect(Screen.width * warriorStatusPosX, Screen.height * warriorStatusPosY, Screen.width * .5f, Screen.height * .1f), "Task: " + StaticData.warriorStatuses[warriorRank]);
        }

        //Cases for rogue level and status
        if (rogueLevel > 0)
        {
            GUI.Label(new Rect(Screen.width * rogueLevelPosX, Screen.height * rogueLevelPosY, Screen.width * .5f, Screen.height * .1f), "Rogue Level: " + rogueLevel.ToString());
            GUI.Label(new Rect(Screen.width * rogueRankPosX, Screen.height * rogueRankPosY, Screen.width * .5f, Screen.height * .1f), "Rank: " + rogueRank.ToString());
            GUI.Label(new Rect(Screen.width * rogueStatusPosX, Screen.height * rogueStatusPosY, Screen.width * .5f, Screen.height * .1f), "Task: " + StaticData.rogueStatuses[rogueRank]);
        }

        //Purchase list
        //Press on the gold button to increment gold
        if (GUI.Button(new Rect(Screen.width * goldButtonPosX, Screen.height * goldButtonPosY, Screen.width * .5f, Screen.height * .1f), "Gold"))
        {
            totalGold = totalGold + 1;
        }
        //Press on the hire warrior to increment warrior count
        if (GUI.Button(new Rect(Screen.width * warriorHirePosX, Screen.height * warriorHirePosY, Screen.width * .5f, Screen.height * .1f),
			"Level Warrior cost: " + warriorPrice))
        {
            if( //TODO remove after testing totalGold >= warriorPrice && 
				warriorLevel < 9)
            {
                warriorLevel = warriorLevel + 1;
                totalGold -= warriorPrice;
            }
        }
        if (GUI.Button(new Rect(Screen.width * warriorUpgradePosX, Screen.height * warriorUpgradePosY, Screen.width * .5f, Screen.height * .1f), "Upgrade Warrior"))
        {
            //Save current stats
            warriorUpgrade = true;
            saveGuildState();

            //Load upgrade screen
            SceneManager.LoadScene("UpgradeScreen");
        }
        if (GUI.Button(new Rect(Screen.width * rogueHirePosX, Screen.height * rogueHirePosY, Screen.width * .5f, Screen.height * .1f),
			"Level Rogue cost: " + roguePrice))
        {
            if (//TODO remove after testing totalGold >= roguePrice && 
				rogueLevel < 9)
            {
                rogueLevel = rogueLevel + 1;
                totalGold -= roguePrice;
            }
        }
        if (GUI.Button(new Rect(Screen.width * rogueUpgradePosX, Screen.height * rogueUpgradePosY, Screen.width * .5f, Screen.height * .1f), "Upgrade Rogue"))
        {
			//Save current stats
			rogueUpgrade = true;
			saveGuildState ();
        
			//Load upgrade screen
			SceneManager.LoadScene ("UpgradeScreen");
        }
        if (GUI.Button(new Rect(Screen.width * QuestBoardPosX, Screen.height * QuestBoardPosY, Screen.width * .5f, Screen.height * .1f), "Quest Board"))
        {
            //Save current stats
            saveGuildState();

            //Load quest board
            SceneManager.LoadScene("QuestBoard");
        }
    }

    // Use this for initialization
    void Start ()
    {
        
        goldUpdateTime = 1f;
        //Reload all saved variables
        totalGold = StaticData.savedTotalGold;
        goldPerSecond = StaticData.savedGoldPerSecond;
        warriorLevel = StaticData.savedWarriorLevel;
        rogueLevel = StaticData.savedRogueLevel;
        warriorRank = StaticData.savedWarriorRank;
        rogueRank = StaticData.savedRogueRank;
        warriorUpgrade = StaticData.warriorUpPressed;
        rogueUpgrade = StaticData.rogueUpPressed;
    }
	
	// Update is called once per frame
	void Update ()
    {
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
        goldPerSecond = warriorLevel * (warriorRank + 1) * warriorGPS + rogueLevel * (rogueRank + 1) * rogueGPS;

        return goldPerSecond;
    }

    void populateAdventurers()
    {
        Adventurer Hector = new Adventurer(1, "Hector", "Warrior", 100, 100, 0, 10, 5, 10, 5, 7);
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

    int getGuildRank()
    {
        return guildLevel;
    }

    void saveGuildState()
    {
        StaticData.savedTotalGold = totalGold;
        StaticData.savedGoldPerSecond = goldPerSecond;
        StaticData.savedWarriorLevel = warriorLevel;
        StaticData.savedRogueLevel = rogueLevel;
        StaticData.warriorUpPressed = warriorUpgrade;
        StaticData.rogueUpPressed = rogueUpgrade;
        StaticData.savedWarriorRank = warriorRank;
        StaticData.savedRogueRank = rogueRank;
    }
}
