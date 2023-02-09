using UnityEngine;

namespace ToTheHeights
{
    public class ObjectSpawnStatus : MonoBehaviour
    {
        [field: SerializeField] public bool IsReturnToPool { get; private set; }
    }
}