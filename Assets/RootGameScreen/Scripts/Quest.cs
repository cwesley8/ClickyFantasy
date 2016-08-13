using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Quest
{
    public int ID { get; set; }
    public string Title { get; set; }
    public int ReqRank { get; set; }
    public int RewardGold { get; set; }
    public int RewardXP { get; set; }
    public string RewardItems { get; set; }


    public Quest(int id, string title, int reqRank, int rewardGold, int rewardXP, string rewardItems)
    {
        ID = id;
        Title = title;
        ReqRank = reqRank;
        RewardGold = rewardGold;
        RewardXP = rewardXP;
        RewardItems = rewardItems;
    }
}
