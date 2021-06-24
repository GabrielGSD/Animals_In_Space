using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.utils;

namespace Assets.Scripts
{
    public abstract class FabricaAleatoria : MonoBehaviour
    {
        protected List<Vector3> spawnPoints;
        [SerializeField]
        protected int spawnPointsNum;
        protected bool gerarOrdem = false;
        protected int contOrdemSpawn;
        protected List<int> ordemSpawn;
        protected int cont = 0;

        //Metodo interno para obter posicao
        protected int definirPosicao() {

            if (!gerarOrdem) {
                ordemSpawn = GeraNumUtil.getUniqueRandomArray(0, spawnPointsNum, spawnPointsNum);
                contOrdemSpawn = 0;
            } else if (contOrdemSpawn == ordemSpawn.Count - 1) {
                gerarOrdem = false;
            }
            return ordemSpawn[contOrdemSpawn++];
        }
        public abstract void criaInstancia();
    }
}