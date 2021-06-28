using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets.Scripts.Scoreboard;

public class TelaFinal : MonoBehaviour
{

    [SerializeField]
	Sprite[] sprites;

    [SerializeField]
	Image Imagem;

    GameSession gameSession;
    
    [SerializeField]
    Scoreboard scoreboard;
    ScoreboardEntryData entryData;
    
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        if(gameSession.placarAlien1 == gameSession.placarAlien2){
            Imagem.sprite = sprites[0];

            entryData.entryName = gameSession.nomeAlien1;
            entryData.entryScore = gameSession.placarAlien1;

            entryData.entryName = gameSession.nomeAlien2;
            entryData.entryScore = gameSession.placarAlien2;

            scoreboard.AddEntry(entryData);
        }
        else if(gameSession.placarAlien1 > gameSession.placarAlien2){
            Imagem.sprite = sprites[2];

            entryData.entryName = gameSession.nomeAlien1;
            entryData.entryScore = gameSession.placarAlien1;
            scoreboard.AddEntry(entryData);
            
        }else {
            Imagem.sprite = sprites[3];

            entryData.entryName = gameSession.nomeAlien2;
            entryData.entryScore = gameSession.placarAlien2;
            scoreboard.AddEntry(entryData);
        }

        StartCoroutine(loadRanking());
    }

    private IEnumerator loadRanking() {
        yield return new WaitForSeconds(5f);
        scoreboard.gameObject.SetActive(true);
    }

    public void CarregarScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
