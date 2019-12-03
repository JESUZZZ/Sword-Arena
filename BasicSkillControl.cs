using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSkillControl : MonoBehaviour
{
    public int player;
    //public Animator anim;
    public int skillNum;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player == 1)
        {
            if (skillNum == 1)
            {
                if (!PlayerControl.canDash)
                {
                    //anim.SetBool("isCooldown", true);
                    sr.color = new Color(0.4f, 0.4f, 0.4f,1.0f);
                }
                else if (PlayerControl.canDash)
                {
                    //anim.SetBool("isCooldown", false);
                    sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
            else if (skillNum == 2)
            {
                if (!PlayerControl.canParry)
                {
                    //anim.SetBool("isCooldown", true);
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
                }
                else if (PlayerControl.canParry)
                {
                    //anim.SetBool("isCooldown", false);
                    sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
        }
        else if (player == 2)
        {
            if (skillNum == 1)
            {
                if (!PlayerControl2.canDash)
                {
                    //anim.SetBool("isCooldown", true);
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
                }
                else if (PlayerControl2.canDash)
                {
                    //anim.SetBool("isCooldown", false);
                    sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
            else if (skillNum == 2)
            {
                if (!PlayerControl2.canParry)
                {
                    //anim.SetBool("isCooldown", true);
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1.0f);
                }
                else if (PlayerControl2.canParry)
                {
                    //anim.SetBool("isCooldown", false);
                    sr.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                }
            }
        }
    }
}
