using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    Ship ship;

    [SerializeField]
    SceneNavigator sceneNavigator;
    [SerializeField]
    TimeManager timeManager;

    void OnPlayersShipCompletelyBreak()
    {
        timeManager.Stop();
        ScoreManager.SetTime(timeManager.GetTime());
        sceneNavigator.GoToScore();
    }


    void Start()
    {
        ship.OnCompletelyBreak += OnPlayersShipCompletelyBreak;
    }
}
