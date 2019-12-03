using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public int playerNumber;
    private int hp;
    public int hpLeft;
    public float appearTime;
    public Animator anim;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        StartCoroutine(appearance());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNumber == 1)
        {
            hp = LevelControl.p1HP;
        }
        else if (playerNumber == 2)
        {
            hp = LevelControl.p2HP;
        }

        if (hp <= 4)
        {
            anim.SetBool("isPump", true);
        }

        if (hpLeft == hp)
        {
            if (hp > 4)
            {
                anim.SetBool("isDisappear", true);
            }
            else if (hp <= 4)
            {
                anim.SetBool("isPumpDisappear", true);
            }
            StartCoroutine(destroy());
        }
    }

    IEnumerator appearance()
    {
        yield return new WaitForSeconds(appearTime);
        sr.enabled = true;
        anim.SetBool("isAppear", true);
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
