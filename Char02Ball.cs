using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char02Ball : MonoBehaviour
{
    public float speed;
    private float speedCopy;
    public Animator anim;
    public Rigidbody2D rb;
    public Collider2D col;
    public int x_direction;
    public int y_direction;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col.enabled = false;
        speedCopy = speed;
        if (gameObject.tag != "knife")
        {
            StartCoroutine(toIdle());
        }
        StartCoroutine(toDisappear());
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isIdle"))
        {
            if(x_direction != 0 && y_direction != 0)
            {
                speed = speedCopy / 1.5f;
            }
            col.enabled = true;
        }
    }

    private void FixedUpdate()
    {
        if (anim.GetBool("isIdle"))
        {
            rb.velocity = new Vector3(x_direction * speed * Time.deltaTime, y_direction * speed * Time.deltaTime, 0);
        }
    }

    IEnumerator toIdle()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isIdle", true);
    }
    IEnumerator toDisappear()
    {
        yield return new WaitForSeconds(4.6f);
        anim.SetBool("isDisappear", true);
        col.enabled = false;
        speed = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (anim.GetBool("isIdle") && gameObject.tag != "knife" && gameObject.tag != collision.tag)
        {
            if ((player == 1 && collision.tag != "p1") || (player == 2 && collision.tag != "p2"))
            {
                speed = 0;
                anim.SetBool("isDisappear", true);
                col.enabled = false;
                Destroy(gameObject, 0.3f);
            }
        }
        else if (anim.GetBool("isIdle") && gameObject.tag == "knife" && gameObject.tag != collision.tag)
        {
            if ((player == 1 && collision.tag != "p1") || (player == 2 && collision.tag != "p2"))
            {
                speed = 0;
                anim.SetBool("isDisappear", true);
                transform.localScale = new Vector3(0.5f, 0.5f, 1f);
                col.enabled = false;
                Destroy(gameObject, 0.3f);
            }
        }
    }
}
