using System.IO;
using UnityEngine;

namespace Assets.Scripts.Scoreboard {
    public class Scoreboard : MonoBehaviour
    {
        [SerializeField] private int maxScoreboardEntries = 5;
        [SerializeField] private Transform highScoresHolderTransform = null;
        [SerializeField] private GameObject scoreboardEntryObject = null;

        [Header("Test")]
        [SerializeField] ScoreboardEntryData testEntryData = new ScoreboardEntryData();

        private string SavePath => $"{Application.persistentDataPath}/highScores.json";

        private void Start() {
            ScoreboardSaveData savedScores = GetSavedScores();

            UpdateUI(savedScores);

            SaveScores(savedScores);
        }

        [ContextMenu("Add Test Entry")]
        public void AddTestEntry() {
            AddEntry(testEntryData);
        }

        private void AddEntry(ScoreboardEntryData scoreboardEntryData) {
            ScoreboardSaveData savedScores = GetSavedScores();

            bool scoreAdded = false;

            for (int i = 0; i < savedScores.highScores.Count; i++) 
            {
                if(scoreboardEntryData.entryScore > savedScores.highScores[i].entryScore) {
                    savedScores.highScores.Insert(i, scoreboardEntryData);
                    scoreAdded = true;
                    break;
                }
            }
            
            if(!scoreAdded && savedScores.highScores.Count < maxScoreboardEntries)  {
                savedScores.highScores.Add(scoreboardEntryData);
            }

            if(savedScores.highScores.Count > maxScoreboardEntries) {
                savedScores.highScores.RemoveRange(maxScoreboardEntries, savedScores.highScores.Count - maxScoreboardEntries);
            }

            UpdateUI(savedScores);
            SaveScores(savedScores);

        }

        private void UpdateUI(ScoreboardSaveData savedScores) {
            foreach (Transform child in highScoresHolderTransform) {
                Destroy(child.gameObject);
            }

            foreach (ScoreboardEntryData highScore in savedScores.highScores){
                Instantiate(scoreboardEntryObject, highScoresHolderTransform).GetComponent<ScoreboardEntryUI>().Initialise(highScore);
            }
        }

        private ScoreboardSaveData GetSavedScores() {
            if(!File.Exists(SavePath)) {
                File.Create(SavePath).Dispose();
                return new ScoreboardSaveData();
            }

            using (StreamReader stream = new StreamReader(SavePath)) {
                string json = stream.ReadToEnd();
                return JsonUtility.FromJson<ScoreboardSaveData>(json);
            }
        }

        private void SaveScores(ScoreboardSaveData scoreboardSaveData) {
            using(StreamWriter stream = new StreamWriter(SavePath)){
                string json = JsonUtility.ToJson(scoreboardSaveData, true);
                stream.Write(json);
            }
        }

    }
}

