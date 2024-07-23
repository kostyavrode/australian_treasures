using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool isSoundEnabled;
    public AudioSource audioSourcePrefab;
    public Scrollbar scrollbar;
    private AudioSource audioSource;
    private void OnEnable()
    {
        isSoundEnabled = true;

        if (audioSource == null)
        {
            try
            {
                audioSource = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioSource>();

            }
            catch
            {
                audioSource = Instantiate(audioSourcePrefab);
                CheckSound();
            }

        }
        DontDestroyOnLoad(audioSource);

    }
    private void CheckSound()
    {
        float t = PlayerPrefs.GetFloat("Volume");
        audioSource.volume = t;
    }
    public void AudioButton()
    {
        isSoundEnabled = !isSoundEnabled;
        CheckSound();
    }
    public void ChangeVolume()
    {

        audioSource.volume = scrollbar.value;
        Debug.Log(scrollbar.value);
        PlayerPrefs.SetFloat("Volume", audioSource.volume);
        PlayerPrefs.Save();
    }
}
