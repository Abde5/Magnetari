using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour {

    public void GoToWin(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ActivatePanel(GameObject itemToActivate)
    {
        if (!itemToActivate.active)
        {
            itemToActivate.SetActive(true);
        }
        else
        {
            itemToActivate.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
