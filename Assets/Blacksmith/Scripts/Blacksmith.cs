using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Blacksmith : MonoBehaviour
{
    public Texture backgroundTexture;

    public float blacksmithTitlePosX;
    public float blacksmithTitlePosY;

    public Vector2 scrollPosition = Vector2.zero;

    void OnGUI()
    {


        //Display background texture 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        //Display title of new page
        GUI.Label(new Rect(Screen.width * blacksmithTitlePosX, Screen.height * blacksmithTitlePosY, Screen.width * .5f, Screen.height * .1f), "Blacksmith");

        if (GUI.Button(new Rect(Screen.width * 0.25f, Screen.height * 0.875f, Screen.width * .5f, Screen.height * .1f), "Return"))
        {
            //Return to root game screen
            SceneManager.LoadScene("RootGameScreen");
        }

        /*using (var scrollScope = new GUI.ScrollViewScope(new Rect(10, 30, 310, 390), scrollPosition, new Rect(0, 0, 310, 100)))
        {
            scrollPosition = scrollScope.scrollPosition;

        }*/
    }


}
