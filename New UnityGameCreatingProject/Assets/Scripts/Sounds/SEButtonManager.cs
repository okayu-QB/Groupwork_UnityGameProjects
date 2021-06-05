using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEButtonManager : MonoBehaviour
{
    [SerializeField]
    private GameObject homeButtonCanvas;

    [SerializeField]
    private GameObject soundOptionCanvas;

    public void OnClick() {
        var audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log("SE!!!");

        homeButtonCanvas.SetActive(!homeButtonCanvas.activeSelf);
        soundOptionCanvas.SetActive(!soundOptionCanvas.activeSelf);
    }
}
