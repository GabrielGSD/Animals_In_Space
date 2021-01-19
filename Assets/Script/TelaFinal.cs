using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TelaFinal : MonoBehaviour
{

    [SerializeField]
	Sprite[] sprites;

    [SerializeField]
	Image Imagem;

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        if(gameSession.placarAlien1 == gameSession.placarAlien2){
            Imagem.sprite = sprites[0];
        }else if(gameSession.placarAlien1 > gameSession.placarAlien2){
            Imagem.sprite = sprites[1];
        }else {
            Imagem.sprite = sprites[2];
        }
    }

    public void CarregarScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
