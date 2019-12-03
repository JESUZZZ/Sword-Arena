using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource p1_smash;
    public AudioSource p2_smash;
    public AudioSource tick;
    public AudioSource shining;
    // Start is called before the first frame update
    void Start()
    {
        p1_smash.enabled = false;
        p2_smash.enabled = false;
        tick.enabled = false;
        shining.enabled = false;
        StartCoroutine(tickSoundPlay(7f));
        StartCoroutine(tickSoundPlay(8f));
        StartCoroutine(tickSoundPlay(9f));
        StartCoroutine(shiningSoundPlay());
    }

    // Update is called once per frame
    void Update()
    {
        if(AtkHB.isHit || AtkHB_range.isHit)
        {
            p1_smash.enabled = true;
            StartCoroutine(p1_smashSound());
        }
        else if (AtkHB2.isHit || AtkHB2_range.isHit)
        {
            p2_smash.enabled = true;
            StartCoroutine(p2_smashSound());
        }
        
    }
    IEnumerator p1_smashSound()
    {
        yield return new WaitForSeconds(0.76f);
        p1_smash.enabled = false;
    }
    IEnumerator p2_smashSound()
    {
        yield return new WaitForSeconds(0.76f);
        p2_smash.enabled = false;
    }
    IEnumerator tickSound()
    {
        yield return new WaitForSeconds(0.31f);
        tick.enabled = false;
    }
    IEnumerator tickSoundPlay(float delay)
    {
        yield return new WaitForSeconds(delay);
        tick.enabled = true;
        StartCoroutine(tickSound());
    }
    IEnumerator shiningSoundPlay()
    {
        yield return new WaitForSeconds(10f);
        shining.enabled = true;
    }
}
