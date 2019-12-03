using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugCheck : MonoBehaviour
{
    public int player;
    public float dashLength;
    public float parryLength;
    public float stunLength;
    private float dashLengthTemp;
    private float parryLengthTemp;
    private float stunLengthTemp;
    // Start is called before the first frame update
    void Start()
    {
        dashLengthTemp = dashLength;
        parryLengthTemp = parryLength;
        stunLengthTemp = stunLength;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1)
        {
            if (PlayerControl.whileDash)
            {
                dashLengthTemp -= Time.deltaTime;
                if (dashLengthTemp <= 0)
                {
                    PlayerControl.whileDash = false;
                }
            }
            else if (!PlayerControl.whileDash)
            {
                dashLengthTemp = dashLength;
            }

            if (PlayerControl.whileParry)
            {
                parryLengthTemp -= Time.deltaTime;
                if (parryLengthTemp <= 0)
                {
                    PlayerControl.whileParry = false;
                }
            }
            else if (!PlayerControl.whileParry)
            {
                parryLengthTemp = parryLength;
            }

            if (PlayerControl.isStun)
            {
                stunLengthTemp -= Time.deltaTime;
                if (stunLengthTemp <= 0)
                {
                    PlayerControl.isStun = false;
                }
            }
            else if (!PlayerControl.isStun)
            {
                stunLengthTemp = stunLength;
            }

        }
        else if (player == 2)
        {
            if (PlayerControl2.whileDash)
            {
                dashLengthTemp -= Time.deltaTime;
                if (dashLengthTemp <= 0)
                {
                    PlayerControl2.whileDash = false;
                }
            }
            else if (!PlayerControl2.whileDash)
            {
                dashLengthTemp = dashLength;
            }

            if (PlayerControl2.whileParry)
            {
                parryLengthTemp -= Time.deltaTime;
                if (parryLengthTemp <= 0)
                {
                    PlayerControl2.whileParry = false;
                }
            }
            else if (!PlayerControl2.whileParry)
            {
                parryLengthTemp = parryLength;
            }

            if (PlayerControl2.isStun)
            {
                stunLengthTemp -= Time.deltaTime;
                if (stunLengthTemp <= 0)
                {
                    PlayerControl2.isStun = false;
                }
            }
            else if (!PlayerControl2.isStun)
            {
                stunLengthTemp = stunLength;
            }
        }
    }
}
