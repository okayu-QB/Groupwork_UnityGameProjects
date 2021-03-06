using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSound : MonoBehaviour
{
    public AudioClip Boost;
    public Vihecle VihecleObj;
    public VihecleHit VihecleHitObj;
    AudioSource audioSource;

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

        //Debug.Log("Play " + clip.ToString());
    }

    private void FixedUpdate()
    {
        if (VihecleObj.BoostMode == true)
        {
            if (audioSource.isPlaying)
            {
                return;
            }
            else
            {
                SetAndPlaySE(Boost, true);
            }
        }
        else
        {
            audioSource.clip = null;
            audioSource.loop = false;
        }
    }
}
