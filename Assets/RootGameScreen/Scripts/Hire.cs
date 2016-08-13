using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Hire
{
	public int ID { get; set; }
	public string Title { get; set; }
//	public int ReqRank { get; set; }
	public int ReqGold { get; set; }
//	public int RewardXP { get; set; }
//	public string RewardItems { get; set; }

//	public Hire(int id, string title, int reqRank, int rewardGold, int rewardXP, string rewardItems)
	public Hire(int id, String title, int reqGold)
	{
		this.ID= id;
		this.Title = title;
		this.ReqGold = reqGold;
		//TODO maybe add items carried?
//		ReqRank = reqRank;
//		RewardGold = rewardGold;
//		RewardXP = rewardXP;
//		RewardItems = rewardItems;
	}
}
