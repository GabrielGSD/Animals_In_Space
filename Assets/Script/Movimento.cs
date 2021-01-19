using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

    public float moveSpeed = 1.5f;

    private Vector3 vetorEscalaObj = new Vector2(0.02f, 0.02f);

    void Update()
    {
        var vector = new Vector2(Time.deltaTime * moveSpeed, 0);
        gameObject.transform.Translate(vector,Space.World);
    }

    //Destruir objeto caso saia da scene
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Destruir"))
        {
          Destroy(gameObject);
        }
    }
}
