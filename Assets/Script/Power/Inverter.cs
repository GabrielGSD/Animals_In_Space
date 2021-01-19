using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : MonoBehaviour, IPowerUP {

    [SerializeField]
    Transform inverterAnimado;

    Alien target;

    public void ExecutePowerUP(Alien target) {
        this.target = target;
        AtivarInverter();
    }

    //Funcao para inverter
    IEnumerator InverterCD(Transform inveterAnimadoClone) {
        yield return new WaitForSeconds(10.0f);
        target.Inverter = 1.0f;
        Destroy(inveterAnimadoClone.gameObject);
    }

    //Metodo chamado pelo Alien inimigo para ativar o processo de inverter
    void AtivarInverter() {
        //Ativar o sprite do inverter animado
        target.Inverter = -1.0f;
        Transform inverterAnimadoClone = Instantiate(inverterAnimado, new Vector3(target.transform.position.x, target.transform.position.y + 1.5f, target.transform.position.z), 
            Quaternion.identity, target.transform);
        StartCoroutine(InverterCD(inverterAnimadoClone));
    }
}
