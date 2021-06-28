using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Animal
{
    public class CriadorAnimal : FabricaAleatoria
    {
        [SerializeField]
        List<Animais> animais; 
        HashSet<Animais> animaisRepetidos = new HashSet<Animais>();
        [SerializeField]
        List<Animais> animaisSpawn;

        public override void criaInstancia()
        {
            if (cont == animais.Count)
                cont = 0;
            
            if(animaisSpawn.Count == spawnPoints.Count) {
                DestroyAnimals();
                
            }
            getAllAnimais();
            spawnAnimais();
        }

        private void spawnAnimais() {
            for (int i=0; i<spawnPoints.Count; i++)
            {
                Instantiate(animaisSpawn[i], spawnPoints[i], Quaternion.identity);
            }
        }

        private void getAllAnimais() {
            
            for(int i=0; i<=spawnPoints.Count; i++){
                shuffle();
                foreach (Animais anm in animaisRepetidos){
                    if(animaisSpawn.Count < spawnPoints.Count) {
                       animaisSpawn.Add(anm); 
                    }
                }
                animaisRepetidos.Clear();
            }
         }

        private void shuffle() {
            for(int i = 0; i < animais.Count; i++) {
                int j = Random.Range(0, animais.Count);
                while(!animaisRepetidos.Contains(animais[j])) {
                    animaisRepetidos.Add(animais[j]);
                } 
            }
        }

        private void DestroyAnimals() {
            Animais[] anm = GameObject.FindObjectsOfType<Animais>();
            foreach (Animais anim in anm)
            {
                anim.Deletar();
            }
            animaisSpawn.Clear();
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
