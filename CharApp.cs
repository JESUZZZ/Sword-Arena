using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharApp : MonoBehaviour
{
    public int character;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(toIdle());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator toIdle()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        anim.SetBool("isIdle", true);
    }
}
