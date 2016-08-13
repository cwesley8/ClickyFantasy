using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class QuestBoard : MonoBehaviour
{
    public Texture backgroundTexture;

    public float questBoardTitlePosX;
    public float questBoardTitlePosY;

    public Vector2 scrollPosition = Vector2.zero;

    //Quest stuff
    public List<Quest> Quests = new List<Quest>();
    private string questTitle;

    void OnGUI()
    {
        

        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //Display title of new page
        GUI.Label(new Rect(Screen.width * questBoardTitlePosX, Screen.height * questBoardTitlePosY, Screen.width * .5f, Screen.height * .1f), "Quest Board");

        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
        }

        using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 30, 310, 390), scrollPosition, new Rect(0, 0, 310, Quests.Count*100)))
        {
            scrollPosition = scrollScope.scrollPosition;

            //Populate quest list with all known quests
            
            for (int i = 0; i < Quests.Count; i++)
            {              
                GUI.Button(new Rect(0, i*100, 280, 100), QuestByID(i).Title + "\nReq. Rank: " + QuestByID(i).ReqRank +  "\nReward: "+ QuestByID(i).RewardGold + " G, " + QuestByID(i).RewardItems);
            }
        }
    }

    //Questboard quests should be added here
    void populateQuests()
    {
        //Rank 1 quests
        Quest RatExtermination = new Quest(0, "Rat Extermination", 1, 1000, 50, "Rat Tails");
        Quest GatherHerbs = new Quest(1, "Local Teen Needs Herb", 1, 500, 25, "Funny Herbs");

        //Rank 2 quests
        Quest RatKingHunt = new Quest(2, "Take on the King of Rats", 2, 10000, 500, "Royal Rat Tail");
        Quest GatherOre = new Quest(3, "I Got the Black Lung", 2, 10000, 500, "Iron Ore");

        //Rank 3 quests
        Quest DragonHunt = new Quest(4, "Dragon Slayer", 3, 100000, 5000, "Blue Dragon Scale");


        Quests.Add(RatExtermination);
        Quests.Add(GatherHerbs);
        Quests.Add(RatKingHunt);
        Quests.Add(GatherOre);
        Quests.Add(DragonHunt);

        StaticData.numOfQuests = Quests.Count;
    }

    void Start()
    {
        populateQuests();
    }
    public Quest QuestByID(int id)
    {
        foreach (Quest quest in Quests)
        {
            if (quest.ID == id)
            {
                return quest;
            }
        }

        return null;
    }
}
