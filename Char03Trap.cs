using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char03Trap : MonoBehaviour
{
    public int player;
    public Animator anim;
    public Collider2D col;
    public GameObject fxCrash1;
    public GameObject fxCrash2;
    public float fxOffset;
    public float decreaseSpeed;
    public static bool stun;
    public static int playerNum;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerNum = player;
        stun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player == 1)
        {
            if (collision.gameObject.tag == "p2" && !PlayerControl2.whileDash)
            {
                col.enabled = false;
                PlayerControl.trapCount++;
                anim.SetBool("isDisappear", true);
                Destroy(gameObject, 0.25f);
                Instantiate(fxCrash1, new Vector3(transform.position.x,transform.position.y - fxOffset,transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxOffset, transform.position.z), Quaternion.identity);
                stun = true;
                PlayerControl2.speed = 0;
                PlayerControl2.isStun = true;
            }
            else if (collision.gameObject.tag == "p2" && PlayerControl2.whileDash)
            {
                col.enabled = false;
                StartCoroutine(returnCol());
            }
        }
        else if (player == 2)
        {
            if (collision.gameObject.tag == "p1" && !PlayerControl.whileDash)
            {
                col.enabled = false;
                PlayerControl2.trapCount++;
                anim.SetBool("isDisappear", true);
                Destroy(gameObject, 0.25f);
                Instantiate(fxCrash1, new Vector3(transform.position.x, transform.position.y - fxOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxOffset, transform.position.z), Quaternion.identity);
                stun = true;
                PlayerControl.speed = 0;
                PlayerControl.isStun = true;
            }
            else if (collision.gameObject.tag == "p1" && PlayerControl.whileDash)
            {
                col.enabled = false;
                StartCoroutine(returnCol());
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "p1" || collision.gameObject.tag == "p2")
       {
            col.enabled = true;
       }
    }
    IEnumerator returnCol()
    {
        yield return new WaitForSeconds(0.1f);
        col.enabled = true;
    }
}
