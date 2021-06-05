using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundOption : MonoBehaviour {

    //�@SoundOption�L�����o�X��ݒ�
    [SerializeField]
    private GameObject soundOptionCanvas;

    [SerializeField]
    private GameObject homeButtonCanvas;

    //�@Option�{�^���������ꂽ��UI���I���E�I�t
    public void OnClick() {

        var audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log("SE!!!");

        soundOptionCanvas.SetActive(!soundOptionCanvas.activeSelf);
        homeButtonCanvas.SetActive(!homeButtonCanvas.activeSelf);
    }
}