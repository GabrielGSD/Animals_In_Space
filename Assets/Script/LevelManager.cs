using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField]
        FabricaAleatoria criadorAnimal, criadorPoder;

        void Awake()
        {
            InvokeRepeating("buscaPoder", 1f, Random.Range(15f, 30f));
        }

        void buscaAnimal() { 
            criadorAnimal.criaInstancia();
        }

        void buscaPoder() { 
            criadorPoder.criaInstancia();
        }
    }
}
