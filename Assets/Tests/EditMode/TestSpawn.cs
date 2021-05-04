using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tests
{
    public class TestSpawn
    {

        private GameObject[] spawnPointsAnimals;
        private GameObject[] spawnPointsPowers;

        [SetUp]
        public void setUp()
        {
            EditorSceneManager.OpenScene("Assets/Scenes/Main.unity");

            spawnPointsAnimals = GameObject.FindGameObjectsWithTag("spawnAnimals");
            spawnPointsPowers = GameObject.FindGameObjectsWithTag("spawnPower");
        }

        [Test]
        public void testNumbersSpawnPointAnimal()
        {
            Assert.AreEqual(18, spawnPointsAnimals.Length);
        }

        [Test]
        public void testNumbersSpawnPointPower()
        {
            Assert.AreEqual(5, spawnPointsPowers.Length);
        }

    }
}
