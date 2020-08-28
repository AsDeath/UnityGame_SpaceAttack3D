using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public AudioSource MenuMusic;
    public AudioSource FightMusic;
    private void OnEnable()
    {
        Time.timeScale = 0;
        FightMusic.Stop();
        MenuMusic.Play();
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
        MenuMusic.Stop();
        FightMusic.Play();
    }

    public void Mute(bool enable)
    {
        if(enable) Mixer.audioMixer.SetFloat("MasterVolume", -80);
        else Mixer.audioMixer.SetFloat("MasterVolume", 0);
    }
    public void SliderMusic(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeValue(float value)
    {
        Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, value));
    }

    public void Menu()
    {
        PlayerPrefs.SetInt("Save", Save.MaxScore);
        SceneManager.LoadScene(0);
    }
}
