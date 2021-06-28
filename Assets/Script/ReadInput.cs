using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;
    [SerializeField] private GameSession gsession;  

    public void readStringInput(string s) {
        input = s;
    }

    public void SubmitName(string alien) {
        if(alien == "alien_1") {
            gsession.nomeAlien1 = input;
        }
        else if(alien == "alien_2") {
            gsession.nomeAlien2 = input;
        }
    }
}
