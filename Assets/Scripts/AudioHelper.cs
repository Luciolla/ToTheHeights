using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ToTheHeights
{
    public class AudioHelper : MonoBehaviour
    {
        private float _sfxVolume = 1f;
        private bool _isPlayingMusic = true;
        private bool _isPlayingSFX = true;
        private bool _isMusicPlayingNow = true;

        private AudioClip _currentLevelMusic;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _audioSFXList;
        [SerializeField] private List<AudioClip> _musicList;

        private void Start()
        {
            _currentLevelMusic = _musicList[SceneManager.GetActiveScene().buildIndex];
            PlayMusic();
        }

        private void Update()
        {
            _audioSource.volume = _sfxVolume;
            CheckMusicToggle();
        }

        public void IsPlayingMusic() => _isPlayingMusic = !_isPlayingMusic;
        public void IsPlayingSFX() => _isPlayingSFX = !_isPlayingSFX;
        public void SetVolume(float volume) => _sfxVolume = volume;

        public void PlaySound(AudioClip clip)
        {
            if (_isPlayingSFX) _audioSource.PlayOneShot(clip);
        }

        public void PlayMusic()
        {
            if (_isPlayingMusic) _audioSource.PlayOneShot(_currentLevelMusic);
        }

        private void CheckMusicToggle() //todo fix
        {
            if (_isPlayingMusic == false) _audioSource.Stop();
        }
    }
}