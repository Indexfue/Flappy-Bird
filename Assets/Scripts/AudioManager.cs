using Players;
using Scores;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip _deathClip;
    [SerializeField] private AudioClip _scoreClip;
    [SerializeField] private AudioClip _jumpClip;

    private AudioSource _audioSource;

    private void Start() => _audioSource = GetComponent<AudioSource>();
    
    private void OnEnable()
    {
        PlayerMover.Jumped += OnJump;
        Player.Died += OnDeath;
        ScoreTrigger.Triggered += OnScore;
    }
    
    private void OnDisable()
    {
        PlayerMover.Jumped -= OnJump;
        Player.Died -= OnDeath;
        ScoreTrigger.Triggered -= OnScore;
    }

    private void OnJump() => _audioSource.PlayOneShot(_jumpClip, 0.7f);
    private void OnDeath() => _audioSource.PlayOneShot(_deathClip, 0.7f);
    private void OnScore() => _audioSource.PlayOneShot(_scoreClip, 0.7f);
}
