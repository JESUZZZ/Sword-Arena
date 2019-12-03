using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    private int currentPage;
    public GameObject control;
    public GameObject skill;
    public GameObject basicSkill;
    public GameObject match;
    public GameObject mode;
    public GameObject bullKnight;
    public GameObject arkaneWitch;
    public GameObject poopSplash;
    public GameObject gizmo;
    public GameObject shadow;
    public GameObject guardian;
    public GameObject paceBreaker;
    public GameObject rank;
    public Text charName;
    public GameObject toRankButton;
    public GameObject undoRankButton;
    // Start is called before the first frame update
    void Start()
    {
        currentPage = 1;
        control.SetActive(true);
        skill.SetActive(false);
        basicSkill.SetActive(false);
        match.SetActive(false);
        mode.SetActive(false);
        bullKnight.SetActive(false);
        arkaneWitch.SetActive(false);
        poopSplash.SetActive(false);
        gizmo.SetActive(false);
        shadow.SetActive(false);
        guardian.SetActive(false);
        paceBreaker.SetActive(false);
        charName.enabled = false;
        rank.SetActive(false);
        toRankButton.SetActive(false);
        undoRankButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void closeAll()
    {
        control.SetActive(false);
        skill.SetActive(false);
        basicSkill.SetActive(false);
        match.SetActive(false);
        mode.SetActive(false);
        bullKnight.SetActive(false);
        arkaneWitch.SetActive(false);
        poopSplash.SetActive(false);
        gizmo.SetActive(false);
        shadow.SetActive(false);
        guardian.SetActive(false);
        paceBreaker.SetActive(false);
        rank.SetActive(false);
        charName.enabled = false;
        toRankButton.SetActive(false);
        undoRankButton.SetActive(false);
    }

    public void toHome()
    {
        SceneManager.LoadScene("StartingScene");
    }

    public void toControl()
    {
        if(currentPage != 1)
        {
            currentPage = 1;
            closeAll();
            control.SetActive(true);
        }
    }

    public void toSkill()
    {
        if (currentPage != 2)
        {
            currentPage = 2;
            closeAll();
            skill.SetActive(true);
        }
    }

    public void toBasicSkill()
    {
        if (currentPage != 3)
        {
            currentPage = 3;
            closeAll();
            basicSkill.SetActive(true);
        }
    }

    public void toMatch()
    {
        if (currentPage != 4)
        {
            currentPage = 4;
            closeAll();
            match.SetActive(true);
        }
    }

    public void toMode()
    {
        if (currentPage != 5)
        {
            currentPage = 5;
            closeAll();
            mode.SetActive(true);
            toRankButton.SetActive(true);
        }
    }

    public void toBullKnight()
    {
        if (currentPage != 6)
        {
            currentPage = 6;
            closeAll();
            bullKnight.SetActive(true);
            charName.enabled = true;
            charName.text = "Bull Knight";
        }
    }

    public void toArkaneWitch()
    {
        if (currentPage != 7)
        {
            currentPage = 7;
            closeAll();
            arkaneWitch.SetActive(true);
            charName.enabled = true;
            charName.text = "Arkane Witch";
        }
    }

    public void toPoopsplash()
    {
        if (currentPage != 8)
        {
            currentPage = 8;
            closeAll();
            poopSplash.SetActive(true);
            charName.enabled = true;
            charName.text = "Poopsplash";
        }
    }

    public void toGizmo()
    {
        if (currentPage != 9)
        {
            currentPage = 9;
            closeAll();
            gizmo.SetActive(true);
            charName.enabled = true;
            charName.text = "Gizmo";
        }
    }

    public void toShadow()
    {
        if (currentPage != 10)
        {
            currentPage = 10;
            closeAll();
            shadow.SetActive(true);
            charName.enabled = true;
            charName.text = "Shadow";
        }
    }

    public void toGuardian()
    {
        if (currentPage != 11)
        {
            currentPage = 11;
            closeAll();
            guardian.SetActive(true);
            charName.enabled = true;
            charName.text = "Guardian";
        }
    }

    public void toPaceBreaker()
    {
        if (currentPage != 12)
        {
            currentPage = 12;
            closeAll();
            paceBreaker.SetActive(true);
            charName.enabled = true;
            charName.text = "Pace Breaker";
        }
    }

    public void toRank()
    {
        if (currentPage != 13)
        {
            currentPage = 13;
            closeAll();
            undoRankButton.SetActive(true);
            rank.SetActive(true);
        }
    }
}
