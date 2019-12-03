using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char07Spike : MonoBehaviour
{
    public Animator anim;
    public Collider2D col;
    public GameObject fxCrash1;
    public GameObject fxCrash2;
    public float posOffset;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(fxCrash1, new Vector3(transform.position.x, transform.position.y - posOffset, transform.position.z), Quaternion.identity);
        Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - posOffset, transform.position.z), Quaternion.identity);
        col.enabled = true;
        anim = GetComponent<Animator>();
        StartCoroutine(toIdle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator toIdle()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isIdle", true);
        StartCoroutine(toDown());
    }
    IEnumerator toDown()
    {
        yield return new WaitForSeconds(1f);
        anim.SetBool("isDown", true);
        col.enabled = false;
        //StartCoroutine(toDestroy());
    }
    /*IEnumerator toDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }*/
}
