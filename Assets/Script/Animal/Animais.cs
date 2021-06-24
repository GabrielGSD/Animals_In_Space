using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animais : MonoBehaviour
{
    //Referencia para o GO da animacao do texto
    [SerializeField]
    Transform pontuacaoAnimacao;

    //Referencia para os sprites (-1,1,2)
    [SerializeField]
    Sprite[] pontuacaoSprites;

    //O valor dos pontos desse animal
    [SerializeField]
    private int _ponto;
    public int Ponto { get { return _ponto; } }

    public void ExecutaAnimacao(int indexSprite)
    {
        Transform pontuacaoClone = Instantiate(pontuacaoAnimacao, transform.position, transform.rotation);
        pontuacaoClone.GetChild(0).GetComponent<SpriteRenderer>().sprite = pontuacaoSprites[indexSprite];
        Destroy(pontuacaoClone.gameObject, 1.0f);
    }

    public void Deletar()
    {
        Destroy(gameObject);
    }
}

