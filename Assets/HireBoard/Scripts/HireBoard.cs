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
	public List<Adventurer> Adventurers = new List<Adventurer>();

	void OnGUI()
	{
		//Display background texture 
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

		//Display title of new page
		GUI.Label(new Rect(Screen.width * hireTitlePosX, Screen.height * hireTitlePosY, Screen.width * .5f, Screen.height * .1f), "Hire");

		if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
		{
            saveStaticData();
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
		}

		using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 30, 310, 390), scrollPosition, new Rect(0, 0, 310, Adventurers.Count*100)))
		{
			scrollPosition = scrollScope.scrollPosition;

            //Render hire list  
            int j = -1;
			for (int i = 0; i < Adventurers.Count; i++)
			{        
                if(!AdventurerByID(i).Hired)
                {
                    j++;
                    if (GUI.Button(new Rect(0, j * 100, 280, 100), AdventurerByID(i).Name + "\nReq. Gold: " + AdventurerByID(i).ReqGold))
                    {
                        AdventurerByID(i).Hired = true;                       
                    }
                }
			}
		}
	}

	void Start()
	{
        loadStaticData();
	}

	public Adventurer AdventurerByID(int id)
	{
		foreach (Adventurer Adventurer in Adventurers)
		{
			if (Adventurer.ID == id)
			{
				return Adventurer;
			}
		}

		return null;
	}

    void saveStaticData()
    {
        StaticData.numOfAdventurers = Adventurers.Count;
    }

    void loadStaticData()
    {
        Adventurers = StaticData.savedAdventurers;
    }
}
