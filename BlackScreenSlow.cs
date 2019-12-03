using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackScreenSlow : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 1)
        {
            sr.enabled = true;
        }
        else
        {
            sr.enabled = false;
        }
    }
}
