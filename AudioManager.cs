// Xử lý va chạm với Coin, Enemy, Trap, Key, Deadzone.
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backGround;
    [SerializeField] private AudioSource effect;

    [SerializeField] private AudioClip backGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlaybackGroundMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaybackGroundMusic()
    {
        backGround.clip = backGroundClip;
        backGround.Play();
    }
    public void PlayCoinSound()
    {
        effect.PlayOneShot(coinClip);
    }
    public void PlayJumpSound()
    {
        effect.PlayOneShot(jumpClip);
    }
}
