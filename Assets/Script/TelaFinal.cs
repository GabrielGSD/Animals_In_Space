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
    
    
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();

        if(gameSession.nomeAlien1 != "" || gameSession.nomeAlien2 != "") {

            if(gameSession.placarAlien1 == gameSession.placarAlien2){
                Imagem.sprite = sprites[0];
            }
            else if(gameSession.placarAlien1 > gameSession.placarAlien2){
                Imagem.sprite = sprites[2];
            }else {
                Imagem.sprite = sprites[3];
            }
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7)){
            SceneManager.LoadScene("Scoreboard");
        }
    }
}
