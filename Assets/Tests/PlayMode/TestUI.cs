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
    }
}
