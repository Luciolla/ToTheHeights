using UnityEngine;

namespace ToTheHeights
{
    public class SkyBoxChanger : MonoBehaviour
    {
        [SerializeField] private Material _skybox;

        [Range(0, 1)] public float blend;

        private void Update()
        {
            _skybox.SetFloat("_Blend", blend);
        }

    }
}