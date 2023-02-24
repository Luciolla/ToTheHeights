using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

namespace ToTheHeights
{
    public class DangerObjectSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _dangers;
        [SerializeField, Range(1, 10)] private float _spawnTime = 3f;

        private Random _rand = new();

        private void Start()
        {
            StartCoroutine(SpawnStart());
        }

        private IEnumerator SpawnStart()
        {
            foreach (var obj in _dangers)
            {
                obj.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(_spawnTime);
            }
            StopCoroutine(SpawnStart());
        }
    }
}