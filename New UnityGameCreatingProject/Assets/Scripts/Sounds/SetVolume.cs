using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    [SerializeField]
    private Slider masterSlider;
    [SerializeField]
    private Slider bgmSlider;
    [SerializeField]
    private Slider seSlider;

    void Start() {
        if(mixer.GetFloat("MasterVol",out float masterValue)) {
            masterSlider.value = Mathf.Pow(10, masterValue / 20);
        }
        if(mixer.GetFloat("BGMVol",out float bgmVolume)) {
            //Debug.Log("BGMSliser = " + bgmVolume);
            bgmSlider.value = Mathf.Pow(10, bgmVolume / 20);
        }
        if (mixer.GetFloat("SEVol", out float seVolume)) {
            seSlider.value = Mathf.Pow(10, seVolume / 20);
        }
    }

    public void SetMasterLevel(float sliderValue) {
        mixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
    }
    public void SetBGMLevel(float sliderValue) {
        mixer.SetFloat("BGMVol", Mathf.Log10(sliderValue) * 20);
    }

    public void SetSELevel(float sliderValue) {
        mixer.SetFloat("SEVol", Mathf.Log10(sliderValue) * 20);
    }
}
