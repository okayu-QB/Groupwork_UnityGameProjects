using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    public AudioClip Engine;
    public AudioClip Hit;
    public AudioClip Boost;
    public Vihecle VihecleObj;
    public VihecleHit VihecleHitObj;
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

    private void SetAndPlaySE(AudioClip clip,bool loop)
    {
        if(audioSource == null)
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
        if (VihecleHitObj.FrontHit == true)
        {
            HitSECheck = true;
            SetAndPlaySE(Hit, false);
        }
        else if (VihecleObj.BoostMode == true)
        {
            if (audioSource.isPlaying && HitSECheck)
            {
                return;
            }
            else
            {
                SetAndPlaySE(Boost, true);
                HitSECheck = false;
            }
        }
        else if (VihecleObj.speed > 0.3f)
        {
            if (audioSource.isPlaying && HitSECheck)
            {
                return;
            }
            else
            {
                SetAndPlaySE(Engine, true);
                HitSECheck = false;
            }
        }
    }
}
