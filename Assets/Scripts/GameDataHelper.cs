using UnityEngine;

namespace ToTheHeights
{
    public class GameDataHelper : MonoBehaviour
    {
        [SerializeField] private float _speedModif = 1.47f;
        [SerializeField] private int _heightSpeedModif = 150;
        [SerializeField] private UIHelper _helper;

        private int _startLifeCount = 2;
        private int _currentLifeCount = 2;
        private float _startSpeed = 0f;
        private float _startHeight = 15f;
        private float _currentHeight = 15f;
        private float _currentSpeed = 0f;

        public int SetCurrentLifeCount //todo :\
        {
            get => _currentLifeCount; 
            set => _currentLifeCount = value;
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
            _helper.SetCurrentLifeCountView = _startLifeCount;
            _helper.SetHeight = _startHeight;
            _helper.SetSpeed = _startSpeed;
        }  
        private void UpdateGameStats()
        {
            _helper.SetCurrentLifeCountView = _currentLifeCount;
            _helper.SetHeight = _currentHeight;
            _helper.SetSpeed = _currentSpeed;
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