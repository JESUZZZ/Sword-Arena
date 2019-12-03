using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRankAccount : MonoBehaviour
{
    public int playerAmount;
    private string[] playerName;
    private int[] playerRank;

    //==========================================================REGISTER==========================================================
    private bool canRegister;
    public InputField p1_register_1;
    public InputField p1_register_2;
    public Text p1_register_status;
    public InputField p2_register_1;
    public InputField p2_register_2;
    public Text p2_register_status;
    //==========================================================REGISTER==========================================================


    //==========================================================LOGIN==========================================================
    public InputField p1_logIn;
    public Text p1_logIn_status;
    public InputField p2_logIn;
    public Text p2_logIn_status;

    public Text p1Name;
    public Text p1Rank;
    public Text p2Name;
    public Text p2Rank;
    public Text p2rankName;
    public Text p1rankName;
    public static bool p1Ready;
    public static bool p2Ready;
    public GameObject p1_beginner;
    public GameObject p1_warrior;
    public GameObject p1_challenger;
    public GameObject p1_king;
    public GameObject p2_beginner;
    public GameObject p2_warrior;
    public GameObject p2_challenger;
    public GameObject p2_king;
    //==========================================================LOGIN==========================================================


    //==========================================================LEADERBOARD==========================================================
    public List<Text> l_name;
    public List<Text> l_rank;
    //==========================================================LEADERBOARD==========================================================

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("p1AccountName", "");
        PlayerPrefs.SetInt("p1AccountRank", -1);
        PlayerPrefs.SetString("p2AccountName", "");
        PlayerPrefs.SetInt("p2AccountRank", -1);
        canRegister = false;
        p1_register_status.enabled = false;
        p2_register_status.enabled = false;
        p1_logIn_status.enabled = false;
        p2_logIn_status.enabled = false;

        playerName = new string[playerAmount];
        playerRank = new int[playerAmount];
        p1Ready = false;
        p2Ready = false;
        loadAccount();
        /*for(int i = 0; i < playerAmount; i++)
        {
            Debug.Log(playerName[i] + "  " + playerRank[i]);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
    }

    void loadAccount()
    {
        
        for(int i = 0; i< 50; i++)
        {
            if (PlayerPrefs.GetInt("PlayerRank" + i.ToString()) > 0)
            {
                playerName[i] = PlayerPrefs.GetString("PlayerName" + i.ToString());
                playerRank[i] = PlayerPrefs.GetInt("PlayerRank" + i.ToString());
            }
            else
            {
                playerName[i] = "none";
                playerRank[i] = -1;
            }
        }
        for(int i = 0; i<playerAmount; i++)
        {
            if (playerName[i] == "none")
            {
                canRegister = true;
                break;
            }
        }
        PlayerPrefs.Save();
    }

    //==========================================================REGISTER==========================================================
    public void p1_accountRegister()
    {
        if (canRegister)
        {
            if (p1_register_1.text == p1_register_2.text && p1_register_1.text.Length > 2)
            {
                bool isAlreadyRegister = false ;
                for (int i = 0; i < playerAmount; i++)
                {
                    if (playerName[i] == p1_register_1.text)
                    {
                        p1_register_status.enabled = true;
                        p1_register_status.text = "Account is already registered";
                        StartCoroutine(statusDisappear(p1_register_status));
                        isAlreadyRegister = true;
                        break;
                    }
                }
                if (!isAlreadyRegister)
                {
                    for(int i = 0; i < playerAmount; i++)
                    {
                        if(playerName[i] == "none")
                        {
                            PlayerPrefs.SetString("PlayerName" + i.ToString(), p1_register_1.text);
                            PlayerPrefs.SetInt("PlayerRank" + i.ToString(), 10);
                            loadAccount();
                            break;
                        }
                    }
                    p1_register_1.text = "";
                    p1_register_2.text = "";
                    p1_register_status.enabled = true;
                    p1_register_status.text = "Registration Complete";
                    StartCoroutine(statusDisappear(p1_register_status));
                }
            }
            else
            {
                p1_register_status.enabled = true;
                p1_register_status.text = "Unable to register";
                StartCoroutine(statusDisappear(p1_register_status));
            }
        }
        else
        {
            p1_register_status.enabled = true;
            p1_register_status.text = "Your account is fulled";
            StartCoroutine(statusDisappear(p1_register_status));
        }
    }


    public void p2_accountRegister()
    {
        if (canRegister)
        {
            if (p2_register_1.text == p2_register_2.text && p2_register_1.text.Length > 2)
            {
                bool isAlreadyRegister = false;
                for (int i = 0; i < playerAmount; i++)
                {
                    if (playerName[i] == p2_register_1.text)
                    {
                        p2_register_status.enabled = true;
                        p2_register_status.text = "Account is already registered";
                        StartCoroutine(statusDisappear(p2_register_status));
                        isAlreadyRegister = true;
                        break;
                    }
                }
                if (!isAlreadyRegister)
                {
                    for (int i = 0; i < playerAmount; i++)
                    {
                        if (playerName[i] == "none")
                        {
                            PlayerPrefs.SetString("PlayerName" + i.ToString(), p2_register_1.text);
                            PlayerPrefs.SetInt("PlayerRank" + i.ToString(), 10);
                            loadAccount();
                            break;
                        }
                    }
                    p2_register_1.text = "";
                    p2_register_2.text = "";
                    p2_register_status.enabled = true;
                    p2_register_status.text = "Registration Complete";
                    StartCoroutine(statusDisappear(p2_register_status));
                }
            }
            else
            {
                p2_register_status.enabled = true;
                p2_register_status.text = "Unable to register";
                StartCoroutine(statusDisappear(p2_register_status));
            }
        }
        else
        {
            p2_register_status.enabled = true;
            p2_register_status.text = "Your account is fulled";
            StartCoroutine(statusDisappear(p2_register_status));
        }
    }

    public void p1UndoRegister()
    {
        p1_register_status.enabled = false;
        /*PlayerPrefs.SetString("p1AccountName", "");
        PlayerPrefs.SetInt("p1AccountRank", -1);*/
    }
    public void p2UndoRegister()
    {
        p2_register_status.enabled = false;
        /*PlayerPrefs.SetString("p2AccountName", "");
        PlayerPrefs.SetInt("p2AccountRank", -1);*/
    }
    public void undoLogin()
    {
        PlayerPrefs.SetString("p1AccountName", "");
        PlayerPrefs.SetInt("p1AccountRank", -1);
        PlayerPrefs.SetString("p2AccountName", "");
        PlayerPrefs.SetInt("p2AccountRank", -1);
        p1_logIn_status.enabled = false;
        p2_logIn_status.enabled = false;
    }
    //==========================================================REGISTER==========================================================

    //==========================================================LOGIN==========================================================
    public void p1LogIn()
    {
        bool canLogIn = false;
        for (int i = 0; i < playerAmount; i++)
        {
            if (p1_logIn.text == playerName[i] && p1_logIn.text != PlayerPrefs.GetString("p2AccountName"))
            {
                p1Ready = true;
                PlayerPrefs.SetString("p1AccountName", playerName[i]);
                PlayerPrefs.SetInt("p1AccountRank", playerRank[i]);
                PlayerPrefs.SetInt("p1AccountIndex", i);
                canLogIn = true;
                p1_logIn_status.enabled = true;
                p1_logIn_status.text = "Log-in complete";
                p1Name.text = playerName[i];
                p1Rank.text = playerRank[i].ToString();
                p1_beginner.SetActive(true);
                p1_warrior.SetActive(false);
                p1_challenger.SetActive(false);
                p1_king.SetActive(false);
                p1rankName.text = "Beginner";
                if (playerRank[i] > 39)
                {
                    l_rank[i].color = new Color(1f, 0f, 0f, 1f);
                    p1_beginner.SetActive(false);
                    p1_warrior.SetActive(false);
                    p1_challenger.SetActive(false);
                    p1_king.SetActive(true);
                    p1rankName.text = "King";
                }
                else if (playerRank[i] > 29)
                {
                    l_rank[i].color = new Color(1f, 0.5f, 0f, 1f);
                    p1_beginner.SetActive(false);
                    p1_warrior.SetActive(false);
                    p1_challenger.SetActive(true);
                    p1_king.SetActive(false);
                    p1rankName.text = "Challenger";
                }
                else if (playerRank[i] > 19)
                {
                    l_rank[i].color = new Color(1f, 1f, 0f, 1f);
                    p1_beginner.SetActive(false);
                    p1_warrior.SetActive(true);
                    p1_challenger.SetActive(false);
                    p1_king.SetActive(false);
                    p1rankName.text = "Warrior";
                }
                break;
            }
        }
        if (!canLogIn)
        {
            p1_logIn_status.enabled = true;
            p1_logIn_status.text = "Unable to log-in";
            StartCoroutine(statusDisappear(p1_logIn_status));
        }
    }

    public void p2LogIn()
    {
        bool canLogIn = false;
        for (int i = 0; i < playerAmount; i++)
        {
            if (p2_logIn.text == playerName[i] && p2_logIn.text != PlayerPrefs.GetString("p1AccountName"))
            {
                p2Ready = true;
                PlayerPrefs.SetString("p2AccountName", playerName[i]);
                PlayerPrefs.SetInt("p2AccountRank", playerRank[i]);
                PlayerPrefs.SetInt("p2AccountIndex", i);
                canLogIn = true;
                p2_logIn_status.enabled = true;
                p2_logIn_status.text = "Log-in complete";
                p2Name.text = playerName[i];
                p2Rank.text = playerRank[i].ToString();
                p2_beginner.SetActive(true);
                p2_warrior.SetActive(false);
                p2_challenger.SetActive(false);
                p2_king.SetActive(false);
                p2rankName.text = "Beginner";
                if (playerRank[i] > 39)
                {
                    l_rank[i].color = new Color(1f, 0f, 0f, 1f);
                    p2_beginner.SetActive(false);
                    p2_warrior.SetActive(false);
                    p2_challenger.SetActive(false);
                    p2_king.SetActive(true);
                    p2rankName.text = "King";
                }
                else if (playerRank[i] > 29)
                {
                    l_rank[i].color = new Color(1f, 0.5f, 0f, 1f);
                    p2_beginner.SetActive(false);
                    p2_warrior.SetActive(false);
                    p2_challenger.SetActive(true);
                    p2_king.SetActive(false);
                    p2rankName.text = "Challenger";
                }
                else if (playerRank[i] > 19)
                {
                    l_rank[i].color = new Color(1f, 1f, 0f, 1f);
                    p2_beginner.SetActive(false);
                    p2_warrior.SetActive(true);
                    p2_challenger.SetActive(false);
                    p2_king.SetActive(false);
                    p2rankName.text = "Warrior";
                }
                break;
            }
        }
        if (!canLogIn)
        {
            p2_logIn_status.enabled = true;
            p2_logIn_status.text = "Unable to log-in";
            StartCoroutine(statusDisappear(p2_logIn_status));
        }
    }

    public void p1LogOut()
    {
        p1_logIn_status.enabled = false;
        /*PlayerPrefs.SetString("p1AccountName", "none");
        PlayerPrefs.SetInt("p1AccountRank", -1);*/
    }
    public void p2LogOut()
    {
        p2_logIn_status.enabled = false;
        /*PlayerPrefs.SetString("p2AccountName", "none");
        PlayerPrefs.SetInt("p2AccountRank", -1);*/
    }

    //==========================================================LOGIN==========================================================

    //==========================================================LEADERBOARD==========================================================

    public void leaderboard()
    {
        string[] topName = new string[10];
        int[] topRank = new int[10];
        for (int time = 0; time < 10; time++)
        {
            int max = 0;
            if (time == 0)
            {
                for (int i = 0; i < playerAmount; i++)
                {
                    if(playerRank[i] > max)
                    {
                        max = playerRank[i];
                        topName[time] = playerName[i];
                        topRank[time] = playerRank[i];
                    }

                }
            }
            else
            {
                for(int i = 0; i < playerAmount; i++)
                {
                    if (playerRank[i] > max && playerRank[i] < topRank[time-1])
                    {
                        max = playerRank[i];
                        topName[time] = playerName[i];
                        topRank[time] = playerRank[i];
                    }
                    else if (playerRank[i] == topRank[time - 1] /*&& playerName[i] != topName[time - 1]*/)
                    {
                        bool isOnBoard = false;
                        for(int j = 0; j < 10; j++)
                        {
                            if(playerName[i] == topName[j])
                            {
                                isOnBoard = true;
                            }
                        }
                        if (!isOnBoard)
                        {
                            topName[time] = playerName[i];
                            topRank[time] = playerRank[i];
                            i = playerAmount;
                        }
                    }
                }
            }
        }
        for(int i = 0; i < 10; i++)
        {
            if (topRank[i] > 0)
            {
                l_name[i].text = topName[i];
                l_rank[i].text = topRank[i].ToString();
                if(topRank[i] > 39)
                {
                    l_rank[i].color = new Color(1f, 0f, 0f, 1f);
                }
                else if (topRank[i]> 29)
                {
                    l_rank[i].color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (topRank[i] > 19)
                {
                    l_rank[i].color = new Color(1f, 1f, 0f, 1f);
                }
            }
        }

    }

    //==========================================================LEADERBOARD==========================================================

    IEnumerator statusDisappear(Text status)
    {
        yield return new WaitForSeconds(1.5f);
        status.enabled = false;
    }
}
