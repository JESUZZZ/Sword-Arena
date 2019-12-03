using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIdisappear : MonoBehaviour
{
    public float delay;
    private bool canDisappear;
    // Start is called before the first frame update
    void Start()
    {
        canDisappear = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((LevelControl.p1HP <=0 || LevelControl.p2HP <= 0) && canDisappear)
        {
            canDisappear = false;
            StartCoroutine(disappear());
        }
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
