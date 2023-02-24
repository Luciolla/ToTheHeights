using UnityEngine;

namespace ToTheHeights
{
    public class WithdrawTrigger : MonoBehaviour
    {
        [SerializeField] private Vector3 _dangerStartPosition;

        private Vector3 _startPos;

        private void Start()
        {
            _startPos = transform.position.normalized;
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            var obj = other.TryGetComponent(out ObjectSpawnStatus status);
            if (status.IsReturnToPool)
            {
                other.transform.position = _dangerStartPosition;
                other.gameObject.SetActive(false);
                other.gameObject.SetActive(true);
            }

            else 
                other.gameObject.SetActive(false);
        }
    }
}