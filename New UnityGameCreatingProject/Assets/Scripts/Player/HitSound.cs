using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public AudioClip Hit;
    public Vihecle VihecleObj;
    public VihecleHit VihecleFrontHitObj;
    AudioSource audioSource;

    bool HitSECheck = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetAndPlaySE(AudioClip clip, bool loop)
    {
        if (audioSource == null)
        {
            Debug.Log("AudioSouce Component is null");
            return;
        }

        if (audioSource.clip == clip)
        {
            return;
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();

        Debug.Log("Play " + clip.ToString());
    }

    private void FixedUpdate()
    {
        if(VihecleFrontHitObj.Hit == true)
        {
            Debug.Log("FrontHit");
        }
        if (VihecleFrontHitObj.Hit == true)
        {
            HitSECheck = true;
            SetAndPlaySE(Hit, false);
            VihecleFrontHitObj.Hit = false;
        }
        else if(audioSource.isPlaying && HitSECheck)
        {
            return;
        }
        else
        {
            audioSource.clip = null;
        }
    }
}
