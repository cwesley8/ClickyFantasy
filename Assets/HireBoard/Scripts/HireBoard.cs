using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class HireBoard : MonoBehaviour
{
	public Texture backgroundTexture;

	public float hireTitlePosX;
	public float hireTitlePosY;

	public Vector2 scrollPosition = Vector2.zero;

	//Quest stuff
	public List<Hire> Hires = new List<Hire>();

	void OnGUI()
	{
		//Display background texture 
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

		//Display title of new page
		GUI.Label(new Rect(Screen.width * hireTitlePosX, Screen.height * hireTitlePosY, Screen.width * .5f, Screen.height * .1f), "Hire");

		if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
		{
			//Return to root game screen
			SceneManager.LoadScene("RootGameScreen");
		}

		using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 30, 310, 390), scrollPosition, new Rect(0, 0, 310, Hires.Count*100)))
		{
			scrollPosition = scrollScope.scrollPosition;

			//Populate quest list with all known quests

			for (int i = 0; i < Hires.Count; i++)
			{              
				GUI.Button(new Rect(0, i*100, 280, 100), HireByID(i).Title + "\nReq. Gold: " + HireByID(i).ReqGold);
			}
		}
	}

	//hirables
	void populateHires()
	{
		//hires
		Hire Ratatuille = new Hire(0, "Ratatuille", 1000);
		Hire Gerber = new Hire(1, "Gerber", 1500);

		Hire KingHunter = new Hire(2, "King Hunter", 2000);
		Hire Gatherer = new Hire(3, "Gatherer", 2500);

		Hire DragonHunter = new Hire(4, "Dragon Hunter", 3000);


		Hires.Add(Ratatuille);
		Hires.Add(Gerber);
		Hires.Add(KingHunter);
		Hires.Add(Gatherer);
		Hires.Add(DragonHunter);

		StaticData.numOfHires = Hires.Count;
	}

	void Start()
	{
		populateHires();
	}
	public Hire HireByID(int id)
	{
		foreach (Hire hire in Hires)
		{
			if (hire.ID == id)
			{
				return hire;
			}
		}

		return null;
	}
}
