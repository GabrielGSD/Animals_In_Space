using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class TestCronometro
    {
        private UI cronometro;

        [SetUp]
        public void setUp()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");
            cronometro = GameObject.Find("AnimalText").GetComponent<UI>();
        }

        [Test]
        public void testTextTimer()
        {
            Assert.IsTrue(GameObject.FindWithTag("Cronometro"));
        }

        [Test]
        public void testTimerStarted()
        {
            Assert.AreEqual(expected: 3, actual: cronometro.aux);
        }
    }
}
