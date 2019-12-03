using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BGintro : MonoBehaviour
{
    public SpriteRenderer sr;
    public float delay;
    private bool canPress;
    public Text press;
    // Start is called before the first frame update
    void Start()
    {
        press.enabled = false;
        canPress = false;
        sr.color = new Color(0f, 0f, 0f, 1f);
        StartCoroutine(changeColor());
    }

    // Update is called once per frame
    void Update()
    {
        if (canPress)
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene("StartingScene");
            }
        }
    }
    IEnumerator changeColor()
    {
        yield return new WaitForSeconds(delay);
        sr.color = new Color(1f, 0.5f, 0f, 1f);
        canPress = true;
        press.enabled = true;
        StartCoroutine(textDisappear());
    }
    IEnumerator textDisappear()
    {
        yield return new WaitForSeconds(1f);
        press.enabled = false;
        StartCoroutine(textAppear());
    }
    IEnumerator textAppear()
    {
        yield return new WaitForSeconds(0.5f);
        press.enabled = true;
        StartCoroutine(textDisappear());
    }
}
