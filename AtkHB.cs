using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHB : MonoBehaviour
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
        isCrash = false;
        isCounter = false;
        oneTime = 0;
        if(PlayerPrefs.GetInt("p1Choose") == 3)
        {
            float fxSpawnOffset = fxHitOffset / 2f;
            if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x + fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y + fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x - fxSpawnOffset, transform.position.y - fxSpawnOffset, transform.position.z), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && oneTime < 1)
        {
            oneTime++;
            
            if (PlayerControl2.whileAttack == true && (PlayerControl2.x_lastMove * -1 == PlayerControl.x_lastMove && PlayerControl2.y_lastMove * -1 == PlayerControl.y_lastMove))
            {
                isCrash = true;
                if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove == 0)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove == 0)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove > 0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                }
                else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove < -0.5f)
                {
                    Instantiate(fxCrash, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                    Instantiate(fxCrash2, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                }
                //Debug.Log("P1CRASH");
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
 
        if (other.tag == "p2" && PlayerControl2.whileDash == false && PlayerControl2.whileParry == false && PlayerControl2.isImmortal == false)
        {           
            isHit = true;
        }
        else if (other.tag == "p2" && PlayerControl2.whileParry == true&& oneTime<1)
        {
            oneTime++;
            //Debug.Log("P1COUNTERED");
            if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxCrash, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxCrash2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            PlayerControl.isStun = true;
            PlayerControl.speed = 0;
            isCounter = true;
        } 
    }
    IEnumerator destroyHB()
    {
        yield return new WaitForSeconds(0.10f);
        //yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    void minusHealth()
    {
        
            LevelControl.p2HP--;
            
            if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove == 0)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove == 0 && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove > 0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x + fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove > 0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y + fxHitOffset, transform.position.z), Quaternion.identity);
            }
            else if (PlayerControl.x_lastMove < -0.5f && PlayerControl.y_lastMove < -0.5f)
            {
                Instantiate(fxHit, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
                Instantiate(fxHit2, new Vector3(transform.position.x - fxHitOffset, transform.position.y - fxHitOffset, transform.position.z), Quaternion.identity);
            }
            //Debug.Log("p2HP = " + LevelControl.p2HP);
            PlayerControl2.isImmortal = true;
            if (PlayerControl2.speed != PlayerControl2.speedCopy)
            {
                PlayerControl2.speed = PlayerControl2.speedCopy;
            }
            if (PlayerControl2.isStun != false)
            {
                PlayerControl2.isStun = false;
            }
        
    }
    
}
