using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour {

    //　SoundOptionキャンバスを設定
    [SerializeField]
    private GameObject soundOptionCanvas;

    [SerializeField]
    private GameObject homeButtonCanvas;

    //　Optionボタンが押されたらUIをオン・オフ
    public void OnClick() {

        var audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log("SE!!!");

        soundOptionCanvas.SetActive(!soundOptionCanvas.activeSelf);
        homeButtonCanvas.SetActive(!homeButtonCanvas.activeSelf);
    }
}