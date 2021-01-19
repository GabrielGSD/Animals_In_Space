using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyAnimal : MonoBehaviour
{
    public float secondsToDestroy;   
    private void Start() {
        secondsToDestroy = Random.Range(9f, 9f);
        Destroy(this.gameObject, secondsToDestroy);
    }
}
