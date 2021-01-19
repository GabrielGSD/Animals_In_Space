using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UI_SelectAlien : MonoBehaviour
{

    [SerializeField]
	Sprite[] spriteAliens;

    [SerializeField]
	Image ImagemAliens;

    [SerializeField]
	Sprite[] spriteElipse;

    [SerializeField]
	Image[] ImagemElipse;

    string analogicoHor = "", analogicoVer = "";
    KeyCode keyCodeA, keyCodeX;

    int index = 0;
    bool act = false;

    // Start is called before the first frame update
    void Start()
    {
        if (transform.CompareTag("Alien1")) {
            analogicoHor = "Left Analog Horizontal";
            analogicoVer = "Left Analog Vertical";

		} else {
            analogicoHor = "Left Analog Horizontal 2";
            analogicoVer = "Left Analog Vertical 2";
		}
        ImagemAliens.sprite = spriteAliens[index];
        ImagemElipse[0].sprite = spriteElipse[1];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7)){
            SceneManager.LoadScene("Main");
        }

        if (Input.GetAxis(analogicoHor) == 1 && index <= 4 && !act) {
            if(index<=2){
                index++;
                ImagemAliens.sprite = spriteAliens[index];
                ImagemElipse[index].sprite = spriteElipse[1];
                ImagemElipse[index-1].sprite = spriteElipse[0];
                act = true;
            }
            StartCoroutine(DelaySelec());
        }
        else if (Input.GetAxis(analogicoHor) == -1 && index >= 0 && !act) {
            if(index>=1){
                index--;
                ImagemAliens.sprite = spriteAliens[index];
                ImagemElipse[index].sprite = spriteElipse[1];
                ImagemElipse[index+1].sprite = spriteElipse[0];
                act = true;
            }
            StartCoroutine(DelaySelec());
        }

    }

    IEnumerator DelaySelec()
	{
		yield return new WaitForSeconds(0.2f);
        act = false;
	}
}
