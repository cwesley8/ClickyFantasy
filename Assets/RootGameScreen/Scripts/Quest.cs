using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Quest
{
    public string Title { get; set; }
    public int ReqRank { get; set; }
    public int RewardGold { get; set; }
    public int RewardXP { get; set; }

    public Quest(string title, int reqRank, int rewardGold, int rewardXP)
    {
        title = Title;
        reqRank = ReqRank;
        rewardGold = RewardGold;
        rewardXP = RewardXP;
    }
}
