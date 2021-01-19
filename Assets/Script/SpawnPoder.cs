using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnPoder : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] poderes;

    public List<GameObject> repetido = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPower());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPower()
    {

        if(repetido.Count == poderes.Length){
            repetido.Clear();
        }

        var point = Random.Range(0, spawnPoints.Length);
        var power = Random.Range(0, poderes.Length);

        while(repetido.Contains(poderes[power])){
            power = Random.Range(0, poderes.Length);
        } 

        repetido.Add(poderes[power]);
        Instantiate(poderes[power], spawnPoints[point].position, spawnPoints[point].rotation);

        print(power + " " + point);

        yield return new WaitForSeconds(Random.Range(15f, 30f));
        StartCoroutine(SpawnPower());
    }
}
