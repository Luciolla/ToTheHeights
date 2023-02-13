using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using Image = UnityEngine.UI.Image;

namespace ToTheHeights
{
    public class UIHelper : MonoBehaviour
    {
        private int _currentLifeCountView = 2;
        private float _currentHeight = 1f;
        private float _currentSpeed = 0f;
        private bool isMenuActive = false;

        [SerializeField] private TMP_Text _heightText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private List<Image> _lifeImages;
        [SerializeField] private GameObject _menuPanel;

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
            _heightText.text = System.MathF.Round(_currentHeight, 2).ToString();
        }

        public void OpenSettings()
        {
            isMenuActive = !isMenuActive;
            _menuPanel.gameObject.SetActive(isMenuActive);

            var timeStop = isMenuActive ? Time.timeScale = 0.00001f : Time.timeScale = 1f;
        }

        public void ExitGame()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
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