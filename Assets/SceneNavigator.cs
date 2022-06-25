using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigator : MonoBehaviour
{
    public void GoToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToCreate()
    {
        SceneManager.LoadScene("Create");
    }

    public void GoToScore()
    {
        SceneManager.LoadScene("Score");
    }
}
