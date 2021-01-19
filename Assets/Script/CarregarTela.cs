using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Add essa biblioteca para trocar de scene
using UnityEngine.UI;

public class CarregarTela : MonoBehaviour {

    public void CarregarScene(string nomeScene)
    {
        SceneManager.LoadScene(nomeScene);
        Time.timeScale = 1;
    }

}

    