using UnityEngine;
using System.Collections;

namespace ToTheHeights
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    public class LifeLoss : MonoBehaviour
    {
        [SerializeField] private GameObject _data;
        [SerializeField] private GameObject _rocketBody;
        [SerializeField] private float _invulnerabilityTime = 3f;

        private bool isInvulnerability = false;
        private bool isBodyActive = true;

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
            {
                EffectsPlayer.Instance.PlaySmallBlast();
                AudioHelper.Instance.PlaySound(AudioHelper.Instance.GetSFTList[3]);
                StartCoroutine(InvulnerabilityRutine());
            }
            else
            {
                EffectsPlayer.Instance.PlayBigBlast();
                AudioHelper.Instance.PlaySound(AudioHelper.Instance.GetSFTList[3]);
                StartCoroutine(InvulnerabilityRutine());
                UIHelper.Instance.OpenDeathPanel();
            }
        }
    }
}