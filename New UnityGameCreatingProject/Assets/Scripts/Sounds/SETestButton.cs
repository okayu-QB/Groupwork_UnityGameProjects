using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SETestButton : MonoBehaviour
{
    public void OnClick() {
        var audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        //Debug.Log("SE!!!");

    }
}
