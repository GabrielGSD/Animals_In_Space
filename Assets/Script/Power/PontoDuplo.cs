using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontoDuplo : MonoBehaviour, IPowerUP {
    public void ExecutePowerUP(Alien target) {
        target.AtivarPontoDuplo();
    }
}
