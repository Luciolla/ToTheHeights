using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

namespace ToTheHeights
{
    public class UIHelper : MonoBehaviour
    {
        private int _currentLifeCountView = 2;
        private float _currentHeight = 1f;
        private float _currentSpeed = 0f;
        private bool _isMenuActive = false;
        private bool _isDeathMenuActive = false;

        [Header("Список меню")]
        [SerializeField] private List<GameObject> _menuList = new();

        [SerializeField] private TMP_Text _heightText;
        [SerializeField] private TMP_Text _speedText;
        [SerializeField] private List<Image> _lifeImages;

        public static UIHelper Instance { get; private set; }

        public int SetCurrentLifeCountView
        {
            set => _currentLifeCountView = value;
        }

        public float SetHeight
        {
            set => _currentHeight = value;
        }

        public float SetSpeed
        {
             set => _currentSpeed = value;
        }

        private void Start()
        {
            Instance = this;
            StartCoroutine(UIRelevanceCheckerRutine());
        }

        private void Update()
        {
            _speedText.text = System.MathF.Round(_currentSpeed, 1).ToString() + " m/s";
            _heightText.text = System.MathF.Round(_currentHeight, 2).ToString() + " m";
        }

        public void OpenSettings()
        {
            OpenCloseMenu(_menuList[0], _isMenuActive);
            _isMenuActive = !_isMenuActive;
        }

        public void OpenDeathPanel()
        {
            OpenCloseMenu(_menuList[2], _isDeathMenuActive);
            _isDeathMenuActive = !_isDeathMenuActive;
        }

        private void OpenCloseMenu(GameObject obj, bool activity)
        {
            obj.gameObject.SetActive(!activity);

            var timeStop = !activity ? Time.timeScale = 0.00001f : Time.timeScale = 1f;
        }

        public void CloseTutorPanel()
        {
            _menuList[1].gameObject.SetActive(false);
        }

        public void RestartGame()
        {
            Time.timeScale = 1f;
            CloseTutorPanel();
            
            SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex);
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

                switch (_currentLifeCountView) //todo - it works, but make it look nice
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