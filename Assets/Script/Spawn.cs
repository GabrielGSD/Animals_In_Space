using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawn : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] objetos;
    public List<GameObject> animals = new List<GameObject>();
    public List<int> animRepetido = new List<int>();


    void Start()
    {
        StartCoroutine(SpawnObj());
    }

    void FixedUpdate()
    {
        
    }
    
    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space)){
            
        }
        
    }


// Adicionar um script ao spawnar o animal, esse script irá deletar o animal
    IEnumerator SpawnObj()
    {
        for (int i = 0; i < spawnPoints.Count(); i++)
        {
            var anim = Random.Range(0,objetos.Length);
            if(animRepetido.Contains(anim)){
                while(!animRepetido.Contains(anim)){
                    anim = Random.Range(0,objetos.Length);
                }
                animRepetido.Add(anim);
                Instantiate(objetos[anim], spawnPoints[i].position, spawnPoints[i].rotation);
                animals.Add(objetos[anim]);
            }else {
                animRepetido.Add(anim);
                Instantiate(objetos[anim], spawnPoints[i].position, spawnPoints[i].rotation);
                animals.Add(objetos[anim]);
            }
            if(animRepetido.Count()==objetos.Length){
                animRepetido.Clear();
            }
        }

        yield return new WaitForSeconds(9f);
        StartCoroutine(SpawnObj());
    }

}