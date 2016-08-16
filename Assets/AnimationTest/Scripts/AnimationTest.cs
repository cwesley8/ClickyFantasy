using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimationTest : MonoBehaviour
{
    void OnGUI()
    {
        //Displays clickable intro card
        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            //Return to Main menu scene to continue game
            SceneManager.LoadScene("Roster");
        }
    }

}
