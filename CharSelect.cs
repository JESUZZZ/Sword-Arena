using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour
{
    public static int p1_charSelect;
    public static int p2_charSelect;
    public static bool p1Choosing;
    public static bool p2Choosing;
    public Transform p1CharApp;
    public Transform p2CharApp;
    public GameObject char01;
    public GameObject char02;
    public GameObject char03;
    public GameObject char04;
    public GameObject char05;
    public GameObject char06;
    public GameObject char07;
    public Button char01Button;
    public Button char02Button;
    public Button char03Button;
    public Button char04Button;
    public Button char05Button;
    public Button char06Button;
    public Button char07Button;
    private int firstPick;
    private Vector3 normalScale;
    private Vector3 pickedScale;
    public Text playerTurnText;
    public Text turnNumber;
    public Text turnNumberShadow;
    public Text only4TMode;
    public Text tl20;
    public Text tl30;
    public Text tl40;

    private GameObject temp_p1;
    private GameObject temp_p2;

    private int level;
    public GameObject level_1;
    public GameObject level_2;
    public GameObject level_3;
    public GameObject level_4;

    public Text p1_charName;
    public Text p2_charName;
    public Text playerName;
    public Text playerRank;
    public Text tl;

    // Start is called before the first frame update
    void Start()
    {
        //===========TEST=================
        //PlayerPrefs.SetInt("matchType", 1);
        //===========TEST=================
        p1_charSelect = 0;
        p2_charSelect = 0;
        firstPick = 0;
        p1Choosing = true;
        p2Choosing = false;
        normalScale = new Vector3(1.0f, 1.0f, 1.0f);
        pickedScale = new Vector3(1.15f, 1.15f, 1.0f);
        playerTurnText.text = "Player   's Turn to Choose";
        turnNumber.text = "1";
        turnNumberShadow.text = "1";
        level = Random.Range(1, 5);
        //level = 2;
        PlayerPrefs.SetInt("level", level);
        p1_charName.enabled = false;
        p2_charName.enabled = false;
        playerName.enabled = false;
        playerRank.enabled = false;
        tl.enabled = false;
        tl20.enabled = false;
        tl30.enabled = false;
        tl40.enabled = false;
        only4TMode.enabled = true;
        level_1.SetActive(false);
        level_2.SetActive(false);
        level_3.SetActive(false);
        level_4.SetActive(false);
        char05Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        char06Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        char07Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        if (level == 1)
        {
            level_1.SetActive(true);
        }
        else if (level == 2)
        {
            level_2.SetActive(true);
        }
        else if (level == 3)
        {
            level_3.SetActive(true);
        }
        else if (level == 4)
        {
            level_4.SetActive(true);
        }

        if (PlayerPrefs.GetInt("matchType") == 2)
        {
            //char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
            playerName.enabled = true;
            playerRank.enabled = true;
            tl.enabled = true;
            tl40.enabled = true;
            tl30.enabled = true;
            tl20.enabled = true;
            only4TMode.enabled = false;
            playerName.text = PlayerPrefs.GetString("p1AccountName");
            playerRank.text = PlayerPrefs.GetInt("p1AccountRank").ToString();
            if (PlayerPrefs.GetInt("p1AccountRank") > 39)
            {
                playerRank.color = new Color(1f, 0f, 0f, 1f);
                char07Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                char06Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                tl40.enabled = false;
                tl30.enabled = false;
                tl20.enabled = false;
            }
            else if (PlayerPrefs.GetInt("p1AccountRank") > 29)
            {
                playerRank.color = new Color(1f, 0.5f, 0f, 1f);
                char06Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                tl30.enabled = false;
                tl20.enabled = false;
            }
            else if (PlayerPrefs.GetInt("p1AccountRank") > 19)
            {
                playerRank.color = new Color(1f, 1f, 0f, 1f);
                char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                tl20.enabled = false;
            }
            else
            {
                playerRank.color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!p1Choosing && !p2Choosing)
        {
            playerName.enabled = false;
            playerRank.enabled = false;
            tl.enabled = false;
            tl20.enabled = false;
            tl30.enabled = false;
            tl40.enabled = false;
            only4TMode.enabled = false;
            playerTurnText.text = "...LOADING...";
        }
    }

    public void chooseChar01()
    {
        if (p1Choosing && p1_charSelect != 1)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = pickedScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 1;
            temp_p1 = Instantiate(char01, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Bull Knight";
        }
        else if (p2Choosing && p2_charSelect != 1 && firstPick != 1)
        { 
            Destroy(temp_p2);
            char01Button.transform.localScale = pickedScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 1;
            temp_p2 = Instantiate(char01, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Bull Knight";
        }
    }

    public void chooseChar02()
    {
        if (p1Choosing && p1_charSelect != 2)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = pickedScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 2;
            temp_p1 = Instantiate(char02, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Arkane Witch";

        }
        else if (p2Choosing && p2_charSelect != 2 && firstPick != 2)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = pickedScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 2;
            temp_p2 = Instantiate(char02, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Arkane Witch";

        }
    }

    public void chooseChar03()
    {
        if (p1Choosing && p1_charSelect != 3)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = pickedScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 3;
            temp_p1 = Instantiate(char03, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Poopsplash";

        }
        else if (p2Choosing && p2_charSelect != 3 && firstPick != 3)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = pickedScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 3;
            temp_p2 = Instantiate(char03, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Poopsplash";

        }
    }

    public void chooseChar04()
    {
        if (p1Choosing && p1_charSelect != 4)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = pickedScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 4;
            temp_p1 = Instantiate(char04, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Gizmo";

        }
        else if (p2Choosing && p2_charSelect != 4 && firstPick != 4)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = pickedScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 4;
            temp_p2 = Instantiate(char04, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Gizmo";

        }
    }

    public void chooseChar05()
    {
        if (p1Choosing && p1_charSelect != 5 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p1AccountRank") >= 20)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = pickedScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 5;
            temp_p1 = Instantiate(char05, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Shadow";

        }
        else if (p2Choosing && p2_charSelect != 5 && firstPick != 5 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p2AccountRank") >= 20)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = pickedScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 5;
            temp_p2 = Instantiate(char05, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Shadow";

        }
    }

    public void chooseChar06()
    {
        if (p1Choosing && p1_charSelect != 6 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p1AccountRank") >= 30)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = pickedScale;
            char07Button.transform.localScale = normalScale;
            p1_charSelect = 6;
            temp_p1 = Instantiate(char06, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Guardian";

        }
        else if (p2Choosing && p2_charSelect != 6 && firstPick != 6 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p2AccountRank") >= 30)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = pickedScale;
            char07Button.transform.localScale = normalScale;
            p2_charSelect = 6;
            temp_p2 = Instantiate(char06, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Guardian";

        }
    }

    public void chooseChar07()
    {
        if (p1Choosing && p1_charSelect != 7 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p1AccountRank") >= 40)
        {
            Destroy(temp_p1);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = pickedScale;
            p1_charSelect = 7;
            temp_p1 = Instantiate(char07, new Vector3(p1CharApp.transform.position.x, p1CharApp.transform.position.y, p1CharApp.transform.position.z), Quaternion.identity);
            p1_charName.enabled = true;
            p1_charName.text = "Pace Breaker";

        }
        else if (p2Choosing && p2_charSelect != 7 && firstPick != 7 && PlayerPrefs.GetInt("matchType") == 2 && PlayerPrefs.GetInt("p2AccountRank") >= 40)
        {
            Destroy(temp_p2);
            char01Button.transform.localScale = normalScale;
            char02Button.transform.localScale = normalScale;
            char03Button.transform.localScale = normalScale;
            char04Button.transform.localScale = normalScale;
            char05Button.transform.localScale = normalScale;
            char06Button.transform.localScale = normalScale;
            char07Button.transform.localScale = pickedScale;
            p2_charSelect = 7;
            temp_p2 = Instantiate(char07, new Vector3(p2CharApp.transform.position.x, p2CharApp.transform.position.y, p2CharApp.transform.position.z), Quaternion.identity);
            p2_charName.enabled = true;
            p2_charName.text = "Pace Breaker";

        }
    }

    public void comfirmChar()
    {
        if (p1Choosing && p1_charSelect != 0)
        {
            p2Choosing = true;
            p1Choosing = false;
            firstPick = p1_charSelect;
            PlayerPrefs.SetInt("p1Choose", p1_charSelect);
            if (PlayerPrefs.GetInt("matchType") == 2)
            {
                char05Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char06Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char07Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                tl20.enabled = true;
                tl30.enabled = true;
                tl40.enabled = true;
                playerName.text = " " + PlayerPrefs.GetString("p2AccountName");
                playerRank.text = PlayerPrefs.GetInt("p2AccountRank").ToString();
                if (PlayerPrefs.GetInt("p2AccountRank") > 39)
                {
                    playerRank.color = new Color(1f, 0f, 0f, 1f);
                    tl20.enabled = false;
                    tl30.enabled = false;
                    tl40.enabled = false;
                    if (p1_charSelect != 5)
                    {
                        char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                    if (p1_charSelect != 6)
                    {
                        char06Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                    if (p1_charSelect != 7)
                    {
                        char07Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 29)
                {
                    playerRank.color = new Color(1f, 0.5f, 0f, 1f);
                    tl20.enabled = false;
                    tl30.enabled = false;
                    if (p1_charSelect != 5)
                    {
                        char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                    if (p1_charSelect != 6)
                    {
                        char06Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                }
                else if (PlayerPrefs.GetInt("p2AccountRank") > 19)
                {
                    playerRank.color = new Color(1f, 1f, 0f, 1f);
                    tl20.enabled = false;
                    if (p1_charSelect != 5)
                    {
                        char05Button.image.color = new Color(1f, 1f, 1f, 1.0f);
                    }
                }
                else
                {
                    playerRank.color = new Color(1f, 1f, 1f, 1f);
                }
            }
            if (p1_charSelect == 1)
            {
                char01Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char01Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 2)
            {
                char02Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char02Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 3)
            {
                char03Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char03Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 4)
            {
                char04Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char04Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 5)
            {
                char05Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char05Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 6)
            {
                char06Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char06Button.transform.localScale = normalScale;
            }
            else if (p1_charSelect == 5)
            {
                char07Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char07Button.transform.localScale = normalScale;
            }
            playerTurnText.text = "Player    's Turn to Choose";
            turnNumber.text = "2";
            turnNumberShadow.text = "2";
        }
        else if (p2Choosing && p2_charSelect != 0)
        {
            p2Choosing = false;
            PlayerPrefs.SetInt("p2Choose", p2_charSelect);
            if (p2_charSelect == 1)
            {
                char01Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char01Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 2)
            {
                char02Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char02Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 3)
            {
                char03Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char03Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 4)
            {
                char04Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char04Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 5)
            {
                char05Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char05Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 6)
            {
                char06Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char06Button.transform.localScale = normalScale;
            }
            else if (p2_charSelect == 7)
            {
                char07Button.image.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
                char07Button.transform.localScale = normalScale;
            }
            Destroy(turnNumber);
            Destroy(turnNumberShadow);
        }
    }

    public void goHome()
    {
        SceneManager.LoadScene("StartingScene", LoadSceneMode.Single);
    }
}
    
