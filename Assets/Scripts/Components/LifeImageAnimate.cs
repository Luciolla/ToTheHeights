using DG.Tweening;
using System.Collections;
using UnityEngine;

public class LifeImageAnimate : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StartLifeAnimationRutine());
    }
    private IEnumerator StartLifeAnimationRutine()
    {
        while (true)
        {
            DOTween.Sequence()
                .Append(transform.DOScale(.95f, .6f))
                .Append(transform.DOScale(1.05f, .6f));
            yield return new WaitForSeconds(1f);
        }
    }
}
