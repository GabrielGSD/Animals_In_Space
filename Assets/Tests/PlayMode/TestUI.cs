using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestUI
    {
        private UI ui;

        [UnitySetUp]
        public IEnumerator setUp()
        {
            SceneManager.LoadScene("Main");
            yield return new WaitForSeconds(1);
            ui = GameObject.Find("AnimalText").GetComponent<UI>();
        }

        [UnityTest]
        public IEnumerator testAudioSource()
        {
            Assert.NotNull(ui.GetComponent<AudioSource>(), "UI has an audio source attached");
            yield return new WaitForSeconds(1);
        }

        [UnityTest]
        public IEnumerator testPlayPalavra()
        {
            // SetNome() -> Setar a palavra q vai falar
            // PlayPalavra() -> Dar o play no AudioClip da palavra
            yield return new WaitForSeconds(1);
        }

        // [UnityTest]
        // public IEnumerator testEndGame()
        // {
        //     ui.aux = 0;
        //     ui.fim = 3;
        //     ui.cronometro = 4f;
        //     yield return new WaitForSeconds(5);
        //     // int idScene = SceneManager.GetActiveScene().buildIndex;
        //     // Assert.AreEqual(3, idScene);
        //     yield return new WaitForSeconds(1);

        //     int idScene = SceneManager.GetActiveScene().buildIndex;

        //     Assert.AreEqual(4, idScene);
        // }
    }
}
