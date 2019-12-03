using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char06StunBall : MonoBehaviour
{
    public int player;
    public float delay;
    public GameObject fxCrash1;
    public GameObject fxCrash2;
    public static int playerNum;
    public static bool isStun;
    // Start is called before the first frame update
    void Start()
    {
        isStun = false;
        playerNum = player;
        Instantiate(fxCrash1, transform.localPosition, Quaternion.identity);
        Instantiate(fxCrash2, transform.localPosition, Quaternion.identity);
        StartCoroutine(destroy());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(player == 1 && other.tag == "p2" && !PlayerControl2.whileParry)
        {
            PlayerControl2.isStun = true;
            isStun = true;
            PlayerControl2.speed = 0;
        }
        else if (player == 2 && other.tag == "p1" && !PlayerControl.whileParry)
        {
            PlayerControl.isStun = true;
            isStun = true;
            PlayerControl.speed = 0;
        }
    }

    IEnumerator destroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
    
}
