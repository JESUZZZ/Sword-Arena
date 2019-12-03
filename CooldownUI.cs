using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownUI : MonoBehaviour
{
    public Text cooldownText;
    public float cooldown;
    public float cooldownRage;
    public int player;
    private float cooldownTemp;
    private float cooldownRageTemp;
    // Start is called before the first frame update
    void Start()
    {
        cooldownTemp = cooldown;
        cooldownRageTemp = cooldownRage;
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownText.enabled && LevelControl.p1HP > 0 && LevelControl.p2HP >0)
        {
            if (player == 1)
            {
                if (LevelControl.p1HP > 4)
                {
                    cooldownText.text = cooldown.ToString("0");
                }
                else
                {
                    cooldownText.text = cooldownRage.ToString("0");
                }
            }
            else if (player == 2)
            {
                if (LevelControl.p2HP > 4)
                {
                    cooldownText.text = cooldown.ToString("0");
                }
                else
                {
                    cooldownText.text = cooldownRage.ToString("0");
                }
            }
            cooldown -= Time.deltaTime;
            cooldownRage -= Time.deltaTime;
        }

        else
        {
            cooldown = cooldownTemp;
            cooldownRage = cooldownRageTemp;
        }

    }
}
