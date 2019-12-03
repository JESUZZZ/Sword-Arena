using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharIcon : MonoBehaviour
{
    public int player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            if (LevelControl.p1HP <5)
            {
                anim.SetBool("isHurt", true);
            }
        }
        else if (player == 2)
        {
            if(LevelControl.p2HP <5)
            {
                anim.SetBool("isHurt", true);
            }
        }
    }
}
