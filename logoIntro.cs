using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoIntro : MonoBehaviour
{
    public float delay;
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
        yield return new WaitForSeconds(delay);
        anim.SetBool("isIdle", true);
    }
}
