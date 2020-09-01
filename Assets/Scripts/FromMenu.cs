using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class FromMenu : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    //public static Save sv = new Save();
    //public static string path;
    public void Mute(bool enable)
    {
        if (enable) Mixer.audioMixer.SetFloat("MasterVolume", -80);
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

    private void Start()
    {
        if (PlayerPrefs.HasKey("Save"))
        {
            Save.MaxScore = PlayerPrefs.GetInt("Save");
        }
    }
}

