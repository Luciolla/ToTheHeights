using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToTheHeights
{
    public class SkyBoxChanger : MonoBehaviour
    {
        [SerializeField] private Material _skybox;
        [SerializeField] private List<Material> _skyboxList;
        [SerializeField, Range(0, 1)] private float _blend;

        private int blendModif = 0;
        private float _waitTime = 1f;
        private float[] _blendSpeed = { .006f, .004f, .0032f };

        public float SetBlend
        {
            get => _blend;
            set => _blend = value;
        }

        private void Start()
        {
            _skybox = _skyboxList[0];
            StartCoroutine(BlendSkybox());
        }

        private void Update()
        {
            _skybox.SetFloat("_Blend", _blend);
        }

        private IEnumerator BlendSkybox()
        {
            while (true)
            {
                _blend += _blendSpeed[blendModif];
                yield return new WaitForSecondsRealtime(_waitTime);
                if (_blend >= 1f)
                {
                    blendModif++;
                    _skybox = _skyboxList[blendModif];
                    RenderSettings.skybox = _skybox;
                    _blend = 0f;
                    AudioHelper.StageIndex++;
                }
            }
        }
    }
}