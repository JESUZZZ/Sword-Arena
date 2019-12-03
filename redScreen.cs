using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redScreen : MonoBehaviour
{
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelControl.isCountdown)
        {
            StartCoroutine(delayRed());
        }
    }

    IEnumerator delayRed()
    {
        yield return new WaitForSeconds(1f);
        sr.color = new Color(1f, 1f, 1f, 0.15f);
    }
}
