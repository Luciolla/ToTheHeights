using System.Collections;
using UnityEngine;

namespace ToTheHeights
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RocketControls : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _centerPoint;

        private PlayerInput _input;
        private Rigidbody2D _rb;

        private Vector3 _lastTouchPos;

        private float _direction;
        private float _radius = 4f;
        private float _sens = 3f;

        private void Awake()
        {
#if UNITY_EDITOR
            _input = new();
#endif
            _rb = GetComponent<Rigidbody2D>();
        }

#if UNITY_EDITOR
        private void Start()
        {
            StartCoroutine(SnakeMotionCoroutine());
        }
#endif
        private void FixedUpdate()
        {
            CheckTouchToMove();
        }


#if UNITY_EDITOR
        #region EditorControls
        private void OnEnable()
        {
            _input.EditorInput.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void OnDestroy()
        {
            _input.Dispose();
        }

        private IEnumerator SnakeMotionCoroutine()
        {
            while (true)
            {
                _direction = _input.EditorInput.Motion.ReadValue<float>() * (Time.deltaTime * 5f);
                if (_direction != 0f)
                {
                    var newPos = transform.position += -_direction * transform.right;
                    var offset = newPos - _centerPoint;

                    transform.position = _centerPoint + Vector3.ClampMagnitude(offset, _radius);
                }

                yield return new WaitForFixedUpdate();
            }
        }
        #endregion
#endif

        private void CheckTouchToMove()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 delta = Input.mousePosition - _lastTouchPos;
                _rb.velocity += new Vector2(delta.x * _sens * Time.deltaTime, 0f);
            }
            _lastTouchPos = Input.mousePosition;
        }
    }
}