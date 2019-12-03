using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkHB2_range : MonoBehaviour
{
    private int oneTime;
    public static bool isHit;
    public GameObject fxHit;
    public GameObject fxHit2;
    public float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        oneTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && oneTime < 1)
        {
            oneTime++;
            minusHealth();
        }

        isHit = false;
        StartCoroutine(destroyHB());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "p1" && PlayerControl.whileDash == false && PlayerControl.whileParry == false && PlayerControl.isImmortal == false)
        {
            isHit = true;
        }

    }
    IEnumerator destroyHB()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }

    void minusHealth()
    {

        LevelControl.p1HP--;
        Instantiate(fxHit, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Instantiate(fxHit2, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        //Debug.Log("p2HP = " + LevelControl.p2HP);
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
