using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        
        PlayerPrefs.SetFloat("HighScore", 0);
        ////////////money reset//////////////
        //PlayerPrefs.SetFloat("Currency", 0);
        ////////////////////////////////////


        #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }
}
