using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    public Texture backgroundTexture;

    void OnGUI()
    {
        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.5f, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
        }
    }
}
