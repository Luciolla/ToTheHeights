using UnityEngine;
using System.Collections;
using DG.Tweening;
using TMPro;

namespace ToTheHeights
{
    public class NextLevelCounter : MonoBehaviour
    {
        [SerializeField] private float _startCount = 5f;

        private void Start() => StartCoroutine(StartCounterRutine(_startCount));

        private IEnumerator StartCounterRutine(float time)
        {
            TryGetComponent(out TMP_Text counter);

            //just4fun - DoTween :D
            while (time >= 0)
            {
                counter.text = time.ToString();
                DOTween.Sequence()
                    .Append(transform.DOScale(20, .6f))
                    .Append(transform.DOScale(15, .6f));
                yield return new WaitForSeconds(1f);
                time--;
            }
        }

        private void SetCounterText()
        {
            TryGetComponent(out TMP_Text text);
            text.text = _startCount.ToString();
        }
    }
}