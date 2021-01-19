using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Velocidade : MonoBehaviour, IPowerUP {

    Alien target;

    public void ExecutePowerUP(Alien target) {
        this.target = target;
        AtivarVelocidade();
    }

    void AtivarVelocidade() {
        StartCoroutine(AumentarVelocidade());
        target.PlayerRunSpeed = 15.0f;
    }

    //Metodo para aumentar a velocidade do Alien
    IEnumerator AumentarVelocidade() {
        yield return new WaitForSeconds(10.0f);
        target.PlayerRunSpeed = 10.0f;
    }

   
}
