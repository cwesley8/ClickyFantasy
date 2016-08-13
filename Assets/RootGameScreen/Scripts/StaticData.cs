using System;
using System.Collections;
using System.Linq;
using System.Text;

// this can be a static class, doesn't need instantiation
public static class StaticData
{
    static public int savedTotalGold = 10;
    static public int savedGoldPerSecond = 0;
    static public int savedWarriorLevel = 0;
    static public int savedRogueLevel = 0;
    static public int savedWarriorRank = 0;
    static public int savedRogueRank = 0;

    static public bool warriorUpPressed = false;
    static public bool rogueUpPressed = false;

	//TODO consider using arraylist, if this won't be an enum
//	static ArrayList warriorStatuses = new ArrayList("Mug children", "Bodyguard Merchant");
//	static ArrayList rogueStatuses = new ArrayList("Pickpocket grannies", "Ambush caravans");

    static public string[] warriorStatuses = new string[2] {"Mug children",
                                                            "Bodyguard Merchant"};

    static public string[] rogueStatuses = new string[2] {"Pickpocket grannies",
                                                          "Ambush caravans"};

    //Quest Board related junk
    static public int numOfQuests { get; set; }
}
