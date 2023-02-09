using ToTheHeights;
using UnityEngine;

public class WithdrawTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var obj = other.TryGetComponent(out ObjectSpawnStatus status);
        if (status.IsReturnToPool)
        {
            //todo return to pool
        }

        other.gameObject.SetActive(false);
    }
}