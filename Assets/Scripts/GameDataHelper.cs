using System;
using UnityEngine;

namespace ToTheHeights
{
    public class GameDataHelper : MonoBehaviour
    {
        private int _startLifeCount = 2;
        private int _currentLifeCount = 2;
        private float _startSpeed = 0f;
        private float _startHeight = 15f;
        private float _currentHeight = 15f;
        private float _currentSpeed = 0f;

        [SerializeField] private float _speedModif = 1.45f;
        [SerializeField] private int _heightSpeedModif = 100;

        public int SetCurrentLifeCount //todo :\
        {
            get { return _currentLifeCount; }
            set { _currentLifeCount = value; }
        }

        private void Start()
        {
            StartGameStats();
        }

        private void Update()
        {
            UpdateGameStats();
            StartFlight();
        }

        private void StartGameStats()  //todo - it works, but make it look nice
        {
            _currentLifeCount = _startLifeCount;
            UIHelper.instance.SetCurrentLifeCountView = _startLifeCount;
            UIHelper.instance.SetHeight = _startHeight;
            UIHelper.instance.SetSpeed = _startSpeed;
        }  
        private void UpdateGameStats()
        {
            UIHelper.instance.SetCurrentLifeCountView = _currentLifeCount;
            UIHelper.instance.SetHeight = _currentHeight;
            UIHelper.instance.SetSpeed = _currentSpeed;
        }

        //todo separate to another class
        private void StartFlight() //todo fix constants
        {
            if (Time.timeScale < 1f) return;
            _currentHeight += _currentSpeed/_heightSpeedModif;
            _currentSpeed += _speedModif;
        }
    }
}