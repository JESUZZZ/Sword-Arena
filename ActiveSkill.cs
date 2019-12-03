using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActiveSkill : MonoBehaviour
{
    public int player;
    public int skillNum;
    public float cooldown;
    public float cooldownRage;
    private float cooldownCopy;
    private float cooldownRageCopy;
    public Text cooldownText;
    private float countdown;
    private bool changeCooldown;
    // Start is called before the first frame update
    void Start()
    {
        cooldownText.enabled = false;
        cooldownCopy = cooldown;
        cooldownRageCopy = cooldownRage;
        countdown = 10f;
        changeCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && (LevelControl.p1HP > 0 || LevelControl.p2HP > 0))
        {
            countdown = 0f;
            if (player == 1)
            {
                if (skillNum == 1)
                {
                    if (PlayerControl.canSK1)
                    {
                        cooldownText.enabled = false;
                    }
                    else if (!PlayerControl.canSK1)
                    {
                        cooldownText.enabled = true;
                    }
                }
                else if (skillNum == 2)
                {
                    if (PlayerControl.canSK2)
                    {
                        cooldownText.enabled = false;
                    }
                    else if (!PlayerControl.canSK2)
                    {
                        cooldownText.enabled = true;
                    }
                }
            }
            else if (player == 2)
            {
                if (skillNum == 1)
                {
                    if (PlayerControl2.canSK1)
                    {
                        cooldownText.enabled = false;
                    }
                    else if (!PlayerControl2.canSK1)
                    {
                        cooldownText.enabled = true;
                    }
                }
                else if (skillNum == 2)
                {
                    if (PlayerControl2.canSK2)
                    {
                        cooldownText.enabled = false;
                    }
                    else if (!PlayerControl2.canSK2)
                    {
                        cooldownText.enabled = true;
                    }
                }
            }

            if (cooldownText.enabled)
            {
                cooldownText.fontSize = 55;
                if (player == 1)
                {
                    if (LevelControl.p1HP <= 4 && changeCooldown)
                    {
                        cooldownText.text = cooldownRage.ToString("0");
                    }
                    else
                    {
                        cooldownText.text = cooldown.ToString("0");
                    }
                }
                else if (player == 2)
                {
                    if (LevelControl.p2HP <= 4 && changeCooldown)
                    {
                        cooldownText.text = cooldownRage.ToString("0");
                    }
                    else
                    {
                        cooldownText.text = cooldown.ToString("0");
                    }
                }
                cooldown -= Time.deltaTime;
                cooldownRage -= Time.deltaTime;
            }
            else if (!cooldownText.enabled)
            {
                cooldown = cooldownCopy;
                cooldownRage = cooldownRageCopy;
                if (player == 1 && LevelControl.p1HP <= 4)
                { 
                    changeCooldown = true;
                }
                else if (player == 2 && LevelControl.p2HP <= 4)
                {
                    changeCooldown = true;
                }
            }

        }

        if(LevelControl.p1HP <= 0 || LevelControl.p2HP <= 0)
        {
            cooldownText.enabled = false;
        }
        
    }
}
