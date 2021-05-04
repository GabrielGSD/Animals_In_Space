using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDestroy : MonoBehaviour
{
    Animais[] animais;

    void Start()
    {
        animais = GameObject.FindObjectsOfType<Animais>();

        foreach (Animais anm in animais)
        {
            anm.Deletar();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
