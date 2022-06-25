using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    [SerializeField]
    Ship ship;

    [SerializeField]
    SceneNavigator sceneNavigator;

    void OnPlayersShipCompletelyBreak()
    {
        sceneNavigator.GoToScore();
    }


    void Start()
    {
        ship.OnCompletelyBreak += OnPlayersShipCompletelyBreak;
    }
}
