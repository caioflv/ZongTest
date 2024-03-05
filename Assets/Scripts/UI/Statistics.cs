using System;
using TMPro;
using UnityEngine;

namespace ZongGameTest
{
    public class Statistics : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _statisticsName;
        [SerializeField] private TextMeshProUGUI _statisticsValue;

        private TimeSpan _timePlayed;
        private int _maxScore;
        private int _enemiesDefeated;
        private int _deaths;
        private int _spheresFound;

        //Simple player stats screen. In a minimalist way, I used two text components next to each other.
        //The first with the names and the second with their respective values.
        //An adjustment was made to the distance between lines resulting in a perfect fit between names and values.
        private void Awake()
        {
            _timePlayed = new TimeSpan().Add(TimeSpan.FromSeconds(100));

            _maxScore = 128;
            _enemiesDefeated = 0;
            _deaths = 2;
            _spheresFound = 1;

            _statisticsName.text = GetNames();
            _statisticsValue.text = GetValues();
        }

        private string GetNames()
        {
            string result = "";
            result += $"Time Played :\n";
            result += $"MaxScore :\n";
            result += $"EnemiesDefeated :\n";
            result += $"Deaths :\n";
            result += $"SpheresFound :";

            return result;
        }

        public string GetValues()
        {
            string result = "";
            result += $"{ _timePlayed.ToString(@"hh\:mm\:ss")}\n";
            result += $"{_maxScore}\n";
            result += $"{_enemiesDefeated}\n";
            result += $"{_deaths}\n";
            result += $"{_spheresFound}";

            return result;
        }
    }

}

