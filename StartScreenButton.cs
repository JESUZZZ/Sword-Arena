using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class StartScreenButton : MonoBehaviour
{
    public GameObject logo;
    public GameObject start;
    public GameObject how2play;
    public GameObject quit;
    public GameObject credit;

    public GameObject normal;
    public GameObject rank;
    public GameObject back;

    public GameObject back2;
    public GameObject p1_logInRank;
    public GameObject p2_logInRank;
    public GameObject p1_registerRank;
    public GameObject p2_registerRank;
    public GameObject p1_back;
    public GameObject p2_back;

    public GameObject p1Stat;
    public GameObject p2Stat;
    public GameObject p1LogOut;
    public GameObject p2LogOut;
    public GameObject p1Confirm;
    public GameObject p2Confirm;

    private bool isP1Ready;
    private bool isP2Ready;

    public GameObject leaderboardBtn;
    public GameObject leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        logo.SetActive(true);
        start.SetActive(true);
        how2play.SetActive(true);
        quit.SetActive(true);
        credit.SetActive(true);
        normal.SetActive(false);
        rank.SetActive(false);
        back.SetActive(false);
        back2.SetActive(false);
        p1_logInRank.SetActive(false);
        p2_logInRank.SetActive(false);
        p1_registerRank.SetActive(false);
        p2_registerRank.SetActive(false);
        p1_back.SetActive(false);
        p2_back.SetActive(false);

        isP1Ready = false;
        isP2Ready = false;
        p1Stat.SetActive(false);
        p2Stat.SetActive(false);
        p1LogOut.SetActive(false);
        p2LogOut.SetActive(false);
        p1Confirm.SetActive(false);
        p2Confirm.SetActive(false);

        leaderboardBtn.SetActive(true);
        leaderboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isP1Ready && isP2Ready)
        {
            PlayerPrefs.SetInt("matchType", 2);
            SceneManager.LoadScene("CharacterSelection", LoadSceneMode.Single);
        }
    }

    public void newGame()
    {
        start.SetActive(false);
        how2play.SetActive(false);
        quit.SetActive(false);
        normal.SetActive(true);
        rank.SetActive(true);
        back.SetActive(true);
        leaderboardBtn.SetActive(false);
        credit.SetActive(false);
    }
    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay", LoadSceneMode.Single);
    }
    public void exit()
    {
        Application.Quit();
    }
    public void undo()
    {
        start.SetActive(true);
        how2play.SetActive(true);
        quit.SetActive(true);
        normal.SetActive(false);
        rank.SetActive(false);
        back.SetActive(false);
        leaderboardBtn.SetActive(true);
        credit.SetActive(true);
    }
    public void normalMatch()
    {
        SceneManager.LoadScene("CharacterSelection",LoadSceneMode.Single);
        PlayerPrefs.SetInt("matchType", 1);
    }
    public void rankMatch()
    {
        logo.SetActive(false);
        back.SetActive(false);
        rank.SetActive(false);
        normal.SetActive(false);
        back2.SetActive(true);
        p1_logInRank.SetActive(true);
        p2_logInRank.SetActive(true);
    }


    //===============================rankUI============================================
    public void undo2()
    {
        logo.SetActive(true);
        back.SetActive(true);
        rank.SetActive(true);
        normal.SetActive(true);
        back2.SetActive(false);
        p1_logInRank.SetActive(false);
        p2_logInRank.SetActive(false);
        p1_registerRank.SetActive(false);
        p2_registerRank.SetActive(false);
        p1Stat.SetActive(false);
        p2Stat.SetActive(false);
        p1Confirm.SetActive(false);
        p2Confirm.SetActive(false);
        p1LogOut.SetActive(false);
        p2LogOut.SetActive(false);
        PlayerPrefs.SetString("p1AccountName", "none");
        PlayerPrefs.SetInt("p1AccontRank", -1);
        PlayerPrefs.SetString("p2AccountName", "none");
        PlayerPrefs.SetInt("p2AccontRank", -1);
    }
    public void p1_Register()
    {
        p1_logInRank.SetActive(false);
        p1_registerRank.SetActive(true);
        p1_back.SetActive(true);
    }
    public void p2_Register()
    {
        p2_logInRank.SetActive(false);
        p2_registerRank.SetActive(true);
        p2_back.SetActive(true);
    }
    public void p1_undo()
    {
        p1_logInRank.SetActive(true);
        p1_registerRank.SetActive(false);
    }
    public void p2_undo ()
    {
        p2_logInRank.SetActive(true);
        p2_registerRank.SetActive(false);
    }

    public void p1LogIn()
    {
        if (PlayerRankAccount.p1Ready)
        {
            p1_logInRank.SetActive(false);
            //isP1Ready = true;
            p1Stat.SetActive(true);
            p1Confirm.SetActive(true);
            p1LogOut.SetActive(true);
        }
    }

    public void p2LogIn()
    {
        if (PlayerRankAccount.p2Ready)
        {
            p2_logInRank.SetActive(false);
            //isP2Ready = true;
            p2Stat.SetActive(true);
            p2Confirm.SetActive(true);
            p2LogOut.SetActive(true);
        }
    }

    public void p1Ready()
    {
        isP1Ready = true;
        back2.SetActive(false);
        p1LogOut.SetActive(false);
    }

    public void p2Ready()
    {
        isP2Ready = true;
        back2.SetActive(false);
        p2LogOut.SetActive(false);
    }

    //logoutButton
    public void p1SignOut()
    {
        p1_logInRank.SetActive(true);
        p1Stat.SetActive(false);
        p1Confirm.SetActive(false);
        p1LogOut.SetActive(false);
        PlayerPrefs.SetString("p1AccountName", "none");
        PlayerPrefs.SetInt("p1AccountRank", -1);
    }
    public void p2SignOut()
    {
        p2_logInRank.SetActive(true);
        p2Stat.SetActive(false);
        p2Confirm.SetActive(false);
        p2LogOut.SetActive(false);
        PlayerPrefs.SetString("p2AccountName", "none");
        PlayerPrefs.SetInt("p2AccountRank", -1);
    }

    //===============================rankUI============================================

    public void enterLeaderboard()
    {
        leaderboardBtn.SetActive(false);
        leaderboard.SetActive(true);
        logo.SetActive(false);
        start.SetActive(false);
        how2play.SetActive(false);
        quit.SetActive(false);
        credit.SetActive(false);
    }
    public void exitLeaderboard()
    {
        leaderboardBtn.SetActive(true);
        leaderboard.SetActive(false);
        logo.SetActive(true);
        start.SetActive(true);
        how2play.SetActive(true);
        quit.SetActive(true);
        credit.SetActive(true);
    }

}

