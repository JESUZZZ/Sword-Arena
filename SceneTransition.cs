using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public int allCharNumber;
    public GameObject leftSideScreen;
    public GameObject rightSideScreen;
    public GameObject[] leftSideChar;
    public GameObject[] rightSideChar;
    public GameObject[] leftSideName;
    public GameObject[] rightSideName;
    public float screen_startPos;
    public float screen_finishPos;
    public float speed;
    private bool oneTime;
    //private bool oneTime2;
    // Start is called before the first frame update
    void Start()
    {
        leftSideScreen.transform.localPosition = new Vector3(screen_startPos * -1f, leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        rightSideScreen.transform.localPosition = new Vector3(screen_startPos, leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        oneTime = true;
        //oneTime2 = true;
        //DontDestroyOnLoad(gameObject);
        for(int i = 0; i < allCharNumber; i++)
        {
            leftSideChar[i].SetActive(false);
            rightSideChar[i].SetActive(false);
            leftSideName[i].SetActive(false);
            rightSideName[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!CharSelect.p1Choosing && !CharSelect.p2Choosing && oneTime)
        {
            oneTime = false;
            leftSideChar[CharSelect.p1_charSelect - 1].SetActive(true);
            rightSideChar[CharSelect.p2_charSelect - 1].SetActive(true);
            leftSideName[CharSelect.p1_charSelect - 1].SetActive(true);
            rightSideName[CharSelect.p2_charSelect - 1].SetActive(true);
            StartCoroutine(screenTransition());
        }
        /*if (!LevelControl.isCountdownUI&& oneTime2)
        {
            oneTime2 = false;
            StartCoroutine(screenTransitionOut());
        }*/
    }
    

    IEnumerator screenTransition()
    {
        yield return new WaitForSeconds(0.1f);
        leftSideScreen.transform.localPosition = new Vector3(leftSideScreen.transform.position.x + (speed*Time.deltaTime), leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        rightSideScreen.transform.localPosition = new Vector3(rightSideScreen.transform.position.x - (speed * Time.deltaTime), leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        if (leftSideScreen.transform.position.x < screen_finishPos * -1f && rightSideScreen.transform.position.x > screen_finishPos)
        {
            StartCoroutine(screenTransition());
        }
        else if (leftSideScreen.transform.position.x >= screen_finishPos * -1f && rightSideScreen.transform.position.x <= screen_finishPos)
        {
            leftSideScreen.transform.localPosition = new Vector3(screen_finishPos * -1f, leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
            rightSideScreen.transform.localPosition = new Vector3(screen_finishPos, leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
            StartCoroutine(goNewScene());
        }
    }

    /*IEnumerator screenTransitionOut()
    {
        yield return new WaitForSeconds(0.1f);
        leftSideScreen.transform.localPosition = new Vector3(leftSideScreen.transform.position.x - (speed * Time.deltaTime), leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        rightSideScreen.transform.localPosition = new Vector3(rightSideScreen.transform.position.x + (speed * Time.deltaTime), leftSideScreen.transform.position.y, leftSideScreen.transform.position.z);
        if (leftSideScreen.transform.position.x > screen_startPos * -1f && rightSideScreen.transform.position.x < screen_startPos)
        {
            StartCoroutine(screenTransitionOut());
        }
        /*else if (leftSideScreen.transform.position.x <= screen_finishPos * -1f && rightSideScreen.transform.position.x >= screen_finishPos)
        {
            Destroy(gameObject);
        }

    }*/

    IEnumerator goNewScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("FightingScene", LoadSceneMode.Single);

    }
}
