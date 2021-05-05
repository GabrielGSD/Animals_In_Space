using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class AlienTest
    {
        private GameObject alien_1, alien_2;

        [UnitySetUp]
        public IEnumerator setUp()
        {
            SceneManager.LoadScene("Main");
            yield return new WaitForFixedUpdate();
            alien_1 = GameObject.Find("Alien1");
            alien_2 = GameObject.Find("Alien2");
        }

        [UnityTest]
        public IEnumerator testNumbersAliens()
        {
            Alien[] aliens_count = GameObject.FindObjectsOfType<Alien>();

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(2, aliens_count.Length);
        }

        [UnityTest]
        public IEnumerator testCollider()
        {
            Assert.NotNull(alien_1.GetComponent<CapsuleCollider2D>(), "Alien1 has a Collider attached");

            yield return new WaitForFixedUpdate();

            Assert.NotNull(alien_2.GetComponent<CapsuleCollider2D>(), "Alien2 has a Collider attached");
        }

        [UnityTest]
        public IEnumerator testScoreAlien()
        {
            Assert.AreEqual(0, alien_1.GetComponent<Alien>().pontos);

            yield return new WaitForFixedUpdate();

            Assert.AreEqual(0, alien_2.GetComponent<Alien>().pontos);
        }

        [UnityTest]
        public IEnumerator testPowerAlien()
        {
            Assert.IsFalse(alien_1.GetComponent<Alien>().temPower);

            yield return new WaitForFixedUpdate();

            Assert.IsFalse(alien_2.GetComponent<Alien>().temPower);
        }
    }
}
