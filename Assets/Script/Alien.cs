using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Alien : MonoBehaviour
{

    //constantes
    const string TAG_POWER_DOWN = "PowerDown";
    const string TAG_POWER_UP = "PowerUp";

    [SerializeField]
    [Range(10, 30)]
    float playerRunSpeed;

    [SerializeField]
    Alien alienInimigo;

    //Referencia para o UI 
    GameObject _ui;

    //Referencia para o UI_PODER. UI que tem as imagens dos poderes
    [SerializeField]
    UiPoder _ui_Poder;

    //Referencia para a UI que seta o audio da palavra
    [SerializeField]
    UI _ui_Palavra;

    //Referencia para a tag dos animais que deve ser pego
    public string Animais_Tag { get; set; }

    //Referencia para o sprite inverter
    [SerializeField]
    GameObject inverterAnimado;

    public Text alienText;

    SpriteRenderer mySpriteRenderer;

    public int pontos { get; set; }

    public float vrau;

    //Referencia para o corpo rigido
    Rigidbody2D PlayerRB;
    //Referencia para o animator
    public Animator anim;
    //Referencia para a velocidade do Alien
    public float Alienspeed;
    //Referencia para o collider
    public CapsuleCollider2D playerCapCollider;
    //Referencia para o sprite renderer
    SpriteRenderer playerSpriteRenderer;
    //Powerup pego
    IPowerUP powerUP;

    //Definicao de controle
    KeyCode keyCodeA, keyCodeX, keyCodeRB;

    //variaveis de controle 
    float playerXDir;
    float playerYDir;
    bool BotaoX;
    bool BotaoRB;
    bool playPalavra = false;
    bool A, BotaoA;
    bool auxiliarCongelado = false;
    public bool temPowerUP = false, temPowerDown = false, temPower = false;
    public bool auxiliarInverter = false;
    bool auxiliarVel = false;
    bool auxiliarMult = false;
    bool Mult_Pts = false;
    public bool cegar = false;

    //Propriedades
    public float PlayerRunSpeed { get; set; }
    public float Inverter { get; set; }

    //Diferenciar controles de cada player
    string analogicoHor = "", analogicoVer = "";

    // Use this for initialization
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        playerCapCollider = GetComponent<CapsuleCollider2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();

        pontos = 0;

        PlayerRunSpeed = 10.0f;
        Inverter = 1.0f;
        _ui = GameObject.Find("Image_Lixo");

        if (transform.CompareTag("Alien1"))
        {
            analogicoHor = "Left Analog Horizontal";
            analogicoVer = "Left Analog Vertical";
            alienText = GameObject.FindWithTag("Score1").GetComponent<Text>();
            keyCodeA = KeyCode.Joystick1Button0;
            keyCodeX = KeyCode.Joystick1Button2;
            keyCodeRB = KeyCode.Joystick1Button5;

        }
        else
        {
            analogicoHor = "Left Analog Horizontal 2";
            analogicoVer = "Left Analog Vertical 2";
            alienText = GameObject.FindWithTag("Score2").GetComponent<Text>();
            keyCodeA = KeyCode.Joystick2Button0;
            keyCodeX = KeyCode.Joystick2Button2;
            keyCodeRB = KeyCode.Joystick2Button5;
        }
    }

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        BotaoA = Input.GetKey(keyCodeA);
        BotaoX = Input.GetKeyDown(keyCodeX);
        BotaoRB = Input.GetKeyDown(keyCodeRB);

        // //Left Analog Vertical
        // playerXDir = Input.GetAxis(analogicoHor) * Time.deltaTime * PlayerRunSpeed * Inverter;
        // playerYDir = Input.GetAxis(analogicoVer) * Time.deltaTime * PlayerRunSpeed * Inverter;

        Vector3 movement = new Vector3(Input.GetAxis(analogicoHor), Input.GetAxis(analogicoVer), 0f);

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * PlayerRunSpeed * Inverter * Time.deltaTime;

        Mover();

        if (temPower && BotaoX)
        {
            if (temPowerUP)
            {
                powerUP.ExecutePowerUP(this);
                temPowerUP = false;
            }
            else if (temPowerDown)
            {
                powerUP.ExecutePowerUP(alienInimigo);
                temPowerDown = false;
            }
            temPower = false;
            _ui_Poder.MudarSpritePoder("Default");
        }

        if (BotaoRB && !playPalavra)
        {
            _ui_Palavra.PlayPalavra();
            playPalavra = true;
            StartCoroutine(DelayPlayPalavra());
        }

    }

    //Metodo para mover
    private void Mover()
    {
        float xMin = -41f;
        float xMax = 43f;
        float yMin = -27.5f;
        float yMax = 27.0f;
        playerXDir = Mathf.Clamp(playerXDir, xMin, xMax);
        transform.Translate(playerXDir, playerYDir, 0);
        Vector3 tempPosition = transform.position;
        tempPosition.x = Mathf.Clamp(transform.position.x, xMin, xMax);
        tempPosition.y = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = tempPosition;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (BotaoA)
        {
            //Tratar colisao com os animais
            if (collision.tag.Equals(Animais_Tag))
            {
                if (Mult_Pts)
                    pontos += 2;
                else
                    pontos += 1;
                AtualizaPlacar(collision, 1);
            }
            else if (collision.CompareTag(TAG_POWER_UP) || collision.CompareTag(TAG_POWER_DOWN))
            {
                //print("PEGANDO O PODER");
                if (temPower)
                    Destroy(collision.gameObject);
                else
                {
                    if (collision.CompareTag("PowerUp"))
                    {
                        temPowerUP = true;
                        temPowerDown = false;
                        SetarPoder(collision);
                    }
                    else if (collision.CompareTag("PowerDown"))
                    {
                        temPowerDown = true;
                        temPowerUP = false;
                        SetarPoder(collision);
                    }
                }
            }
            else if (!collision.CompareTag(alienInimigo.tag) && !collision.CompareTag("Bg"))
            {
                if (pontos == 0)
                {
                    Destroy(collision.gameObject);
                }
                if (pontos > 0)
                {
                    pontos--;
                    AtualizaPlacar(collision, 0);
                }
            }
        }

    }

    void SetarPoder(Collider2D collision)
    {
        temPower = true;
        _ui_Poder.MudarSpritePoder(collision.gameObject.name.Replace("(Clone)", ""));
        collision.GetComponent<SpriteRenderer>().enabled = false;
        collision.GetComponent<Collider2D>().enabled = false;
        powerUP = collision.gameObject.GetComponent<IPowerUP>();
    }

    public void AtivarPontoDuplo()
    {
        StartCoroutine(Multiplicar());
        Mult_Pts = true;
    }

    public void AtivarCegar(bool state)
    {
        this.playerCapCollider.enabled = state;
    }

    IEnumerator DelayPlayPalavra()
    {
        yield return new WaitForSeconds(3.0f);
        playPalavra = false;
    }

    //Multiplicar()
    IEnumerator Multiplicar()
    {
        //yield return new WaitForSecondsRealtime(8.0f);
        yield return new WaitForSeconds(8.0f);
        Mult_Pts = false;
    }

    void AtualizaPlacar(Collider2D collision, int anim)
    {
        alienText.text = pontos.ToString();
        //collision.GetComponentInChildren<Animais>().ExecutaAnimacao(anim);
        Destroy(collision.gameObject);
    }
}
