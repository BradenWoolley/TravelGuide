using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audios;

    private AudioSource audioSource;

    private void Start() => audioSource = GetComponent<AudioSource>();

    public void PlayAudio(int audio)
    {
        audioSource.clip = audios[audio];
        audioSource.Play();
    }
}
