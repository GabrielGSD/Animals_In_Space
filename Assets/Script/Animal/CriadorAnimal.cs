using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Animal
{
    public class CriadorAnimal : FabricaAleatoria
    {
        [SerializeField]
        List<Animais> animais; 

        public override void criaInstancia()
        {
            int pos = definirPosicao();

            if (cont == animais.Count)
                cont = 0;
            Instantiate(animais[cont++], spawnPoints[pos], Quaternion.identity);
        }

        void Start()
        {
            spawnPoints = new List<Vector3>();
            foreach (Transform spawnPoint in transform) {
                spawnPoints.Add(spawnPoint.position);
            }
            spawnPointsNum = spawnPoints.Count;
        }
    }
}
