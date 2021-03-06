using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Power {
    public class CriadorPoder : FabricaAleatoria
    {

        [SerializeField]
        List<GameObject> poderes;

        public override void criaInstancia()
        {
            int pos = definirPosicao();

            if (cont == poderes.Count)
                cont = 0;
            Instantiate(poderes[cont++], spawnPoints[pos], Quaternion.identity);
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
