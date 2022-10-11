using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    private AudioSource clip;
    public AudioClip [] Audios;
    private Movement_Manager player;
    private int Aux;

    private void Awake()
    {
        clip = GetComponent<AudioSource>();
        player = GetComponent<Movement_Manager>();
    }

    public void SeleccionAudio (int indice, float volumen)
    {
        clip.PlayOneShot(Audios[indice], volumen);
    }
}
