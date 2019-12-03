using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimBG : MonoBehaviour
{
    public SpriteRenderer bg;
    // Start is called before the first frame update
    void Start()
    {
        bg.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dim()
    {
        bg.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
    public void unDim()
    {
        bg.color = new Color(1f, 1f, 1f, 1f);
    }
}
