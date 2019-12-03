using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonCooldown : MonoBehaviour
{
    public float cooldown;
    public float currentCooldown;
    public UnityEvent onClick;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown > 0)
        {
            Time.timeScale = 1;
            currentCooldown -= Time.deltaTime;

        }
    }

    public void getValue()
    {
        if (currentCooldown <= 0)
        {
            onClick.Invoke();
            currentCooldown = cooldown;
        }

    }
}
