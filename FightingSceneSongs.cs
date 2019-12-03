using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingSceneSongs : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    public AudioSource track4;
    public AudioSource track5;
    public AudioSource track6;
    public AudioSource track7;
    public AudioSource countdownTrack;
    public AudioSource victory;
    public AudioSource bassBend1;
    public AudioSource bassBend2;
    private int trackNum;
    private float normalVol;
    // Start is called before the first frame update
    void Start()
    {
        track1.enabled = false;
        track2.enabled = false;
        track3.enabled = false;
        track4.enabled = false;
        track5.enabled = false;
        track6.enabled = false;
        track7.enabled = false;
        countdownTrack.enabled = false;
        victory.enabled = false;
        bassBend1.enabled = false;
        bassBend2.enabled = false;
        normalVol = 1f;
        trackNum = Random.Range(1, 8);
        StartCoroutine(playSong());
    }

    // Update is called once per frame
    void Update()
    {
        if((PlayerControl.isStun || PlayerControl2.isStun || Time.time != 1) && LevelControl.p1HP > 0 && LevelControl.p2HP > 0)
        {
            countdownTrack.volume = normalVol / 3.0f;
            if (trackNum == 1)
            {
                track1.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 2)
            {
                track2.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 3)
            {
                track3.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 4)
            {
                track4.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 5)
            {
                track5.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 6)
            {
                track6.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
            else if (trackNum == 7)
            {
                track7.volume = normalVol / 3.0f;
                bassBend1.enabled = true;
                bassBend2.enabled = true;
            }
        }
        else
        {
            countdownTrack.volume = normalVol;
            if (trackNum == 1)
            {
                track1.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 2)
            {
                track2.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 3)
            {
                track3.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 4)
            {
                track4.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 5)
            {
                track5.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 6)
            {
                track6.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
            else if (trackNum == 7)
            {
                track7.volume = normalVol;
                bassBend1.enabled = false;
                bassBend2.enabled = false;
            }
        }

        if (LevelControl.isCountdown)
        {
            if (trackNum == 1)
            {
                track1.enabled = false;
            }
            else if (trackNum == 2)
            {
                track2.enabled = false;
            }
            else if (trackNum == 3)
            {
                track3.enabled = false;
            }
            else if (trackNum == 4)
            {
                track4.enabled = false;
            }
            else if (trackNum == 5)
            {
                track5.enabled = false;
            }
            else if (trackNum == 6)
            {
                track6.enabled = false;
            }
            else if (trackNum == 7)
            {
                track7.enabled = false;
            }
            //StartCoroutine(countdownSong());
            countdownSong();
        }

        if(LevelControl.p1HP <=0 || LevelControl.p2HP <= 0)
        {
            countdownTrack.enabled = false;
            if (trackNum == 1)
            {
                track1.enabled = false;
            }
            else if (trackNum == 2)
            {
                track2.enabled = false;
            }
            else if (trackNum == 3)
            {
                track3.enabled = false;
            }
            else if (trackNum == 4)
            {
                track4.enabled = false;
            }
            else if (trackNum == 5)
            {
                track5.enabled = false;
            }
            else if (trackNum == 6)
            {
                track6.enabled = false;
            }
            else if (trackNum == 7)
            {
                track7.enabled = false;
            }
            StartCoroutine(victorySound());
        }
    }

    IEnumerator playSong()
    {
        yield return new WaitForSeconds(10f);
        if (trackNum == 1)
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
        else if (trackNum == 4)
        {
            track4.enabled = true;
        }
        else if (trackNum == 5)
        {
            track5.enabled = true;
        }
        else if (trackNum == 6)
        {
            track6.enabled = true;
        }
        else if (trackNum == 7)
        {
            track7.enabled = true;
        }

    }

    IEnumerator victorySound()
    {
        yield return new WaitForSeconds(2.0f);
        victory.enabled = true;
    }

    void countdownSong()
    {
        //yield return new WaitForSeconds(1f);
        if (trackNum == 1)
        {
            track1.enabled = false;
        }
        else if (trackNum == 2)
        {
            track2.enabled = false;
        }
        else if (trackNum == 3)
        {
            track3.enabled = false;
        }
        else if (trackNum == 4)
        {
            track4.enabled = false;
        }
        else if (trackNum == 5)
        {
            track5.enabled = false;
        }
        else if (trackNum == 6)
        {
            track6.enabled = false;
        }
        else if (trackNum == 7)
        {
            track7.enabled = false;
        }
        countdownTrack.enabled = true;
    }
}