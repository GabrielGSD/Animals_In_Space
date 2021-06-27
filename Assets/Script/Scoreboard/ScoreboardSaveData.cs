using System;
using System.Collections.Generic;

namespace Assets.Scripts.Scoreboard {
    [Serializable]
    public class ScoreboardSaveData
    {
        public List<ScoreboardEntryData> highScores = new List<ScoreboardEntryData>(); 
    }
}

