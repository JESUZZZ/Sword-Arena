using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public AudioSource fire;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        fire.enabled = false;
        StartCoroutine(delayFire());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator delayFire()
    {
        yield return new WaitForSeconds(delay);
        fire.enabled = true;
    }
}
