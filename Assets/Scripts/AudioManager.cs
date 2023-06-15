using Players;
using Scores;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip DeathClip;
    [SerializeField] private AudioClip ScoreClip;
    [SerializeField] private AudioClip JumpClip;

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

    private void OnJump() => _audioSource.PlayOneShot(JumpClip, 0.7f);
    private void OnDeath() => _audioSource.PlayOneShot(DeathClip, 0.7f);
    private void OnScore() => _audioSource.PlayOneShot(ScoreClip, 0.7f);
}
