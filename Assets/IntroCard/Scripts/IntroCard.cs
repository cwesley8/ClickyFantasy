using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroCard : MonoBehaviour {

    public GUIStyle introCard;

    void OnGUI()
    {
        //Displays clickable intro card
        if (GUI.Button(new Rect(0, 0, 320, 480), "", introCard))
        {
            //Return to Main menu scene to continue game
            SceneManager.LoadScene("RootGameScreen");
        }
    }

}
