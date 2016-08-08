using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Adventurer
{
    public int CurLevel { get; set; }
    public string Name { get; set; }
    public string CharClass { get; set; }
    public int TotalHP { get; set; }
    public int CurHP { get; set; }
    public int CurXP { get; set; }
    public int PAtk { get; set; }
    public int MAtk { get; set; }
    public int PDef { get; set; }
    public int MDef { get; set; }
    public int Speed { get; set; }
        
    public Adventurer(int curLevel, string name, string charClass, int totalHP,  int curHP, int curXP, int pAtk, int mAtk, int pDef, int mDef, int speed)
    {
        curLevel = CurLevel;
        name = Name;
        charClass = CharClass;
        totalHP = TotalHP;
        curHP = CurHP;
        curXP = CurXP;
        pAtk = PAtk;
        mAtk = MAtk;
        pDef = PDef;
        mDef = MDef;
        speed = Speed;
    }
}
