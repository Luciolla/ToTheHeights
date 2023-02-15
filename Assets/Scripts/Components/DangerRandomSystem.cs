using UnityEngine;
using Random = System.Random;

namespace ToTheHeights
{
    public class DangerRandomSystem : MonoBehaviour
    {
        private Random _random = new();

        private float _gravityScaleModif = .1f;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var tempNum = _random.Next(-4, 5);
            var qRotation = _random.Next(-5, 6);
            
            other.transform.position = new Vector3(tempNum, transform.position.y);
            other.TryGetComponent(out Rigidbody2D otherRigid);
            
            otherRigid.AddTorque(((qRotation * Mathf.Deg2Rad) * otherRigid.inertia), ForceMode2D.Impulse);
            otherRigid.gravityScale += _gravityScaleModif;
        }
    }
}