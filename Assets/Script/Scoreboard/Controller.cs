using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Scoreboard;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    GameSession gameSession;
    [SerializeField] Scoreboard scoreboard;
    ScoreboardEntryData entryData = new ScoreboardEntryData();
    
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        if(gameSession.placarAlien1 > gameSession.placarAlien2) {

            entryData.entryName = gameSession.nomeAlien1;
            entryData.entryScore = gameSession.placarAlien1;
            
            scoreboard.AddEntry(entryData);

        }
        else if(gameSession.placarAlien1 < gameSession.placarAlien2) {

            entryData.entryName = gameSession.nomeAlien2;
            entryData.entryScore = gameSession.placarAlien2;

            scoreboard.AddEntry(entryData);
        }
        else {

            entryData.entryName = gameSession.nomeAlien1;
            entryData.entryScore = gameSession.placarAlien1;

            entryData.entryName = gameSession.nomeAlien2;
            entryData.entryScore = gameSession.placarAlien2;

            scoreboard.AddEntry(entryData);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7)){
            entryData.entryName = gameSession.nomeAlien1;
            entryData.entryScore = gameSession.placarAlien1;
            scoreboard.AddEntry(entryData);
        }
    }

    public void CarregarScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
