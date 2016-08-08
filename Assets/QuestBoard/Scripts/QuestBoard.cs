using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuestBoard : MonoBehaviour
{
    public Texture backgroundTexture;

    public float questBoardTitlePosX;
    public float questBoardTitlePosY;

    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //Display title of new page
        GUI.Label(new Rect(Screen.width * questBoardTitlePosX, Screen.height * questBoardTitlePosY, Screen.width * .5f, Screen.height * .1f), "Quest Board");

        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
        }
    }
}
