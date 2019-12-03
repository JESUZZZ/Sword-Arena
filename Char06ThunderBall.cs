using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char06ThunderBall : MonoBehaviour
{
    public int player;
    public float delayLightning;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(startLighning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator startLighning()
    {
        yield return new WaitForSeconds(delayLightning);
        anim.SetBool("isLightning", true);
    }
}
