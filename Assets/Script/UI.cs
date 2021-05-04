using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField]
    string[] nomeAnimais;

    [SerializeField]
    Alien[] alien;

    //Tags sprites
    public string tag_sprite = "sprite";

    public Text Palavra;

    public Text Cronometro;

    GameObject plastico;

    public AudioClip[] shootSound;
    public AudioSource audioObj;
    int indicePalavraAnterior;

    public float cronometro = 59f;
    public int aux = 3;
    public int fim = 0;


    // Use this for initialization
    void Start()
    {
        Palavra = GameObject.FindWithTag("AnimalText").GetComponent<Text>();
        Cronometro = GameObject.FindWithTag("Cronometro").GetComponent<Text>();
        InvokeRepeating("SetNome", 0.0f, Random.Range(10f, 25f)); // tempo para mudar a sprite
        audioObj = GetComponent<AudioSource>();
        indicePalavraAnterior = Random.Range(0, nomeAnimais.Length);
    }

    // Update is called once per frame
    void Update()
    {
        if (cronometro > 0f)
        {
            cronometro -= Time.deltaTime;
            Cronometro.text = aux + ":" + cronometro.ToString("F0");

        }
        else
        {
            aux--;
            cronometro = 59.0f;
            fim++;
        }

        if (aux == -1 && fim == 4)
        {
            Time.timeScale = 0;
            SalvaPlacar();
            SceneManager.LoadScene("TelaVitoria");
        }

    }

    public void SetNome()
    {
        int indicePalavraAtual;
        do
        {
            indicePalavraAtual = Random.Range(0, nomeAnimais.Length);
        } while (indicePalavraAtual == indicePalavraAnterior);
        indicePalavraAnterior = indicePalavraAtual;

        Palavra.text = nomeAnimais[indicePalavraAtual];

        foreach (AudioClip clip in shootSound)
        {
            if (clip.name == nomeAnimais[indicePalavraAtual])
                audioObj.PlayOneShot(clip);
        }

        foreach (Alien player in alien)
        {
            player.Animais_Tag = Palavra.text;
        }
    }

    public void PlayPalavra()
    {
        foreach (AudioClip clip in shootSound)
        {
            if (clip.name == Palavra.text)
                audioObj.PlayOneShot(clip);
        }

        delayFunc(5f);
    }

    IEnumerator delayFunc(float time)
    {
        yield return new WaitForSeconds(time);
    }

    void SalvaPlacar()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        gameSession.placarAlien1 = alien[0].pontos;
        gameSession.placarAlien2 = alien[1].pontos;
    }
}
