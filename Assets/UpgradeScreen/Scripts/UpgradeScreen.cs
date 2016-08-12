using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    public Texture backgroundTexture;

    //Declare GUI object positions here
    public float returnButtonPosX;
    public float returnButtonPosY;
    public float rankUpButtonPosX;
    public float rankUpButtonPosY;
    public float rankLabelPosX;
    public float rankLabelPosY;

    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        if (GUI.Button(new Rect(Screen.width * returnButtonPosX, Screen.height * returnButtonPosY, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            StaticData.warriorUpPressed = false;
            StaticData.rogueUpPressed = false;
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
        }

        if(StaticData.warriorUpPressed)
        {
            GUI.Label(new Rect(Screen.width * rankLabelPosX, Screen.height * rankLabelPosY, Screen.width * .5f, Screen.height * .1f), "Warrior Rank: " + StaticData.savedWarriorRank.ToString());

            if (GUI.Button(new Rect(Screen.width * rankUpButtonPosX, Screen.height * rankUpButtonPosY, Screen.width * .5f, Screen.height * .1f), "Warrior Rank Up"))
            {
				if(StaticData.savedWarriorLevel == 9 && StaticData.savedWarriorRank < StaticData.warriorStatuses.Length - 1)
                {
                    StaticData.savedWarriorRank++;
                }
            }
        }
        else if(StaticData.rogueUpPressed)
        {
            GUI.Label(new Rect(Screen.width * rankLabelPosX, Screen.height * rankLabelPosY, Screen.width * .5f, Screen.height * .1f), "Rogue Rank: " + StaticData.savedRogueRank.ToString());

            if (GUI.Button(new Rect(Screen.width * rankUpButtonPosX, Screen.height * rankUpButtonPosY, Screen.width * .5f, Screen.height * .1f), "Rogue Rank Up"))
            {
				if (StaticData.savedRogueLevel == 9 && StaticData.savedRogueRank < StaticData.rogueStatuses.Length - 1)
                {
                    StaticData.savedRogueRank++;
                }
            }
        }
    }
}
