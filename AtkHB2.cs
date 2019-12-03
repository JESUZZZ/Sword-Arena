using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHB2 : MonoBehaviour
{    
    private int oneTime;
    public static bool isCounter;
    public static bool isHit;
    private bool isCrash;
    public GameObject fxHit;
    public GameObject fxHit2;
    public GameObject fxCrash;
    public GameObject fxCrash2;
    public float fxHitOffset;

    // Start is called before the first frame update
    void Start()
    {
        isCounter = false;
        isCrash = false;
        oneTime = 0;
        if (PlayerPrefs.GetInt("p2Choose") == 3)
        {
            float fxSpawnOffset = fxHitOffset / 2f;
            if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isHit && oneTime<1)
        {
            oneTime++;
            if (PlayerControl.whileAttack == true && (PlayerControl.x_lastMove * -1 == PlayerControl2.x_lastMove && PlayerControl.y_lastMove * -1 == PlayerControl2.y_lastMove))
            {
                isCrash = true;
                if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove == 0)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove == 0)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                //Debug.Log("P2CRASH");
            }

            if (!isCrash)
            {
                minusHealth();
            }
        }
        
        isHit = false;
        StartCoroutine(destroyHB());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "p1" && oneTime < 1 && PlayerControl.whileDash == false && PlayerControl.whileParry == false && PlayerControl.isImmortal == false)
        {
            isHit = true;                       
        }
        else if (other.tag == "p1" && PlayerControl.whileParry == true && oneTime<1)
        {
            oneTime++;
            //Debug.Log("P2COUNTERED");
            if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            PlayerControl2.isStun = true;
            PlayerControl2.speed = 0;
            isCounter = true;
        }
    }

    IEnumerator destroyHB()
    {
        yield return new WaitForSeconds(0.1f);
        //yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void minusHealth()
    {
         LevelControl.p1HP--;
            if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove == 0)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove == 0 && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            //Debug.Log("p1HP = " + LevelControl.p1HP);
            PlayerControl.isImmortal = true;
            if (PlayerControl.speed != PlayerControl.speedCopy)
            {
                PlayerControl.speed = PlayerControl.speedCopy;
            }
            if (PlayerControl.isStun != false)
            {
                PlayerControl.isStun = false;
            }
        
    }

}
