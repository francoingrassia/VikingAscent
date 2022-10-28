using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] Slider sliderSFX, sliderMusic, sliderMaster;
    [SerializeField] AudioMixer audioMixer;

    const string mixerSFX = "VolumenSFX";
    const string mixerMusic = "VolumenMusic";
    const string mixerMaster = "VolumenMaster";

    private void Awake()
    {
        sliderSFX.onValueChanged.AddListener(setVolumenSFX);
        sliderMusic.onValueChanged.AddListener(setVolumenMusic);
        sliderMaster.onValueChanged.AddListener(setVolumenMaster);
    }

    private void setVolumenSFX(float valor)
    {
        audioMixer.SetFloat(mixerSFX, Mathf.Log10(valor)*20);
    }

    private void setVolumenMusic(float valor)
    {
        audioMixer.SetFloat(mixerMusic, Mathf.Log10(valor) * 20);
    }

    private void setVolumenMaster(float valor)
    {
        audioMixer.SetFloat(mixerMaster, Mathf.Log10(valor) * 20);
    }

    public void Quit()
    {
        Menu.SetActive(false);
    }
}
