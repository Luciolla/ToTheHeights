using UnityEngine;

namespace ToTheHeights
{
    public class GameDataHelper : MonoBehaviour
    {
        private UIHelper _helper;

        private int _startLifeCount = 2;
        private int _currentLifeCount;

        private float _startSpeed = 0f;
        private float _startHeight = 15f;
        private float _currentHeight = 15f;
        private float _currentSpeed = 0f;

        private void Start()
        {
            StartGameStats();
        }

        private void Update()
        {
            UpdateGameStats();
            StartFlight();
        }

        private void StartGameStats()
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
        private void StartFlight()
        {
            _currentHeight += _currentSpeed/10;
            _currentSpeed += 0.01f;
        }
    }
}