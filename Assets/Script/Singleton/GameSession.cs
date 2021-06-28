using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    //player 1
    public string nomeAlien1;
    public int placarAlien1;

    //player 2
    public string nomeAlien2;
    public int placarAlien2;


    //Implementacao do singleton para o GameSession
    void Awake() {
        if (FindObjectsOfType<GameSession>().Length > 1) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

}
