using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts
{
    public class Launcher : MonoBehaviour
    {
        [SerializeField] private GameObject _projectilePrefab = null;
        [SerializeField] private AudioClip _windUpSound = null;
        [SerializeField] private AudioClip _launchSound = null;
        [Range(0, 100.0f), SerializeField] private float _forceMultiplier = 0.0f;

        private AudioSource _audioSource = null;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                   _forceMultiplier = 0.0f;
                   _audioSource.clip = _windUpSound;
                   _audioSource.Play();
            }

            if (Input.GetMouseButton(0))
            {
                _forceMultiplier += Time.deltaTime / _windUpSound.length * 100.0f;
                if (_forceMultiplier > 100.0f) _forceMultiplier = 100.0f;
            }

            if (Input.GetMouseButtonUp(0))
            {
               GameObject projectile = Instantiate(_projectilePrefab);
               Impulse impulse = projectile.GetComponent<Impulse>();
               impulse.SetForce(impulse.Force * _forceMultiplier / 100.0f);
               _audioSource.clip = _launchSound;
               _audioSource.Play();
            }
        }
    }
}
