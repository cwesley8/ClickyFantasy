using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StaticData
{  
    static public int savedTotalGold = 10;
    static public int savedGoldPerSecond = 0;
    static public int savedWarriorLevel = 0;
    static public int savedRogueLevel = 0;
    static public int savedWarriorRank = 0;
    static public int savedRogueRank = 0;

    static public bool warriorUpPressed = false;
    static public bool rogueUpPressed = false;

    static public string[] warriorStatuses = new string[2] {"Mug children",
                                                            "Bodyguard Merchant"};

    static public string[] rogueStatuses = new string[2] {"Pickpocket grannies",
                                                          "Ambush caravans"};


}
