using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour {

    
    public int placarAlien1;
  
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
