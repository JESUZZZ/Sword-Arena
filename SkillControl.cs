using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillControl : MonoBehaviour
{
    public int player;
    public int character;
    public int skillNum;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        if (player == 1)
        {
            if (character != PlayerPrefs.GetInt("p1Choose"))
            {
                Destroy(gameObject);
            }
        }
        else if (player == 2)
        {
            if (character != PlayerPrefs.GetInt("p2Choose"))
            {
                Destroy(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == 1)
        {
            if (skillNum == 1)
            {
                if (PlayerControl.canSK1)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (!PlayerControl.canSK1)
                {
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
                }
            }
            else if (skillNum == 2)
            {
                if (PlayerControl.canSK2)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (!PlayerControl.canSK2)
                {
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
                }
            }
        }
        else if (player == 2)
        {
            if (skillNum == 1)
            {
                if (PlayerControl2.canSK1)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (!PlayerControl2.canSK1)
                {
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
                }
            }
            else if (skillNum == 2)
            {
                if (PlayerControl2.canSK2)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (!PlayerControl2.canSK2)
                {
                    sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
                }
            }
        }
    }
}
