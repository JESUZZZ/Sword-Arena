using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSkill : MonoBehaviour
{
    public bool haveCharge;
    public Text chargeText;
    private int charge;
    private Vector3 normalScale;
    private Vector3 triggerScale;
    public float triggerScaleOffset;
    public int player;
    public int skillNum;
    private float countdown;
    // Start is called before the first frame update
    void Start()
    {
        if (haveCharge)
        {
            chargeText.enabled = true;
            chargeText.fontSize = 45;
            charge = 0;
            chargeText.text = charge.ToString();
        }
        else if (!haveCharge)
        {
            chargeText.enabled = false;
        }
        normalScale = transform.localScale;
        triggerScale = new Vector3(normalScale.x + triggerScaleOffset, normalScale.y + triggerScaleOffset, normalScale.z);
        countdown = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            countdown = 0f;
            if (player == 1)
            {
                if (skillNum == 1)
                {
                    if (PlayerControl.canSK1)
                    {
                        transform.localScale = triggerScale;
                    }
                    else if (!PlayerControl.canSK1)
                    {
                        transform.localScale = normalScale;
                    }
                }
                else if (skillNum == 2)
                {
                    if (PlayerControl.canSK2)
                    {
                        transform.localScale = triggerScale;
                    }
                    else if (!PlayerControl.canSK2)
                    {
                        transform.localScale = normalScale;
                    }
                }
            }
            else if (player == 2)
            {
                if (skillNum == 1)
                {
                    if (PlayerControl2.canSK1)
                    {
                        transform.localScale = triggerScale;
                    }
                    else if (!PlayerControl2.canSK1)
                    {
                        transform.localScale = normalScale;
                    }
                }
                else if (skillNum == 2)
                {
                    if (PlayerControl2.canSK2)
                    {
                        transform.localScale = triggerScale;
                    }
                    else if (!PlayerControl2.canSK2)
                    {
                        transform.localScale = normalScale;
                    }
                }
            }

            //charge character
            //character 3
            if (haveCharge && PlayerPrefs.GetInt("p1Choose") == 3)
            {
                charge = PlayerControl.trapCount;
                chargeText.text = charge.ToString();
                if (charge == 3)
                {
                    StartCoroutine(returnCharge());
                }
                else
                {
                    chargeText.enabled = true;
                    chargeText.color = new Color(1f, 1f, 1f, 1f);
                    chargeText.fontSize = 45;
                }
            }
            else if (haveCharge && PlayerPrefs.GetInt("p2Choose") == 3)
            {
                charge = PlayerControl2.trapCount;
                chargeText.text = charge.ToString();
                if (charge == 3)
                {
                    StartCoroutine(returnCharge());
                }
                else
                {
                    chargeText.enabled = true;
                    chargeText.color = new Color(1f, 1f, 1f, 1f);
                    chargeText.fontSize = 45;
                }
            }

            if ((LevelControl.p1HP <= 0 || LevelControl.p2HP <= 0) && haveCharge)
            {
                chargeText.enabled = false;
            }
        }

    }

    IEnumerator returnCharge()
    {
        chargeText.color = new Color(1f, 0f, 0f, 1f);
        chargeText.fontSize = 55;
        yield return new WaitForSeconds(1.0f);
        if (charge == 3)
        {
            chargeText.enabled = false;
        }
    }
}
