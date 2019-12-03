using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackIcon : MonoBehaviour
{
    public int player;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1)
        {
            if (PlayerControl.canAttack)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (!PlayerControl.canAttack)
            {
                sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
            }
        }
        else if (player == 2)
        {
            if (PlayerControl2.canAttack)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (!PlayerControl2.canAttack)
            {
                sr.color = new Color(0.4f, 0.4f, 0.4f, 1f);
            }

        }
    }
}
