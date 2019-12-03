using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public Animator anim;
    public bool isHeart;
    public int player;
// Start is called before the first frame update
    void Start()
    {
         anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHeart)
        {
            if (player == 1)
            {
                if (LevelControl.p1HP < 5)
                {
                    anim.SetBool("isPump", true);
                }
            }
            else if (player == 2)
            {
                if (LevelControl.p2HP < 5)
                {
                    anim.SetBool("isPump", true);
                }
            }
        }

        if (LevelControl.isCountdownUI)
        {
            anim.SetBool("isCountdown", true);
        }
    }
}
