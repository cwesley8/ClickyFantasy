using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    public GUIStyle settingsIcon;

    public float newGameButtonPosX;
    public float newGameButtonPosY;
    public float continueButtonPosX;
    public float continueButtonPosY;
    public float settingsButtonPosX;
    public float settingsButtonPosY;

    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
        
        //Displays buttons
        if( GUI.Button(new Rect(Screen.width * newGameButtonPosX, Screen.height * newGameButtonPosY, Screen.width * .5f, Screen.height * .1f), "New Game"))
        {
            //Display intro card screen
            SceneManager.LoadScene("IntroCard");
        }

        if (GUI.Button(new Rect(Screen.width * continueButtonPosX, Screen.height * continueButtonPosY, Screen.width * .5f, Screen.height * .1f), "Continue"))
        {
            print("Clicked Continue!");
            //Begin game
        }

        if (GUI.Button(new Rect(Screen.width - settingsButtonPosX, Screen.height - settingsButtonPosY, 20, 20), "", settingsIcon))
        {
            print("Clicked Settings!");
        }
    }
}
