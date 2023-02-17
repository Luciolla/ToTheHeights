using System.Collections;
using UnityEngine;

namespace ToTheHeights
{
    public class EffectsPlayer : MonoBehaviour
    {
        private float _effectPrefabLifeTime = 2f;
        private IEnumerator rutine;

        [SerializeField] private GameObject SmallBlastPrefab;
        [SerializeField] private GameObject BigBlastPrefab;

        public static EffectsPlayer Instance { get; private set; }

        private void Start() => Instance = this;

        public void PlaySmallBlast()
        {
            rutine = CreateBlast(SmallBlastPrefab);
            StartCoroutine(rutine);
        }

        public void PlayBigBlast()
        {
            rutine = CreateBlast(BigBlastPrefab);
            StartCoroutine(rutine);
        }

        private IEnumerator CreateBlast(GameObject blastPrefab)
        {
            while (true)
            {
                blastPrefab.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(_effectPrefabLifeTime);
                blastPrefab.gameObject.SetActive(false);
                StopRutine();
                yield break;
            }
        }

        private void StopRutine()
        {
            StopCoroutine(rutine);
        }
    }
}