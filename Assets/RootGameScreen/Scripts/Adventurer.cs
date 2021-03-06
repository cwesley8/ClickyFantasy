﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Adventurer
{
    public int ID { get; set; }
    public int CurLevel { get; set; }
    public int CurRank { get; set; }
    public string Name { get; set; }
    public string CharClass { get; set; }
    public int TotalHP { get; set; }
    public int CurHP { get; set; }
    public int CurXP { get; set; }
    public int HP { get; set; }
    public int PAtk { get; set; }
    public int MAtk { get; set; }
    public int PDef { get; set; }
    public int MDef { get; set; }
    public int Speed { get; set; }
    public string CurTask { get; set; }

    //Hire properties
    public int ReqGold { get; set; }
    public bool Hired { get; set; }

    //Growth rate properties
    public int HPGrowth { get; set; }
    public int AttGrowth { get; set; }
    public int DefGrowth { get; set; }
    public int MagGrowth { get; set; }
    public int ResGrowth { get; set; }
    public int SpdGrowth { get; set; }

    public Adventurer(int id, int curLevel, int curRank, string name, string charClass, int totalHP, int curHP, int curXP, 
                      int hp, int pAtk, int mAtk, int pDef, int mDef, int speed, string curTask, int reqGold, bool hired,
                      int hpGrowth, int attGrowth, int magGrowth, int defGrowth, int resGrowth, int spdGrowth)
    {
        ID = id;
        CurLevel = curLevel;
        CurRank = curRank;
        CurTask = curTask;
        Name = name;
        CharClass = charClass;
        TotalHP = totalHP;
        CurHP = curHP;
        CurXP = curXP;
        HP = hp;
        PAtk = pAtk;
        MAtk = mAtk;
        PDef = pDef;
        MDef = mDef;
        Speed = speed;
        ReqGold = reqGold;
        Hired = hired;
        HPGrowth = hpGrowth;
        AttGrowth = attGrowth;
        DefGrowth = defGrowth;
        MagGrowth = magGrowth;
        ResGrowth = resGrowth;
        SpdGrowth = spdGrowth;
    }

    /****************************
    Notes on character classes (may create an encyclopedia page for all this info)
    All stats on a scale of 0 to 10. These values dictate % chance that a stat will grow on level up (1 point = 10%)
    Axeman: Takes hits as well as they dish them out. Lacks accuracy because of use of axes and has naturally low speed.
        HP:||||||||||
        PA:|||||||||
        MA:|||
        PD:|||||||||
        MD:|||
        SP:||||||
    
    Swordsman: The most balanced adventurer. An asset on most quests and works well in any team. 
        HP:||||||
        PA:|||||||||
        MA:|||||
        PD:|||||||
        MD:|||||
        SP:|||||||    
        
    Cleric: Fragile, but can cast healing magics, buffs, and offensive holy magic. High magic resistance.
        HP:||||
        PA:|||
        MA:||||||
        PD:|||
        MD:||||||||
        SP:||||||      

    Warhound: Fast and strong, but can't equip armor. Lacks natural defenses
        HP:|||||||
        PA:||||||||||
        MA:||
        PD:|||
        MD:|||
        SP:||||||||||  
    *****************************/
}
