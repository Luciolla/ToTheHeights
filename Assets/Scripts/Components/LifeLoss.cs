using UnityEngine;
using System.Collections;

namespace ToTheHeights
{
    public class LifeLoss : MonoBehaviour
    {
        private bool isInvulnerability = false;
        private bool isBodyActive = true;

        [SerializeField] private GameObject _data;
        [SerializeField] private GameObject _rocketBody;
        [SerializeField] private float _invulnerabilityTime = 3f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (isInvulnerability) return;

            _data.TryGetComponent(out GameDataHelper helper);
            helper.SetCurrentLifeCount -= 1;
            CheckDeathStatus(helper);
        }

        private IEnumerator InvulnerabilityRutine()
        {
            isInvulnerability = true;
            var time = _invulnerabilityTime;

            while (time > 0)
            {
                _rocketBody.SetActive(isBodyActive);
                isBodyActive = !isBodyActive;
                yield return new WaitForSeconds(.1f);
                time -= .1f;
            }

            isBodyActive = true;
            _rocketBody.SetActive(isBodyActive);
            StopCoroutine(InvulnerabilityRutine());
            isInvulnerability = false;
        }

        private void CheckDeathStatus(GameDataHelper helper) //todo fix this trash before endbuild
        {
            if (helper.SetCurrentLifeCount > 0)
                StartCoroutine(InvulnerabilityRutine());
            else
            {
#if UNITY_EDITOR
                if (Application.isEditor)
                {
                    UnityEditor.EditorApplication.isPlaying = false;
                }
                else
                {
#endif
                    Application.Quit();
#if UNITY_EDITOR
                }
#endif
            }
        }
    }
}