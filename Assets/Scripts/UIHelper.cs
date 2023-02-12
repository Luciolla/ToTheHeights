using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ToTheHeights
{
    public class UIHelper : MonoBehaviour
    {
        private int _currentLifeCountView = 2;
        private float _currentHeight = 1f;
        private float _currentSpeed = 0f;

        [SerializeField] private TMP_Text _heightText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private List<Image> _lifeImages;

        public static UIHelper instance { get; set; }
        public int SetCurrentLifeCountView
        {
            set { _currentLifeCountView = value; }
        }

        public float SetHeight
        {
            set { _currentHeight = value; }
        }

        public float SetSpeed
        {
             set { _currentSpeed = value; }
        }

        private void Start()
        {
            instance = this;
            StartCoroutine(UIRelevanceCheckerRutine());
        }

        private void Update()
        {
            _speedText.text = System.MathF.Round(_currentSpeed, 2).ToString();
            Debug.Log(_currentSpeed + " " + _currentHeight);
            _heightText.text = System.MathF.Round(_currentHeight, 2).ToString();
        }

        private IEnumerator UIRelevanceCheckerRutine()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(2f);

                switch (_currentLifeCountView) //todo it works, but make it look nice
                {
                    case 0:
                        _lifeImages[_currentLifeCountView].gameObject.SetActive(false);
                        break;
                    case 1:
                        _lifeImages[_currentLifeCountView - 1].gameObject.SetActive(true);
                        _lifeImages[_currentLifeCountView].gameObject.SetActive(false);
                        break;
                    case 2:
                        _lifeImages[_currentLifeCountView - 1].gameObject.SetActive(true);
                        _lifeImages[_currentLifeCountView ].gameObject.SetActive(false);
                        break;
                    case 3:
                        _lifeImages[_currentLifeCountView-1].gameObject.SetActive(true);
                        break;
                }
            }
        }
    }
}