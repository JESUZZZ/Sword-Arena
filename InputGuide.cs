using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGuide : MonoBehaviour
{
    public int player;
    public GameObject kb;
    public GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        kb.SetActive(true);
        controller.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == 1 && (Input.GetAxisRaw("JoyStick_Horizontal1") != 0 || Input.GetAxisRaw("JoyStick_Vertical1") != 0) && LevelControl.p1HP > 0 && LevelControl.p2HP > 0)
        {
            kb.SetActive(false);
            controller.SetActive(true);
        }
        else if (player == 2 && (Input.GetAxisRaw("JoyStick_Horizontal2") != 0 || Input.GetAxisRaw("JoyStick_Vertical2") != 0) && LevelControl.p1HP > 0 && LevelControl.p2HP > 0)
        {
            kb.SetActive(false);
            controller.SetActive(true);
        }
    }
}
