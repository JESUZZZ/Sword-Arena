using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSceneSong : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    private int trackNum;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 120;
        track1.enabled = false;
        track2.enabled = false;
        track3.enabled = false;
        trackNum = Random.Range(1,4);
    }

    // Update is called once per frame
    void Update()
    {
        if(trackNum == 1)
        {
            track1.enabled = true;
        }
        else if (trackNum == 2)
        {
            track2.enabled = true;
        }
        else if (trackNum == 3)
        {
            track3.enabled = true;
        }
    }
}
