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
            InvokeRepeating("buscaAnimal", 0f, Random.Range(17f, 25f));
            InvokeRepeating("buscaPoder", 1f, Random.Range(25f, 35f));
        }

        void buscaAnimal() { 
            criadorAnimal.criaInstancia();
        }

        void buscaPoder() { 
            criadorPoder.criaInstancia();
        }
    }
}
