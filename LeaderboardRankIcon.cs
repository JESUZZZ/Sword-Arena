using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LeaderboardRankIcon : MonoBehaviour
{
    public GameObject beginner;
    public GameObject warrior;
    public GameObject challenger;
    public GameObject king;
    public Text rank;
    private int rankNum;
    // Start is called before the first frame update
    void Start()
    {
        beginner.SetActive(false);
        warrior.SetActive(false);
        challenger.SetActive(false);
        king.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        leaderboard();
    }
    void leaderboard()
    {
        rankNum = System.Convert.ToInt32(rank.text);
        if (rankNum > 39)
        {
            king.SetActive(true);
        }
        else if (rankNum > 29)
        {
            challenger.SetActive(true);
        }
        else if (rankNum > 19)
        {
            warrior.SetActive(true);
        }
        else if (rankNum > 0)
        {
            beginner.SetActive(true);
        }
    }
}
