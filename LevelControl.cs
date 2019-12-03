using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControl : MonoBehaviour
{
    public static int p1HP;
    public static int p2HP;

    public GameObject p1;
    public GameObject p2;
    public GameObject p1_char01;
    public GameObject p2_char01;
    public GameObject p1_char02;
    public GameObject p2_char02;
    public GameObject p1_char03;
    public GameObject p2_char03;
    public GameObject p1_char04;
    public GameObject p2_char04;
    public GameObject p1_char05;
    public GameObject p2_char05;
    public GameObject p1_char06;
    public GameObject p2_char06;
    public GameObject p1_char07;
    public GameObject p2_char07;

    public GameObject camShake;
    public GameObject finishButton1;
    public GameObject finishButton2;
    private int p1Choose;
    private int p2Choose;
    //private int textWin;

    public Text timeText;
    public int time;
    public int countdownTime;
    public static bool isCountdown;
    private int oneTimeMinus;
    private bool isEnd;
    public static bool isCountdownUI;

    public GameObject draw;
    public GameObject p1win;
    public GameObject p2win;
    private int expandCount;
    private bool canExpand;

    public static bool winByBoom;

    public GameObject p1Char01Icon;
    public GameObject p2Char01Icon;
    public GameObject p1Char02Icon;
    public GameObject p2Char02Icon;
    public GameObject p1Char03Icon;
    public GameObject p2Char03Icon;
    public GameObject p1Char04Icon;
    public GameObject p2Char04Icon;
    public GameObject p1Char05Icon;
    public GameObject p2Char05Icon;
    public GameObject p1Char06Icon;
    public GameObject p2Char06Icon;
    public GameObject p1Char07Icon;
    public GameObject p2Char07Icon;

    public Text fightText;
    private bool isDestroyFightText;
    private bool canDisableFightText;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;
    public GameObject level4;

    public Text p1Name;
    public Text p1Rank;
    public Text p2Name;
    public Text p2Rank;
    public Text p1_tl;
    public Text p2_tl;

    //endMatchRankDisplay
    public Text p1AccountName;
    public Text p1AccountRank;
    public Text p2AccountName;
    public Text p2AccountRank;
    public Text l_1;
    public Text l_2;
    public Text p1RankChangeUI;
    public Text p2RankChangeUI;
    private int p1RankChange;
    private int p2RankChange;
    private int p1NewRank;
    private int p2NewRank;
    private int endCondition;
    public GameObject p1Beginner;
    public GameObject p1Warrior;
    public GameObject p1Challenger;
    public GameObject p1King;
    public Text p1RankName;
    public GameObject p2Beginner;
    public GameObject p2Warrior;
    public GameObject p2Challenger;
    public GameObject p2King;
    public Text p2RankName;

    // Start is called before the first frame update
    void Awake()
    {
        p1HP = 12;
        p2HP = 12;
        camShake.SetActive(false);
        finishButton1.SetActive(false);
        finishButton2.SetActive(false);
        draw.SetActive(false);
        p1win.SetActive(false);
        p2win.SetActive(false);
        level1.SetActive(false);
        level2.SetActive(false);
        //textWin = Random.Range(1, 4);
        winByBoom = false;
        isDestroyFightText = false;
        p1AccountName.enabled = false;
        p1AccountRank.enabled = false;
        p2AccountName.enabled = false;
        p2AccountRank.enabled = false;
        p1_tl.enabled = false;
        p2_tl.enabled = false;
        l_1.enabled = false;
        l_2.enabled = false;
        p1RankChangeUI.enabled = false;
        p2RankChangeUI.enabled = false;

        //=========================================================TEST===================================================================
        /*PlayerPrefs.SetInt("p1Choose", 7);
        PlayerPrefs.SetInt("p2Choose", 6);
        PlayerPrefs.SetInt("level", 4);
        PlayerPrefs.SetInt("matchType", 1);*/
        //=========================================================TEST===================================================================

        p1Choose = PlayerPrefs.GetInt("p1Choose");
        p2Choose = PlayerPrefs.GetInt("p2Choose");

        isCountdown = false;
        oneTimeMinus = 0;
        isEnd = false;
        isCountdownUI = false;
        canDisableFightText = true;
        expandCount = 0;
        canExpand = true;
        p1NewRank = 10;
        p2NewRank = 10;
        p1Beginner.SetActive(false);
        p1Warrior.SetActive(false);
        p1Challenger.SetActive(false);
        p1King.SetActive(false);
        p1RankName.enabled = false;
        p2Beginner.SetActive(false);
        p2Warrior.SetActive(false);
        p2Challenger.SetActive(false);
        p2King.SetActive(false);
        p2RankName.enabled = false;

        if (p1Choose == 1)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Bull Knight";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char01.SetActive(true);
            p1Char01Icon.SetActive(true);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);
        }
        else if (p1Choose == 2)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Arkane Witch";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char02.SetActive(true);
            p1Char02Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);
        }
        else if (p1Choose == 3)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Poopsplash";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char03.SetActive(true);
            p1Char03Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);
        }
        else if (p1Choose == 4)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Gizmo";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char04.SetActive(true);
            p1Char04Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);

        }
        else if (p1Choose == 5)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Shadow";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char05.SetActive(true);
            p1Char05Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);
        }
        else if (p1Choose == 6)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Guardian";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char06.SetActive(true);
            p1Char06Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char07);
            Destroy(p1Char07Icon);
        }
        else if (p1Choose == 7)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p1Name.text = "Pace Breaker";
                p1Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p1Name.text = PlayerPrefs.GetString("p1AccountName");
                p1Rank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
                p1_tl.enabled = true;
                if (PlayerPrefs.GetInt("p1AccountRank") > 39)
                {
                    p1Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
                {
                    p1Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
                {
                    p1Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p1_char07.SetActive(true);
            p1Char07Icon.SetActive(true);
            Destroy(p1_char01);
            Destroy(p1Char01Icon);
            Destroy(p1_char02);
            Destroy(p1Char02Icon);
            Destroy(p1_char03);
            Destroy(p1Char03Icon);
            Destroy(p1_char04);
            Destroy(p1Char04Icon);
            Destroy(p1_char05);
            Destroy(p1Char05Icon);
            Destroy(p1_char06);
            Destroy(p1Char06Icon);
        }


        if (p2Choose == 1)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Bull Knight";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }
            
            p2_char01.SetActive(true);
            p2Char01Icon.SetActive(true);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);

        }
        else if (p2Choose == 2)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Arkane Witch";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char02.SetActive(true);
            p2Char02Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);
        }
        else if (p2Choose == 3)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Poopsplash";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char03.SetActive(true);
            p2Char03Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);
        }
        else if (p2Choose == 4)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Gizmo";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char04.SetActive(true);
            p2Char04Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);
        }
        else if (p2Choose == 5)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Shadow";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char05.SetActive(true);
            p2Char05Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);
        }
        else if (p2Choose == 6)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Guardian";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char06.SetActive(true);
            p2Char06Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char07);
            Destroy(p2Char07Icon);
        }
        else if (p2Choose == 7)
        {
            if (PlayerPrefs.GetInt("matchType") == 1)
            {
                p2Name.text = "Pace Breaker";
                p2Rank.enabled = false;
            }
            else if (PlayerPrefs.GetInt("matchType") == 2)
            {
                p2Name.text = PlayerPrefs.GetString("p2AccountName");
                p2Rank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                p2_tl.enabled = true;
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    p2Rank.color = new Color(1f, 0f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    p2Rank.color = new Color(1f, 0.5f, 0f, 1f);
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    p2Rank.color = new Color(1f, 1f, 0f, 1f);
                }
            }

            p2_char07.SetActive(true);
            p2Char07Icon.SetActive(true);
            Destroy(p2_char01);
            Destroy(p2Char01Icon);
            Destroy(p2_char02);
            Destroy(p2Char02Icon);
            Destroy(p2_char03);
            Destroy(p2Char03Icon);
            Destroy(p2_char04);
            Destroy(p2Char04Icon);
            Destroy(p2_char05);
            Destroy(p2Char05Icon);
            Destroy(p2_char06);
            Destroy(p2Char06Icon);
        }


        if (!isEnd)
        {
            StartCoroutine(timeReduction());
        }

        if(PlayerPrefs.GetInt("level") == 1)
        {
            level1.SetActive(true);
            Destroy(level2);
            Destroy(level3);
            Destroy(level4);
        }
        else if (PlayerPrefs.GetInt("level") == 2)
        {
            level2.SetActive(true);
            Destroy(level1);
            Destroy(level3);
            Destroy(level4);
        }
        else if (PlayerPrefs.GetInt("level") == 3)
        {
            level3.SetActive(true);
            Destroy(level1);
            Destroy(level2);
            Destroy(level4);
        }
        else if (PlayerPrefs.GetInt("level") == 4)
        {
            level4.SetActive(true);
            Destroy(level1);
            Destroy(level2);
            Destroy(level3);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (p1Choose == 1)
        {
            p1.transform.localPosition = p1_char01.transform.localPosition;
        }
        else if (p1Choose == 2)
        {
            p1.transform.localPosition = p1_char02.transform.localPosition;
        }
        else if (p1Choose == 3)
        {
            p1.transform.localPosition = p1_char03.transform.localPosition;
        }
        else if (p1Choose == 4)
        {
            p1.transform.localPosition = p1_char04.transform.localPosition;
        }
        else if (p1Choose == 5)
        {
            p1.transform.localPosition = p1_char05.transform.localPosition;
        }
        else if (p1Choose == 6)
        {
            p1.transform.localPosition = p1_char06.transform.localPosition;
        }
        else if (p1Choose == 7)
        {
            p1.transform.localPosition = p1_char07.transform.localPosition;
        }

        if (p2Choose == 1)
        {
            p2.transform.localPosition = p2_char01.transform.localPosition;
        }
        else if (p2Choose == 2)
        {
            p2.transform.localPosition = p2_char02.transform.localPosition;
        }
        else if (p2Choose == 3)
        {
            p2.transform.localPosition = p2_char03.transform.localPosition;
        }
        else if (p2Choose == 4)
        {
            p2.transform.localPosition = p2_char04.transform.localPosition;
        }
        else if (p2Choose == 5)
        {
            p2.transform.localPosition = p2_char05.transform.localPosition;
        }
        else if (p2Choose == 6)
        {
            p2.transform.localPosition = p2_char06.transform.localPosition;
        }
        else if (p2Choose == 7)
        {
            p2.transform.localPosition = p2_char07.transform.localPosition;
        }

        if (!isCountdown)
        {
            if (time > 0 && time < 151)
            {
                timeText.text = time.ToString();
                timeText.fontSize = 45;
            }
            else if (time > 150)
            {
                timeText.text = "READY";
                timeText.fontSize = 32;
            }
            else if (time > -2)
            {
                timeText.text = "ERROR";
                isCountdownUI = true;
                timeText.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                timeText.fontSize = 32;
            }
            else
            {
                isCountdown = true;
            }
        }
        else if (isCountdown)
        {
            if (time > 0)
            {
                timeText.text = time.ToString();
                timeText.fontSize = 45;
                timeText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else if (time > -2)
            {
                timeText.text = "BOOM";
                timeText.fontSize = 35;
                timeText.color = new Color(1.0f, 0.2f, 0.2f, 1.0f);
                if (oneTimeMinus < 1 && p1HP > 0 && p2HP > 0)
                {
                    oneTimeMinus++;
                    p1HP--;
                    p2HP--;
                    camShake.SetActive(true);
                    StartCoroutine(returnCamPos());
                    if (p1HP > 0 && p2HP > 0)
                    {
                        PlayerControl.isImmortal = true;
                        PlayerControl2.isImmortal = true;
                        camShake.SetActive(true);
                        StartCoroutine(returnCamPos());
                    }
                    else if ((p1HP<=0 && p2HP>0) || (p1HP > 0 && p2HP <= 0))
                    {
                        winByBoom = true;
                    }
                }
            }
            else
            {
                time = countdownTime;
                oneTimeMinus = 0;
            }
        }

        if(time > 158)
        {
            fightText.text = "STARTING";
        }
        else if (time == 158)
        {
            fightText.text = "STARTING.";
        }
        else if (time == 157)
        {
            fightText.text = "STARTING..";
        }
        else if (time == 156)
        {
            fightText.text = "STARTING...";
        }
        else if (time == 155)
        {
            fightText.fontSize = 70;
            fightText.text = "5";
        }
        else if (time == 154)
        {
            fightText.fontSize = 70;
            fightText.text = "4";
        }
        else if (time == 153)
        {
            fightText.color = new Color(1.0f, 1.0f, 0.6f, 1.0f);
            fightText.fontSize = 90;
            fightText.text = "3";
        }
        else if (time == 152)
        {
            fightText.fontSize = 110;
            fightText.text = "2";
        }
        else if (time == 151)
        {
            fightText.fontSize = 130;
            fightText.text = "1";
        }
        else
        {
            fightText.fontSize = 110;
            fightText.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            fightText.text = "!!!FIGHT!!!";
            if(canDisableFightText)
            {
                canDisableFightText = false;
                StartCoroutine(disableText(fightText, 0.3f));
            }
            StartCoroutine(returnFightText(1.8f));
            Destroy(fightText, 2.0f);
        }

        if (p1HP <= 0 || p2HP <= 0)
        {
            isEnd = true;
            timeText.enabled = false;
            StartCoroutine(returnButtonDelay());
            if ((p1HP <= 0 && p2HP <= 0) && canExpand)
            {
                endCondition = 1;
                canExpand = false;
                StartCoroutine(expand(0.1f, draw, 5.0f));
            }
            else if (p1HP <= 0 && canExpand)
            {
                endCondition = 2;
                canExpand = false;
                StartCoroutine(expand(0.1f, p2win, 6.0f));
            }
            else if (p2HP <= 0 && canExpand)
            {
                endCondition = 3;
                canExpand = false;
                StartCoroutine(expand(0.05f, p1win, 6.0f));
            }
            /*if(textWin == 1)
            {
                timeText.text = "GG";
            }
            else if (textWin == 2)
            {
                timeText.text = "WP";
            }
            else if (textWin == 3)
            {
                timeText.text = "NT";
            }
            else if (textWin == 4)
            {
                timeText.text = "LOL";
            }*/

        }

        if (AtkHB.isHit || AtkHB2.isHit || AtkHB2_range.isHit || AtkHB_range.isHit)
        {
            camShake.SetActive(true);
            StartCoroutine(returnCamPos());
        }
    }

    public void goMenu()
    {
        SceneManager.LoadScene("StartingScene", LoadSceneMode.Single);
    }
    public void goCharSelect()
    {
        SceneManager.LoadScene("CharacterSelection", LoadSceneMode.Single);
    }

    void rankCal(int winnerRank, int loserRank, int finalWinnerRank, int finalLoserRank, int endCondition)
    {
        finalWinnerRank = winnerRank;
        finalLoserRank = loserRank;

        /*if(winnerRank > 40)
        {
            finalWinnerRank += 1;
        }*/
        if (winnerRank > 30 && winnerRank < 40)
        {
            finalWinnerRank += 1;
        }
        else if (winnerRank > 20)
        {
            finalWinnerRank += 2;
        }
        else
        {
            finalWinnerRank += 3;
        }

        /*if (loserRank > 40)
        {
            finalLoserRank += 1;
        }*/
        if (loserRank > 30 && loserRank < 40)
        {
            finalLoserRank += 1;
        }
        else if (loserRank > 20)
        {
            finalLoserRank += 2;
        }
        else
        {
            finalLoserRank += 3;
        }

        if (endCondition != 1)
        {
            if (winnerRank - loserRank < 0)
            {
                finalWinnerRank += 4;
                finalLoserRank -= 4;
            }
            else if (winnerRank - loserRank < 8)
            {
                finalWinnerRank += 3;
                finalLoserRank -= 3;
            }
            else if (winnerRank - loserRank < 16)
            {
                finalWinnerRank += 2;
                finalLoserRank -= 2;
            }
            else
            {
                finalWinnerRank += 1;
                finalLoserRank -= 1;
            }
        }

        if(finalLoserRank < 1)
        {
            finalLoserRank = 1;
        }
        else if (finalLoserRank > 50)
        {
            finalLoserRank = 50;
        }
        if(finalWinnerRank < 1)
        {
            finalWinnerRank = 1;
        }
        else if (finalWinnerRank > 50)
        {
            finalWinnerRank = 50;
        }

        if(endCondition == 1)
        {
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex"), finalWinnerRank);
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex"), finalLoserRank);
        }
        else if (endCondition == 2)
        {
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex"), finalLoserRank);
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex"), finalWinnerRank);
        }
        else if (endCondition == 3)
        {
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex"), finalWinnerRank);
            PlayerPrefs.SetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex"), finalLoserRank);
        }
        PlayerPrefs.Save();
    }


    IEnumerator returnCamPos()
    {
        yield return new WaitForSeconds(0.15f);
        camShake.SetActive(false);
    }

    IEnumerator timeReduction()
    {
        yield return new WaitForSeconds(1.0f);
        if (time >= -1)
        {
            time--;
            StartCoroutine(timeReduction());
        }
    }

    IEnumerator disableText(Text txt, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isDestroyFightText)
        {
            txt.enabled = false;
            StartCoroutine(enableText(txt, delay));
        }
    }
    IEnumerator enableText(Text txt, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!isDestroyFightText)
        {
            txt.enabled = true;
            StartCoroutine(disableText(txt, delay));
        }
    }
    IEnumerator returnFightText(float delay)
    {
        yield return new WaitForSeconds(delay);
        isDestroyFightText = true;
    }
    IEnumerator expand(float delay, GameObject obj,float amount)
    {
        if (expandCount == 0)
        {
            yield return new WaitForSeconds(2.0f);
            obj.SetActive(true);
            obj.transform.localScale = new Vector3(1f, 1f, 1f);
            expandCount++;
            StartCoroutine(expand(delay, obj, amount));
        }
        else
        {
            yield return new WaitForSeconds(delay);
            obj.transform.localScale = new Vector3(obj.transform.localScale.x + amount, obj.transform.localScale.y + amount, obj.transform.localScale.z);
            expandCount++;
            if (expandCount < 10)
            {
                StartCoroutine(expand(delay, obj, amount));
            }
            else if(expandCount == 10 && PlayerPrefs.GetInt("matchType") == 2)
            {
                StartCoroutine(oldPlayerStat());
            }
        }
    }
    IEnumerator returnButtonDelay()
    {
        yield return new WaitForSeconds(3f);
        if (PlayerPrefs.GetInt("matchType") == 1)
        {
            finishButton1.SetActive(true);
            finishButton2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("matchType") == 2)
        {
            finishButton2.SetActive(true);
            finishButton2.transform.localPosition = new Vector3(0f, -350f, finishButton2.transform.position.z);
        }
    }

    IEnumerator oldPlayerStat()
    {
        yield return new WaitForSeconds(1.0f);
        p1AccountName.enabled = true;
        p1AccountRank.enabled = true;
        p2AccountName.enabled = true;
        p2AccountRank.enabled = true;
        l_1.enabled = true;
        l_2.enabled = true;
        p1AccountName.text = PlayerPrefs.GetString("p1AccountName");
        p1AccountRank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
        p2AccountName.text = PlayerPrefs.GetString("p2AccountName");
        p2AccountRank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
        StartCoroutine(newPlayerStat());
    }
    IEnumerator newPlayerStat()
    {
        yield return new WaitForSeconds(2.0f);
        p1RankChangeUI.enabled = true;
        p2RankChangeUI.enabled = true;
        if (endCondition == 1)
        {
            rankCal(PlayerPrefs.GetInt("p1AccountRank"), PlayerPrefs.GetInt("p2AccountRank"), p1NewRank, p2NewRank, endCondition);
        }
        else if (endCondition == 2)
        {
            rankCal(PlayerPrefs.GetInt("p2AccountRank"), PlayerPrefs.GetInt("p1AccountRank"), p1NewRank, p2NewRank, endCondition);
            /*p1AccountRank.color = new Color(1.0f, 0.4f, 0.4f, 1.0f);
            p2AccountRank.color = new Color(0.4f, 1.0f, 0.4f, 1.0f);*/
        }
        else if (endCondition == 3)
        {
            rankCal(PlayerPrefs.GetInt("p1AccountRank"), PlayerPrefs.GetInt("p2AccountRank"), p1NewRank, p2NewRank, endCondition);
            /*p1AccountRank.color = new Color(0.4f, 1.0f, 0.4f, 1.0f);
            p2AccountRank.color = new Color(1.0f, 0.4f, 0.4f, 1.0f);*/
        }

        p1RankChange = PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex")) -PlayerPrefs.GetInt("p1AccountRank"); 
        p2RankChange = PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex")) - PlayerPrefs.GetInt("p2AccountRank");
        if(p1RankChange < 0)
        {
            p1RankChangeUI.color = new Color(1.0f, 0.1f, 0.1f, 1.0f);
            p1RankChangeUI.text = p1RankChange.ToString();
            p1AccountRank.color = new Color(1.0f, 0.1f, 0.1f, 1.0f);
        }
        else if (p1RankChange > 0)
        {
            p1RankChangeUI.color = new Color(0.1f, 1.0f, 0.1f, 1.0f);
            p1RankChangeUI.text = "+" + p1RankChange.ToString();
            p1AccountRank.color = new Color(0.1f, 1.0f, 0.1f, 1.0f);
        }
        else if (p1RankChange == 0)
        {
            p1RankChangeUI.text = "+" + p1RankChange.ToString();
        }

        if (p2RankChange < 0)
        {
            p2RankChangeUI.color = new Color(1.0f, 0.1f, 0.1f, 1.0f);
            p2RankChangeUI.text = p2RankChange.ToString();
            p2AccountRank.color = new Color(1.0f, 0.1f, 0.1f, 1.0f);
        }
        else if (p2RankChange > 0)
        {
            p2RankChangeUI.color = new Color(0.1f, 1.0f, 0.1f, 1.0f);
            p2RankChangeUI.text = "+" + p2RankChange.ToString();
            p2AccountRank.color = new Color(0.1f, 1.0f, 0.1f, 1.0f);
        }
        else if(p2RankChange == 0)
        {
            p2RankChangeUI.text = "+" + p2RankChange.ToString();
        }
        p1AccountRank.text = PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex").ToString()).ToString();
        p1AccountRank.fontSize += 40;
        p2AccountRank.text = PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex").ToString()).ToString();
        p2AccountRank.fontSize += 40;
        rankIcon(PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p1AccountIndex").ToString()), PlayerPrefs.GetInt("PlayerRank" + PlayerPrefs.GetInt("p2AccountIndex").ToString()));
    }

    void rankIcon(int rank1,int rank2)
    {
        p1RankName.enabled = true;
        p2RankName.enabled = true;
        if (rank1 > 39)
        {
            p1RankName.text = "King";
            p1King.SetActive(true);
        }
        else if (rank1 > 29)
        {
            p1RankName.text = "Challenger";
            p1Challenger.SetActive(true);
        }
        else if (rank1 > 19)
        {
            p1RankName.text = "Warrior";
            p1Warrior.SetActive(true);
        }
        else
        {
            p1RankName.text = "Beginner";
            p1Beginner.SetActive(true);
        }

        if (rank2 > 39)
        {
            p2RankName.text = "King";
            p2King.SetActive(true);
        }
        else if (rank2 > 29)
        {
            p2RankName.text = "Challenger";
            p2Challenger.SetActive(true);
        }
        else if (rank2 > 19)
        {
            p2RankName.text = "Warrior";
            p2Warrior.SetActive(true);
        }
        else
        {
            p2RankName.text = "Beginner";
            p2Beginner.SetActive(true);
        }
    } 
}