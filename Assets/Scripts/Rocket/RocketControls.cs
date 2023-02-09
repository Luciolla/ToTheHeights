using System.Collections;
using UnityEngine;

namespace ToTheHeights
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class RocketControls : MonoBehaviour
    {
        private PlayerInput _input;
        private Rigidbody2D _rb;

        private Vector3 _lastTouchPos;

        private float _direction;
        private float _radius = 4f;
        private float _sens = 3f;

        [SerializeField] private Transform _transform;
        [SerializeField] private Vector3 _centerPoint;

        private void Awake()
        {
            _input = new();
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            StartCoroutine(SnakeMotionCoroutine());
        }

        private void FixedUpdate()
        {
            CheckTouchToMove();
        }

        private void OnEnable()
        {
            _input.EditorInput.Enable();
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

        private void CheckTouchToMove()
        {
            if (Input.GetMouseButton(0))
            {
                Vector2 delta = Input.mousePosition - _lastTouchPos;
                Debug.Log(delta);
                _rb.velocity += new Vector2(delta.x * _sens * Time.deltaTime, 0f);
            }
            _lastTouchPos = Input.mousePosition;
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void OnDestroy()
        {
            _input.Dispose();
        }
    }
}