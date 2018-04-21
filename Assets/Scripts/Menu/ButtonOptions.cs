using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOptions : MonoBehaviour {
    /*
     * Manages all available scenes to be loaded
     * Functions must be called from button click event (selected within unity)
     * If the scenes order is changed on the build settings, the load scene value
     * ---MUST BE CHANGED!---
     */

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Below here are track selection buttons

    public void Track01()
    {
        SceneManager.LoadScene(1);
    }
}
