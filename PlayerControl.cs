using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float DashCooldown;
    public float ParryCooldown;
    public float AttackCooldown;
    //public float speedSetting;
    public static float speed;
    public static float speedCopy;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator anim;
    public float dashSpeed;
    public float lastAttackSpeed;
    private float lastAttackSpeedCopy;
    private bool canLastAttack;
    public float knockBack;
    private float knockBackCopy;
    public static float x_lastMove;
    public static float y_lastMove;
    private float x_move;
    private float y_move;
    private float x_knockBack;
    private float y_knockBack;
    public static bool canAttack;
    private bool canMove;
    public static bool canDash;
    public static bool canParry;
    private bool isKnockBack;
    private bool isFirstMove;
    private bool isCrash;
    private bool isLowSpeedParry;
    public static bool isImmortal;
    private int oneTime;
    private int oneTimeKnockBack;
    private int oneTimeBlink;
    private int oneTimeStun;
    private bool canDie;
    private bool canShake;
    public static bool whileDash;
    public static bool whileParry;
    public static bool whileAttack;
    public static bool isStun;
    public float slowMo;
    public GameObject dashUp;
    public GameObject dashDown;
    public GameObject dashLeft;
    public GameObject dashRight;
    public GameObject atkHB;
    public GameObject star;
    public Transform atkPos_right;
    public Transform atkPos_left;
    public Transform atkPos_down;
    public Transform atkPos_up;
    public Transform atkPos_upRight;
    public Transform atkPos_upLeft;
    public Transform atkPos_downRight;
    public Transform atkPos_downLeft;
    public Collider2D col;
    public Text dashCooldownUI;
    public Text parryCooldownUI;
    private Quaternion normalRotate;

    private int dashCount;
    private int parryCount;
    private int parryCheck;
    private int stunCount;


    public int character;
    

    public float Sk1Cooldown;
    public static bool canSK1;
    private int sk1_count;
    private bool whileSK1;

    public float Sk2Cooldown;
    public static bool canSK2;
    private int sk2_count;
    private bool whileSK2;

    //char02Ball
    public GameObject ballUp;
    public GameObject ballUpLeft;
    public GameObject ballLeft;
    public GameObject ballDownLeft;
    public GameObject ballDown;
    public GameObject ballDownRight;
    public GameObject ballRight;
    public GameObject ballUpRight;

    //char03trap
    public GameObject trap;
    public static int trapCount;
    public Transform otherPlayerPos;
    public float trapOffset;

    //char04Knife
    public GameObject knifeUp;
    public GameObject knifeUpRight;
    public GameObject knifeRight;
    public GameObject knifeDownRight;
    public GameObject knifeDown;
    public GameObject knifeDownLeft;
    public GameObject knifeLeft;
    public GameObject knifeUpLeft;
    public GameObject unParryAtkHb;


    //char05Shadow
    public GameObject shadowDown;
    public GameObject shadowLeft;
    public GameObject shadowRight;
    public GameObject shadowUp;
    public GameObject shadowFire;
    private GameObject shadowFireTemp;
    private Vector3 shadowFirePos;

    //char06Ball
    public GameObject stunBall;
    public GameObject lightningball;

    //char07Spike
    public GameObject spike;
    public float spikeOffsetXSetting;
    public float spikeOffsetYSetting;
    private float spikeOffsetX;
    private float spikeOffsetY;
    private Vector3 currentPos;
    public float speedWhileSlow;
    private float normalSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        Time.fixedDeltaTime = 0.02f;
        Time.timeScale = 1;
        canDash = false;
        canAttack = false;
        canParry = false;
        canMove = true;
        canShake = true;
        whileDash = false;
        whileParry = false;
        whileAttack = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        col.enabled = true;
        lastAttackSpeedCopy = lastAttackSpeed;
        canLastAttack = true;
        oneTime = 0;
        oneTimeKnockBack = 0;
        oneTimeBlink = 0;
        oneTimeStun = 0;
        canDie = true;
        //oneTimeFx = 0;
        isStun = false;
        isKnockBack = false;
        isFirstMove = true;
        isImmortal = false;
        isLowSpeedParry = false;
        x_lastMove = 1;
        y_lastMove = 0;
        x_move = 0;
        y_move = 0;
        speed = 350f;
        speedCopy = speed;
        knockBackCopy = knockBack;
        dashCooldownUI.enabled = false;
        parryCooldownUI.enabled = false;
        dashCount = 0;
        parryCount = 0;
        parryCheck = 0;
        stunCount = 0;
        canSK1 = false;
        canSK2 = false;
        whileSK1 = false;
        whileSK2 = false;
        normalRotate = transform.localRotation;
        star.SetActive(false);
        normalSpeed = speedCopy;

        StartCoroutine(RealStart());
    }

    // Update is called once per frame
    void Update()
    {
        if (isStun)
        {
            canMove = false;
            if (y_lastMove < -0.5f)
            {
                anim.SetFloat("x_lastMove", 0.0f);
                anim.SetFloat("y_lastMove", -1.0f);
            }
            else if (x_lastMove < -0.5f)
            {
                anim.SetFloat("x_lastMove", -1.0f);
                anim.SetFloat("y_lastMove", 0.0f);
            }
            else if (x_lastMove > 0.5f)
            {
                anim.SetFloat("x_lastMove", 1.0f);
                anim.SetFloat("y_lastMove", 0.0f);
            }
            else
            {
                anim.SetFloat("x_lastMove", 0.0f);
                anim.SetFloat("y_lastMove", 1.0f);
            }
            anim.SetBool("isStun", true);

            if (canShake)
            {
                star.SetActive(true);
                canShake = false;
                StartCoroutine(stunShake(0.1f, -1.5f));
                StartCoroutine(stunShake(0.2f, 1.5f));
                StartCoroutine(stunShake(0.3f, -1.5f));
                StartCoroutine(stunShake(0.4f, 1.5f));
                StartCoroutine(stunShake(0.5f, -1.5f));
                StartCoroutine(stunShake(0.6f, 1.5f));
                StartCoroutine(stunShake(0.7f, -1.5f));
                StartCoroutine(stunShake(0.8f, 1.5f));
                StartCoroutine(stunShake(0.9f, -1.5f));
                StartCoroutine(returnStunShake(1.5f));
            }
        }
        else if (!isStun)
        {
            star.SetActive(false);
            canShake = true;
            anim.SetBool("isStun", false);
        }

        if (canMove /*&& (LevelControl.p1HP >0&&LevelControl.p2HP>0)*/)
        {
            if (Input.GetAxisRaw("JoyStick_Horizontal1") != 0 || Input.GetAxisRaw("JoyStick_Vertical1") != 0)
            {
                x_move = Input.GetAxisRaw("JoyStick_Horizontal1");
                y_move = Input.GetAxisRaw("JoyStick_Vertical1");
                if(x_move < 0.4f && x_move > -0.4f)
                {
                    x_move = 0;
                }
                if(y_move < 0.4f && y_move > -0.4f)
                {
                    y_move = 0;
                }
            }
            else
            {
                x_move = Input.GetAxisRaw("Horizontal");
                y_move = Input.GetAxisRaw("Vertical");
            }
            anim.SetFloat("x_move", x_move);
            anim.SetFloat("y_move", y_move);
            if(!whileDash && !isLowSpeedParry && !isStun && !isKnockBack )
            {
                speed = speedCopy;
            }
        }
        else if (!canMove)
        {
            if (!whileDash && !isLowSpeedParry && !isStun && !isKnockBack && !whileAttack)
            {
                speed = 0;
            }
        }

        if ((x_move > 0.5f || x_move < -0.5f))
        {
            anim.SetBool("isMove", true);
            isFirstMove = false;
            //rb.velocity = new Vector2(x_move * speed * Time.deltaTime, rb.velocity.y);
            if (x_move > 0.5f)
            {
                anim.SetFloat("x_lastMove", 1.0f);
                x_lastMove = 1.0f;
                anim.SetFloat("y_lastMove", 0.0f);
                y_lastMove = 0.0f;

            }
            else if (x_move < -0.5)
            {
                anim.SetFloat("x_lastMove", -1.0f);
                x_lastMove = -1.0f;
                anim.SetFloat("y_lastMove", 0.0f);
                y_lastMove = 0.0f;
            }
        }
        if ((y_move > 0.5f || y_move < -0.5f))
        {
            anim.SetBool("isMove", true);
            isFirstMove = false;
            //rb.velocity = new Vector2(rb.velocity.x, y_move * speed * Time.deltaTime);
            if (y_move > 0.5f)
            {
                anim.SetFloat("x_lastMove", 0f);
                x_lastMove = 0f;
                anim.SetFloat("y_lastMove", 1.0f);
                y_lastMove = 1.0f;

            }
            else if (y_move < -0.5f)
            {
                anim.SetFloat("x_lastMove", 0f);
                x_lastMove = 0f;
                anim.SetFloat("y_lastMove", -1.0f);
                y_lastMove = -1.0f;
            }

        }

        if (x_move == 0 && y_move == 0)
        {
            anim.SetBool("isMove", false);
            //oneTimeFx = 0;
        }
        /*if (x_move == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (y_move == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }*/
        if ((x_move < -0.5f && y_move > 0.5f) || (x_move < -0.5f && y_move < -0.5f) || (y_move < -0.5f && x_move > 0.5f) || (x_move > 0.5f && y_move > 0.5f))
        {
            //rb.velocity = new Vector2(rb.velocity.x / 1.5f, rb.velocity.y / 1.5f);
            if (x_move > 0.5f && y_move > 0.5f)
            {
                x_lastMove = 1;
                y_lastMove = 1;
                anim.SetFloat("x_lastMove", 1.0f);
                anim.SetFloat("y_lastMove", 1.0f);
            }
            if (x_move < -0.5f && y_move > 0.5f)
            {
                x_lastMove = -1;
                y_lastMove = 1;
                anim.SetFloat("x_lastMove", -1.0f);
                anim.SetFloat("y_lastMove", 1.0f);
            }
            if (x_move > 0.5f && y_move < -0.5f)
            {
                x_lastMove = 1;
                y_lastMove = -1;
                anim.SetFloat("x_lastMove", 1.0f);
                anim.SetFloat("y_lastMove", -1.0f);
            }
            if (x_move < -0.5f && y_move < -0.5f)
            {
                x_lastMove = -1;
                y_lastMove = -1;
                anim.SetFloat("x_lastMove", -1.0f);
                anim.SetFloat("y_lastMove", -1.0f);
            }
        }
        if (x_move == 0 && y_move < -0.5)
        {
            x_lastMove = 0;
            y_lastMove = -1;
            anim.SetFloat("x_lastMove", 0.0f);
            anim.SetFloat("y_lastMove", -1.0f);
        }


        if ((Input.GetKeyDown(KeyCode.G)||Input.GetButton("JoyStick_A1")) && canDash && !isStun && (x_move != 0 || y_move != 0) && !whileDash && !isLowSpeedParry && !whileAttack && !isKnockBack && !whileSK1 && !whileSK2)
        {
            dashCount++;
            dashCooldownUI.enabled = true;
            whileDash = true;
            speed = speedCopy * dashSpeed;
            canDash = false;
            //rb.velocity = new Vector2(x_lastMove * speed * Time.deltaTime, y_lastMove * speed * Time.deltaTime);
            anim.SetBool("isDash", true);
            canMove = false;
            StartCoroutine(returnSpeed());
            StartCoroutine(dashCooldown());
        }

        if(whileDash && character == 5 && whileSK1)
        {
            if (y_lastMove < -0.5f)
            {
                Instantiate(shadowDown, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (x_lastMove < -0.5f)
            {
                Instantiate(shadowLeft, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (x_lastMove > 0.5f)
            {
                Instantiate(shadowRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(shadowUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }
        else if (whileDash)
        {
            if(y_lastMove<-0.5f)
            {
                Instantiate(dashDown, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (x_lastMove < -0.5f)
            {
                Instantiate(dashLeft,new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else if (x_lastMove > 0.5f)
            {
                Instantiate(dashRight, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else
            {
                Instantiate(dashUp, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
        }

        if ((Input.GetKeyDown(KeyCode.H)|| Input.GetButton("JoyStick_X1")) && canAttack && !isStun && !whileDash && !isLowSpeedParry && !isKnockBack && !whileSK1 && !whileSK2)
        {
            whileAttack = true;
            canAttack = false;
            canMove = false;

            if ((x_move == 0 && y_move == 0) && (isFirstMove))
            {
                anim.SetBool("isAttackFromFirstIdle", true);
                Instantiate(atkHB, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
            }
            else if ((x_move == 0 && y_move == 0) && (x_lastMove != 0 || y_lastMove != 0))
            {
                anim.SetBool("isAttackFromIdle", true);
                if (x_lastMove > 0.5 && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5 && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove > 0.5)
                {
                    Instantiate(atkHB, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove < - 0.5)
                {
                    Instantiate(atkHB, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                }

            }
            else
            {
                anim.SetBool("isAttack", true);

                if (x_lastMove > 0.5f && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
                }
            }
            StartCoroutine(returnAttack());
            StartCoroutine(attackCooldown());
        }
        else if ((Input.GetKeyDown(KeyCode.H) || Input.GetButton("JoyStick_X1")) && canAttack && !isStun && !whileDash && !isLowSpeedParry && !isKnockBack && !whileSK1 && whileSK2 && (character == 4||character == 7))
        {
            whileAttack = true;
            canAttack = false;
            canMove = false;

            if ((x_move == 0 && y_move == 0) && (isFirstMove))
            {
                anim.SetBool("isAttackFromFirstIdle", true);
                Instantiate(unParryAtkHb, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
            }
            else if ((x_move == 0 && y_move == 0) && (x_lastMove != 0 || y_lastMove != 0))
            {
                anim.SetBool("isAttackFromIdle", true);
                if (x_lastMove > 0.5 && y_lastMove == 0)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5 && y_lastMove == 0)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove > 0.5)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove < -0.5)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                }

            }
            else
            {
                anim.SetBool("isAttack", true);

                if (x_lastMove > 0.5f && y_lastMove == 0)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove == 0)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove > 0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove < -0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(unParryAtkHb, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
                }
            }
            StartCoroutine(returnAttack());
            StartCoroutine(attackCooldown());
        }

        if ((Input.GetKeyDown(KeyCode.J)||Input.GetButton("JoyStick_Y1")) && canParry && !isStun && !whileDash && !whileAttack &&!isKnockBack && !whileSK1 && !whileSK2)
        {
            parryCount++;
            parryCheck++;
            parryCooldownUI.enabled = true;
            isLowSpeedParry = true;
            speed = speedCopy / 5;
            canParry = false;
            whileParry = true;
            if (isFirstMove)
            {
                anim.SetBool("isParryFromFirstIdle", true);
            }
            else if (x_lastMove != 0 || y_lastMove != 0)
            {
                anim.SetBool("isParry", true);
            }
            StartCoroutine(parryCooldown());
            StartCoroutine(returnParry());

        }

        if (whileParry && PlayerControl2.isStun)
        {
            whileParry = false;
            anim.SetBool("isParryFromFirstIdle", false);
            anim.SetBool("isParry", false);
            isLowSpeedParry = false;
            speed = speedCopy;
            canAttack = true;
            if (dashCooldownUI.enabled)
            {
                canDash = false;
            }
            else
            {
                canDash = true;
            }
            parryCheck++;
        }


        //====================================================character01================================================================//
        if (character == 1)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2)
            {
                whileSK1 = true;
                sk1_count++;
                canSK1 = false;
                anim.SetBool("isWhirlwind", true);
                StartCoroutine(sk1Cooldown());
                StartCoroutine(returnSk1());
                StartCoroutine(sk1SpawnHB(0.08f, atkPos_downRight.localPosition));
                StartCoroutine(sk1SpawnHB(0.16f, atkPos_down.localPosition));
                StartCoroutine(sk1SpawnHB(0.24f, atkPos_downLeft.localPosition));
                StartCoroutine(sk1SpawnHB(0.32f, atkPos_left.localPosition));
                StartCoroutine(sk1SpawnHB(0.40f, atkPos_upLeft.localPosition));
                StartCoroutine(sk1SpawnHB(0.48f, atkPos_up.localPosition));
                StartCoroutine(sk1SpawnHB(0.56f, atkPos_upRight.localPosition));
                StartCoroutine(sk1SpawnHB(0.64f, atkPos_right.localPosition));
            }
            if (anim.GetBool("isWhirlwind"))
            {
                if (isStun || isKnockBack)
                {
                    anim.SetBool("isWhirlwind", false);
                    whileSK1 = false;
                }
            }

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2)
            {
                sk2_count++;
                canSK2 = false;
                canSK1 = true;
            }
        }
        //====================================================character01================================================================//


        //====================================================character02================================================================//
        else if (character == 2)
        {
            //float blink;
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2 && (x_move != 0 || y_move != 0))
            {
                canMove = false;
                canSK1 = false;
                whileSK1 = true;
                anim.SetInteger("sk1State", 1);
                StartCoroutine(appear());
                StartCoroutine(blinkCooldown());
                canMove = true;
            }
            if ((anim.GetInteger("sk1State") == 1 || anim.GetInteger("sk1State") == 2) && (isStun || isKnockBack))
            {
                whileSK1 = false;
                anim.SetInteger("sk1State", 3);
            }
            /*if (anim.GetInteger("sk1State") == 2)
            {
                blink = 4.0f;
                if (x_lastMove != 0 && y_lastMove != 0)
                {
                    float blinkCopy = blink;
                    blink = blinkCopy / 1.5f;
                }
                //rb.AddForce(new Vector3(x_lastMove * blink * Time.deltaTime, y_lastMove * blink * Time.deltaTime, 0.0f), ForceMode2D.Force);
                StartCoroutine(returnBlink(blink));
            }*/

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                whileSK2 = true;
                canSK2 = false;
                canMove = false;
                anim.SetBool("isSk2", true);
                StartCoroutine(sk2Cooldown());
                StartCoroutine(returnSk2());
                Instantiate(ballUp, transform.localPosition + atkPos_up.localPosition, Quaternion.identity);
                Instantiate(ballUpLeft, transform.localPosition + atkPos_upLeft.localPosition, Quaternion.identity);
                Instantiate(ballLeft, transform.localPosition + atkPos_left.localPosition, Quaternion.identity);
                Instantiate(ballDownLeft, transform.localPosition + atkPos_downLeft.localPosition, Quaternion.identity);
                Instantiate(ballDown, transform.localPosition + atkPos_down.localPosition, Quaternion.identity);
                Instantiate(ballDownRight, transform.localPosition + atkPos_downRight.localPosition, Quaternion.identity);
                Instantiate(ballRight, transform.localPosition + atkPos_right.localPosition, Quaternion.identity);
                Instantiate(ballUpRight, transform.localPosition + atkPos_upRight.localPosition, Quaternion.identity);
            }

            if (anim.GetBool("isSk2"))
            {
                if (isStun || isKnockBack)
                {
                    anim.SetBool("isSk2", false);
                    whileSK2 = false;
                }
            }
        }
        //====================================================character02================================================================//


        //====================================================character03================================================================//
        else if (character == 3)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2)
            {
                canSK1 = false;
                anim.SetBool("isPlaceTrap", true);
                canMove = false;
                whileSK1 = true;
                StartCoroutine(returnPlaceTrap());
                StartCoroutine(placeTrapCooldown());
            }

            if (anim.GetBool("isPlaceTrap") && (isKnockBack || isStun))
            {
                whileSK1 = false;
                anim.SetBool("isPlaceTrap", false);
            }
            //Debug.Log(trapCount);
            if (trapCount > 3)
            {
                trapCount = 3;
            }

            if (trapCount == 3)
            {
                canSK2 = true;
                StartCoroutine(returnSk2Trigger());
            }

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                trapCount = 0;
                sk2_count++;
                canSK2 = false;
                whileSK2 = true;
                canMove = false;
                anim.SetBool("isDance", true);
                Instantiate(atkHB, otherPlayerPos.localPosition, Quaternion.identity);
                StartCoroutine(returnDance());
            }
            if (anim.GetBool("isDance") && (isKnockBack || isStun))
            {
                whileSK2 = false;
                sk2_count++;
                anim.SetBool("isDance", false);
                if (isStun)
                {
                    anim.SetBool("isStun", true);
                }
            }
        }
        //====================================================character03================================================================//


        //====================================================character04================================================================//
        else if (character == 4)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2)
            {
                canSK1 = false;
                whileSK1 = true;
                canMove = false;
                anim.SetBool("isSk", true);
                StartCoroutine(returnThrowKnife());
                StartCoroutine(knifeOut());
                StartCoroutine(throwKnifeCooldown());

            }

            if (anim.GetBool("isSk") && isKnockBack)
            {
                whileSK1 = false;
                anim.SetBool("isSk", false);
            }

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                isImmortal = true;
                canSK2 = false;
                whileSK2 = true;
                StartCoroutine(speedyAtk());
                StartCoroutine(speedyAtkCooldown());
                transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                sr.color = new Color(1f, 0.7f, 0.7f, 1f);
            }

        }
        //====================================================character04================================================================//


        //====================================================character05================================================================//

        else if (character == 5)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2 && (x_move != 0 || y_move != 0))
            {
                canSK1 = false;
                whileSK1 = true;
                canMove = false;
                anim.SetBool("isStrikePrepare", true);
                StartCoroutine(strike());
                StartCoroutine(strikeCooldown());
            }

            if (anim.GetBool("isStrikePrepare") && isKnockBack)
            {
                anim.SetBool("isStrikePrepare", false);
                whileSK1 = false;
                if (LevelControl.p1HP > 4)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (LevelControl.p2HP <= 4)
                {
                    sr.color = new Color(1f, 0.7f, 0.71f, 1f);
                }
            }

            if (anim.GetBool("isStrike") && isStun)
            {
                whileDash = false;
                whileSK1 = false;
                anim.SetBool("isStrike", false);
                anim.SetBool("isStun", true);
                if (LevelControl.p1HP > 4)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (LevelControl.p2HP <= 4)
                {
                    sr.color = new Color(1f, 0.7f, 0.7f, 1f);
                }
            }
            else if (anim.GetBool("isStrike") && !isStun)
            {
                if (x_lastMove > 0.5f && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove == 0)
                {
                    Instantiate(atkHB, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                }
                else if (x_lastMove == 0 && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove > 0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove > 0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
                }
                else if (x_lastMove < -0.5f && y_lastMove < -0.5f)
                {
                    Instantiate(atkHB, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
                }
            }
            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                //transform.localPosition = shadowFirePos;
                sr.color = new Color(0.2f, 0.2f, 0.2f, 1f);
                canMove = false;
                canSK2 = false;
                whileSK2 = true;
                anim.SetBool("isDisappear", true);
                StartCoroutine(warpDisappear());
            }
            if ((anim.GetBool("isAppear") || anim.GetBool("isDisappear")) && isKnockBack)
            {
                canMove = true;
                anim.SetBool("isDisappear", false);
                anim.SetBool("isAppear", false);
                whileSK2 = false;
                Destroy(shadowFireTemp);
                if (LevelControl.p1HP > 4)
                {
                    sr.color = new Color(1f, 1f, 1f, 1f);
                }
                else if (LevelControl.p2HP <= 4)
                {
                    sr.color = new Color(1f, 0.7f, 0.7f, 1f);
                }
            }
        }
        //====================================================character05================================================================//


        //====================================================character06================================================================//

        else if (character == 6)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2)
            {
                canMove = false;
                canSK1 = false;
                whileSK1 = true;
                anim.SetBool("isSk1", true);
                StartCoroutine(returnStunBall());
                StartCoroutine(spawnStunBall());
                StartCoroutine(stunBallCooldown());
            }

            if (anim.GetBool("isSk1") && isKnockBack)
            {
                whileSK1 = false;
                anim.SetBool("isSk1", false);
            }

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                canMove = false;
                canSK2 = false;
                whileSK2 = true;
                sk2_count = 0;
                anim.SetBool("isSk2", true);
                StartCoroutine(goDown());
                StartCoroutine(startSpawnLightningBall());
                StartCoroutine(lightningBallCooldown());
            }

            if ((anim.GetBool("isSk1") || anim.GetBool("isSk2")) && isKnockBack)
            {
                whileSK2 = false;
                anim.SetBool("isSk2", false);
                anim.SetBool("isGoDown", false);
            }
        }
        //====================================================character06================================================================//


        //====================================================character07================================================================//

        else if (character == 7)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2 && (x_move != 0 || y_move != 0))
            {
                canSK1 = false;
                canMove = false;
                whileSK1 = true;
                sk1_count = 1;
                anim.SetBool("isSk1", true);
                currentPos = transform.localPosition;
                if (x_lastMove != 0 && y_lastMove != 0)
                {
                    spikeOffsetX = (spikeOffsetXSetting * x_lastMove) / 1.5f;
                    spikeOffsetY = (spikeOffsetYSetting * y_lastMove) / 1.5f;
                }
                else
                {
                    spikeOffsetX = spikeOffsetXSetting * x_lastMove;
                    spikeOffsetY = spikeOffsetYSetting * y_lastMove;
                }
                StartCoroutine(returnSpawnSpike());
                StartCoroutine(startSpawnSpike());
                StartCoroutine(spikeCooldown());
            }

            if (anim.GetBool("isSk1") && isKnockBack)
            {
                whileSK1 = false;
                anim.SetBool("isSk1", false);
            }

            if ((Input.GetKeyDown(KeyCode.U) || Input.GetButton("JoyStick_RB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK2 && !whileSK1)
            {
                canSK2 = false;
                canMove = false;
                whileSK2 = true;
                anim.SetBool("isSk2", true);
                StartCoroutine(startSlowDown());
                StartCoroutine(slowDownCooldown());
            }

            if (whileSK2 && isKnockBack)
            {
                whileSK2 = false;
                anim.SetBool("isSk2", false);
            }

            if(Time.timeScale != 1 && LevelControl.p1HP > 0)
            {
                speedCopy = speedWhileSlow;
            }
            else
            {
                speedCopy = normalSpeed;
            }
        }
        //====================================================character07================================================================//


        if ((AtkHB.isCounter || (Char03Trap.playerNum == 2 && Char03Trap.stun) || (Char06StunBall.isStun && Char06StunBall.playerNum == 2)) && oneTimeStun<1)
        {
            oneTimeStun++;
            stunCount++;
            StartCoroutine(returnCounter());
        }


        if (AtkHB2.isHit || AtkHB2_range.isHit)
        {
            isKnockBack = true;
            dashCooldownUI.enabled = false;
            parryCooldownUI.enabled = false;
        }

        if (isKnockBack && oneTimeKnockBack < 1)
        {
            oneTimeKnockBack++;
            x_knockBack = PlayerControl2.x_lastMove;
            y_knockBack = PlayerControl2.y_lastMove;
        }

        if (isKnockBack && LevelControl.p1HP > 0)
        {
            star.SetActive(false);
            transform.localRotation = normalRotate;
            canMove = false;
            dashCount++;
            parryCount++;
            parryCheck++;
            stunCount++;
            knockBack = knockBackCopy;
            if(character == 7)
            {
                speedCopy = normalSpeed;
            }
            speed = speedCopy;
            isLowSpeedParry = false;
            isStun = false;
            oneTimeStun = 0;
            whileDash = false;
            if ((PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove > 0.5f) || (PlayerControl2.x_lastMove < -0.5f && PlayerControl2.y_lastMove < -0.5f) || (PlayerControl2.y_lastMove < -0.5f && PlayerControl2.x_lastMove > 0.5f) || (PlayerControl2.x_lastMove > 0.5f && PlayerControl2.y_lastMove > 0.5f))
            {
                knockBack = knockBackCopy / 1.5f;
            }
            //rb.velocity = new Vector2(x_knockBack * speed * knockBack * Time.deltaTime, y_knockBack * speed * knockBack * Time.deltaTime);
            StartCoroutine(returnKnockback());
        }

        if (!isImmortal)
        {
            sr.enabled = true;
            oneTimeBlink = 0;
        }
        else if (isImmortal && oneTimeBlink < 1 && LevelControl.p1HP > 0)
        {
            oneTimeBlink++;
            StartCoroutine(returnImmortal());
            StartCoroutine(rendererDisapppear(0.125f));
            StartCoroutine(rendererApppear(0.250f));
            StartCoroutine(rendererDisapppear(0.375f));
            StartCoroutine(rendererApppear(0.500f));
            StartCoroutine(rendererDisapppear(0.625f));
            StartCoroutine(rendererApppear(0.750f));
            StartCoroutine(rendererDisapppear(0.875f));
        }

        //Debug.Log("p1 " + isImmortal);
        if (LevelControl.p1HP < 5)
        {
            sr.color = new Color(1f, 0.7f, 0.7f, 1f);
        }

        if ((LevelControl.p1HP <= 0 || LevelControl.p2HP <= 0) && oneTime < 1)
        {
            Time.fixedDeltaTime = 0.02f;
            Time.timeScale = 1;
            sr.color = new Color(1f, 1f, 1f, 1f);
            canAttack = false;
            canDash = false;
            canParry = false;
            canMove = false;
            canSK1 = false;
            canSK2 = false;
            x_move = 0;
            y_move = 0;
            star.SetActive(false);

            if (LevelControl.p2HP <= 0 && LevelControl.p1HP > 0 && !LevelControl.winByBoom && whileAttack)
            {
                if ((x_lastMove == 1 && y_lastMove == 1) || (x_lastMove == -1 && y_lastMove == 1) || (x_lastMove == -1 && y_lastMove == -1) || (x_lastMove == 1 && y_lastMove == -1))
                {
                    lastAttackSpeed = lastAttackSpeedCopy / 1.75f;
                }
                //rb.AddForce(new Vector2(x_lastMove * lastAttackSpeed * Time.deltaTime, y_lastMove * lastAttackSpeed * Time.deltaTime), ForceMode2D.Impulse);
                if (canLastAttack)
                {
                    anim.SetBool("isAttack", true);
                    canLastAttack = false;
                }
            }
            else if (LevelControl.p1HP <= 0 && LevelControl.p2HP > 0)
            {
                col.enabled = false;
                canMove = false;
            }
            else if (LevelControl.p1HP <= 0 && LevelControl.p2HP <= 0)
            {
                canMove = false;
            }
            StartCoroutine(reduceTime());
            StartCoroutine(returnTime());
            StartCoroutine(returnLastAttack());
        }

        if (LevelControl.p1HP <= 0 && canDie)
        {
            canDie = false;
            sr.color = new Color(1f, 1f, 1f, 1f);
            StartCoroutine(die(0.05f));
        }

    }

    private void FixedUpdate()
    {
        /*Debug.Log("x_move = " + rb.velocity.x);
        Debug.Log("y_move = " + rb.velocity.y);*/
        if ((x_move > 0.5f || x_move < -0.5f))
        {
            rb.velocity = new Vector2(x_move * speed * Time.deltaTime, rb.velocity.y);
        }
        if ((y_move > 0.5f || y_move < -0.5f))
        {
            rb.velocity = new Vector2(rb.velocity.x, y_move * speed * Time.deltaTime);
        }
        if (x_move == 0)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (y_move == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
        }
        if (((x_move < -0.5f && y_move > 0.5f) || (x_move < -0.5f && y_move < -0.5f) || (y_move < -0.5f && x_move > 0.5f) || (x_move > 0.5f && y_move > 0.5f)) && (Input.GetAxisRaw("JoyStick_Horizontal1") == 0 || Input.GetAxisRaw("JoyStick_Vertical1") == 0))
        {
            rb.velocity = new Vector2(rb.velocity.x / 1.5f, rb.velocity.y / 1.5f);
        }
        if ((Input.GetKeyDown(KeyCode.G) || Input.GetButton("JoyStick_A1")) && canDash && !isStun && (x_move != 0 || y_move != 0) && !whileDash && !isLowSpeedParry && !whileAttack && !isKnockBack && !whileSK1 && !whileSK2)
        {
            rb.velocity = new Vector2(x_lastMove * speed * Time.deltaTime, y_lastMove * speed * Time.deltaTime);
        }

        if (character == 2)
        {
            float blink;
            if (anim.GetInteger("sk1State") == 2)
            {
                if (anim.GetInteger("sk1State") == 2)
                {
                    blink = 4.0f;
                    if (x_lastMove != 0 && y_lastMove != 0)
                    {
                        float blinkCopy = blink;
                        blink = blinkCopy / 1.5f;
                    }
                    rb.AddForce(new Vector3(x_lastMove * blink * Time.deltaTime, y_lastMove * blink * Time.deltaTime, 0.0f), ForceMode2D.Force);
                    StartCoroutine(returnBlink(blink));
                }
            }
        }
        else if (character == 5)
        {
            if ((Input.GetKeyDown(KeyCode.Y) || Input.GetButton("JoyStick_LB1")) && !whileAttack && !whileDash && !isLowSpeedParry && !isKnockBack && !isStun && canSK1 && !whileSK2 && (x_move != 0 || y_move != 0))
            {
                StartCoroutine(strikePhx());
            }
        }

        if (isKnockBack && LevelControl.p1HP > 0)
        {
            rb.velocity = new Vector2(x_knockBack * speed * knockBack * Time.deltaTime, y_knockBack * speed * knockBack * Time.deltaTime);
        }
        if ((LevelControl.p1HP <= 0 || LevelControl.p2HP <= 0) && oneTime < 1)
        {
            if (LevelControl.p2HP <= 0 && LevelControl.p1HP > 0 && !LevelControl.winByBoom && whileAttack)
            {
                rb.AddForce(new Vector2(x_lastMove * lastAttackSpeed * Time.deltaTime, y_lastMove * lastAttackSpeed * Time.deltaTime), ForceMode2D.Impulse);
            }
        }
    }

    IEnumerator stunShake(float delay,float amount)
    {
        int hp = LevelControl.p1HP;
        yield return new WaitForSeconds(delay);
        if(hp == LevelControl.p1HP)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, amount);
        }

    }
    IEnumerator returnStunShake(float delay)
    {
        int hp = LevelControl.p1HP;
        yield return new WaitForSeconds(delay);
        if (hp == LevelControl.p1HP)
        {
            transform.localRotation = normalRotate;
        }

    }

    IEnumerator returnSpeed()
    {
        int dashCountTemp = dashCount;
        yield return new WaitForSeconds(0.1f);
        if (dashCountTemp == dashCount)
        {
            if (!isLowSpeedParry)
            {
                speed = speedCopy;
            }
            whileDash = false;
            if (!whileAttack && !isKnockBack && !isStun && !whileParry && !whileSK1 && !whileSK2)
            {
                canMove = true;
            }
            anim.SetBool("isDash", false);
        }
    }
    IEnumerator dashCooldown()
    {
        int dashCountTemp = dashCount;
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(DashCooldown);
            if (dashCountTemp == dashCount)
            {
                canDash = true;
                dashCooldownUI.enabled = false;
            }
                
        }
        else if(LevelControl.p1HP<=4)
        {
            yield return new WaitForSeconds(DashCooldown/2.0f);
            if (dashCountTemp == dashCount)
            {
                canDash = true;
                dashCooldownUI.enabled = false;
            }
            
        }
    }
    IEnumerator returnAttack()
    {
        yield return new WaitForSeconds(0.1f);
        if (LevelControl.p2HP > 0)
        {
            whileAttack = false;
            anim.SetBool("isAttack", false);
            anim.SetBool("isAttackFromIdle", false);
            anim.SetBool("isAttackFromFirstIdle", false);
            if (!whileParry && !whileDash && !isKnockBack && !isStun && !whileSK1 && !whileSK2)
            {
                canMove = true;
            }
            else if (!whileParry && !whileDash && !isKnockBack && !isStun && !whileSK1 && whileSK2 && (character == 4 || character == 7))
            {
                canMove = true;
            }
        }
    }

    IEnumerator attackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        if (!isLowSpeedParry)
        {
            canAttack = true;
        }
    }
    IEnumerator returnParry()
    {
        int parryCheckTemp = parryCheck;
        yield return new WaitForSeconds(1.5f);
        if (parryCheckTemp == parryCheck)
        {
            whileParry = false;
            anim.SetBool("isParryFromFirstIdle", false);
            anim.SetBool("isParry", false);
            StartCoroutine(returnSpeedParry());
        }
        
    }
    IEnumerator returnSpeedParry()
    {
        int parryCountTemp = parryCount;
        yield return new WaitForSeconds(2.5f);
        if (parryCountTemp == parryCount)
        {
            isLowSpeedParry = false;
            if (!isLowSpeedParry)
            {
                speed = speedCopy;
            }
        }
    }
    IEnumerator parryCooldown()
    {
        int parryCountTemp = parryCount;
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(ParryCooldown);
            if (parryCountTemp == parryCount)
            {
                canParry = true;
                parryCooldownUI.enabled = false;
            }
                
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(ParryCooldown/2.0f);
            if (parryCountTemp == parryCount)
            {
                canParry = true;
                parryCooldownUI.enabled = false;
            }
             
        }
    }
    IEnumerator returnCounter()
    {
        int stunCountTemp = stunCount;
        yield return new WaitForSeconds(4.0f);
        if (stunCount == stunCountTemp)
        {
            if (!isLowSpeedParry)
            {
                speed = speedCopy;
            }
            isStun = false;
            if (!whileAttack && !isKnockBack && !whileDash && !whileSK1 && !whileSK2 &&!isStun)
            {
                canMove = true;
            }
            oneTimeStun = 0;
        }
    }
        
    
    IEnumerator returnTime()
    {
        yield return new WaitForSecondsRealtime(2.0f);
        Time.timeScale = 1;
        StartCoroutine(winAct());
        canMove = false;
        canDash = false;
        canParry = false;
        canSK1 = false;
        canSK2 = false;
        if (dashCooldownUI.enabled)
        {
            dashCooldownUI.enabled = false;
        }
        if (parryCooldownUI.enabled)
        {
            parryCooldownUI.enabled = false;
        }
        oneTime++;
    }
    IEnumerator returnLastAttack()
    {
        yield return new WaitForSeconds(0.2f);
        if (anim.GetBool("isAttack"))
        {
            anim.SetBool("isAttack", false);
        }
    }
    IEnumerator winAct()
    {
        yield return new WaitForSeconds(2.0f);
        anim.SetBool("isWin", true);
    }
    IEnumerator reduceTime()
    {
        yield return new WaitForSecondsRealtime(0.19f);
        Time.timeScale = slowMo;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    IEnumerator returnKnockback()
    {
        yield return new WaitForSeconds(0.1f);
        oneTimeKnockBack = 0;
        isKnockBack = false;
        knockBack = 0;
        canMove = true;
        canAttack = true;
        canDash = true;
        canParry = true;
    }
    IEnumerator returnImmortal()
    {
        yield return new WaitForSeconds(1.0f);
        isImmortal = false;
    }
    IEnumerator rendererDisapppear(float second)
    {
        yield return new WaitForSeconds(second);
        sr.enabled = false;
    }
    IEnumerator rendererApppear(float second)
    {
        yield return new WaitForSeconds(second);
        sr.enabled = true;
    }

    IEnumerator die(float delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetBool("isDie",true);
        StartCoroutine(returnDie(0.75f));
    }
    IEnumerator returnDie(float delay)
    {
        yield return new WaitForSeconds(delay);
        sr.enabled = false;
    }

    IEnumerator RealStart()
    {
        yield return new WaitForSeconds(10.0f);
        canDash = true;
        canAttack = true;
        canParry = true;

        if (character == 1)
        {
            canSK1 = true;
            sk1_count = 0;
            sk2_count = 0;
            canSK2 = false;
        }
        else if (character == 2)
        {
            canSK1 = true;
            canSK2 = true;
        }
        else if (character == 3)
        {
            canSK1 = true;
            canSK2 = false;
            sk2_count = 0;
            trapCount = 0;
        }
        else if (character == 4)
        {
            canSK1 = true;
            canSK2 = true;
        }
        else if (character == 5)
        {
            canSK1 = true;
            canSK2 = false;
        }
        else if (character == 6)
        {
            canSK1 = true;
            canSK2 = true;
            sk2_count = 0;
        }
        else if (character == 7)
        {
            canSK1 = true;
            canSK2 = true;
            sk1_count = 1;
        }
    }

    //====================================================character01================================================================//
    IEnumerator returnSk1()
    {
        int p2HP = LevelControl.p2HP;
        yield return new WaitForSeconds(0.67f);
        if (anim.GetBool("isWhirlwind"))
        {
            whileSK1 = false;
            anim.SetBool("isWhirlwind", false);
            if (p2HP > LevelControl.p2HP)
            {
                canSK2 = true;
                StartCoroutine(sk2Triggered());
            }
        }
    }
    IEnumerator sk1SpawnHB(float second , Vector3 pos)
    {
        yield return new WaitForSeconds(second);
        if (anim.GetBool("isWhirlwind"))
        {
            Instantiate(atkHB, new Vector3(transform.position.x + pos.x, transform.position.y + pos.y, pos.z), Quaternion.identity);
        }
    }
    IEnumerator sk1Cooldown()
    {
        int sk1_CountTemp = sk1_count;
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            if (sk1_count == sk1_CountTemp)
            {
                canSK1 = true;
            }
        }
        else if (LevelControl.p1HP <=4)
        {
            yield return new WaitForSeconds(Sk1Cooldown / 2.0f);
            if (sk1_count == sk1_CountTemp)
            {
                canSK1 = true;
            }
        }
        
    }
    IEnumerator sk2Triggered()
    {
        int sk2_countTemp = sk2_count;
        yield return new WaitForSeconds(2.0f);
        if (sk2_countTemp == sk2_count)
        {
            canSK2 = false;
        }
    }
    //====================================================character01================================================================//


    //====================================================character02================================================================//
    IEnumerator appear()
    {
        StartCoroutine(rendererDisapppear(0.34f));
        StartCoroutine(rendererApppear(0.67f));
        yield return new WaitForSeconds(0.67f);
        if (anim.GetInteger("sk1State") != 3)
        { 
            sr.enabled = false;
            anim.SetInteger("sk1State", 2);
            sr.enabled = true;
        }
        StartCoroutine(returnToIdle());
    }
    IEnumerator returnToIdle()
    {
        yield return new WaitForSeconds(0.34f);
        if (anim.GetInteger("sk1State") != 3)
        {
            anim.SetInteger("sk1State", 3);
            whileSK1 = false;
        }
    }
    IEnumerator returnBlink(float val)
    {
        yield return new WaitForSeconds(0.1f);
        val = 0.0f;
    }
    IEnumerator blinkCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown);
            canSK1 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown / 2.0f);
            canSK1 = true;
        }
    }

    IEnumerator returnSk2()
    {
        int hp = LevelControl.p1HP;
        yield return new WaitForSeconds(1.5f);
        if (hp == LevelControl.p1HP)
        {
            anim.SetBool("isSk2", false);
            if (!isStun && !whileAttack && !whileDash && !isKnockBack && !whileSK1)
            {
                canMove = true;
                whileSK2 = false;
            }
        }
    }
    IEnumerator sk2Cooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown);
            canSK2 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown/2.0f);
            canSK2 = true;
        }
    }

    //====================================================character02================================================================//


    //====================================================character03================================================================//

    IEnumerator returnPlaceTrap()
    {
        int p1HP = LevelControl.p1HP;
        yield return new WaitForSeconds(0.8f);
        if (p1HP == LevelControl.p1HP && !isStun && !whileAttack && !whileDash && !isKnockBack && !whileSK2)
        {
            anim.SetBool("isPlaceTrap", false);
            whileSK1 = false;
            canMove = true;
            Instantiate(trap, new Vector3(transform.position.x, transform.position.y + trapOffset, transform.position.z), Quaternion.identity);
        }
    }

    IEnumerator placeTrapCooldown()
    {
        if(LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            canSK1 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown/2.0f);
            canSK1 = true;
        }
    }
    IEnumerator returnSk2Trigger()
    {
        int sk2_countTemp = sk2_count;
        yield return new WaitForSeconds(3.0f);
        if(sk2_countTemp == sk2_count)
        {
            canSK2 = false;
            trapCount = 0;
        }
    }
    IEnumerator returnDance()
    {
        int sk2_countTemp = sk2_count;
        yield return new WaitForSeconds(0.5f);
        if (sk2_countTemp == sk2_count && !isStun && !whileAttack && !whileDash && !isKnockBack && !whileSK1)
        {
            anim.SetBool("isDance", false);
            whileSK2 = false;
            canMove = true;
        }
    }

    //====================================================character03================================================================//


    //====================================================character04================================================================//

    IEnumerator returnThrowKnife()
    {
        yield return new WaitForSeconds(0.5f);
        if (anim.GetBool("isSk"))
        {
            whileSK1 = false;
            canMove = true;
            anim.SetBool("isSk", false);
        }
    }
    IEnumerator knifeOut()
    {
        yield return new WaitForSeconds(0.2f);
        if (anim.GetBool("isSk"))
        {
            if (x_lastMove > 0.5f && y_lastMove == 0)
            {
                Instantiate(knifeRight, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                Instantiate(knifeDownRight, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
                Instantiate(knifeUpRight, new Vector3(atkPos_right.position.x, atkPos_right.position.y, atkPos_right.position.z), Quaternion.identity);
            }
            else if (x_lastMove < -0.5f && y_lastMove == 0)
            {
                Instantiate(knifeLeft, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                Instantiate(knifeDownLeft, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
                Instantiate(knifeUpLeft, new Vector3(atkPos_left.position.x, atkPos_left.position.y, atkPos_left.position.z), Quaternion.identity);
            }
            else if (x_lastMove == 0 && y_lastMove > 0.5f)
            {
                Instantiate(knifeUp, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                Instantiate(knifeUpRight, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
                Instantiate(knifeUpLeft, new Vector3(atkPos_up.position.x, atkPos_up.position.y, atkPos_up.position.z), Quaternion.identity);
            }
            else if (x_lastMove == 0 && y_lastMove < -0.5f)
            {
                Instantiate(knifeDown, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                Instantiate(knifeDownLeft, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
                Instantiate(knifeDownRight, new Vector3(atkPos_down.position.x, atkPos_down.position.y, atkPos_down.position.z), Quaternion.identity);
            }
            else if (x_lastMove > 0.5f && y_lastMove > 0.5f)
            {
                Instantiate(knifeUpRight, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
                Instantiate(knifeRight, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
                Instantiate(knifeUp, new Vector3(atkPos_upRight.position.x, atkPos_upRight.position.y, atkPos_upRight.position.z), Quaternion.identity);
            }
            else if (x_lastMove > 0.5f && y_lastMove < -0.5f)
            {
                Instantiate(knifeDownRight, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
                Instantiate(knifeDown, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
                Instantiate(knifeRight, new Vector3(atkPos_downRight.position.x, atkPos_downRight.position.y, atkPos_downRight.position.z), Quaternion.identity);
            }
            else if (x_lastMove < -0.5f && y_lastMove > 0.5f)
            {
                Instantiate(knifeUpLeft, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
                Instantiate(knifeUp, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
                Instantiate(knifeLeft, new Vector3(atkPos_upLeft.position.x, atkPos_upLeft.position.y, atkPos_upLeft.position.z), Quaternion.identity);
            }
            else if (x_lastMove < -0.5f && y_lastMove < -0.5f)
            {
                Instantiate(knifeDownLeft, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
                Instantiate(knifeDown, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
                Instantiate(knifeLeft, new Vector3(atkPos_downLeft.position.x, atkPos_downLeft.position.y, atkPos_downLeft.position.z), Quaternion.identity);
            }
        }
    }
    IEnumerator throwKnifeCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            canSK1 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown/2f);
            canSK1 = true;
        }
    }
    IEnumerator speedyAtk()
    {
        float attackCooldownCopy = AttackCooldown;
        AttackCooldown = attackCooldownCopy / 2.0f;
        yield return new WaitForSeconds(4f);
        AttackCooldown = attackCooldownCopy;
        transform.localScale = new Vector3(1f, 1f, 1f);
        if (LevelControl.p1HP > 4)
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
        }
        whileSK2 = false;
    }
    IEnumerator speedyAtkCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown);
            canSK2 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown/2f);
            canSK2 = true;
        }
    }
    //====================================================character04================================================================//

    
    //====================================================character05================================================================//

    IEnumerator strike()
    {
        yield return new WaitForSeconds(0.7f);
        if (anim.GetBool("isStrikePrepare"))
        {
            anim.SetBool("isStrikePrepare", false);
            anim.SetBool("isStrike", true);
            canSK2 = true;
            Destroy(shadowFireTemp);
            shadowFirePos = transform.localPosition;
            shadowFireTemp = Instantiate(shadowFire, transform.localPosition, Quaternion.identity);
            whileDash = true;
            sr.color = new Color(0.2f, 0.2f, 0.2f, 1f);
            speed = speedCopy * dashSpeed*1.2f;
            //rb.velocity = new Vector2(x_lastMove * speed * Time.deltaTime, y_lastMove * speed * Time.deltaTime);
            StartCoroutine(returnStrike());
        }
    }
    IEnumerator strikePhx()
    {
        yield return new WaitForSeconds(1.2f);
        if (anim.GetBool("isStrikePrepare"))
        {
            rb.velocity = new Vector2(x_lastMove * speed * Time.deltaTime, y_lastMove * speed * Time.deltaTime);
        }
    }
    IEnumerator returnStrike()
    {
        yield return new WaitForSeconds(0.2f);        
        if (anim.GetBool("isStrike"))
        {
            anim.SetBool("isStrike", false);
            whileDash = false;
            whileSK1 = false;
            if (!isLowSpeedParry && !isStun)
            {
                speed = speedCopy;
            }
            if (!whileAttack && !isKnockBack && !isStun && !whileParry && !whileSK1 && !whileSK2)
            {
                canMove = true;
            }
            if(LevelControl.p1HP > 4)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (LevelControl.p1HP <= 4)
            {
                sr.color = new Color(1f, 0.7f, 0.7f, 1f);
            }
        }
    }
    IEnumerator strikeCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            canSK1 = true;
        }
        else if(LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown/2.0f);
            canSK1 = true;
        }
    }
    IEnumerator warpDisappear()
    {
        yield return new WaitForSeconds(0.4f);
        if (anim.GetBool("isDisappear"))
        {
            Destroy(shadowFireTemp);
            anim.SetBool("isAppear", true);
            anim.SetBool("isDisappear", false);
            transform.localPosition = shadowFirePos;
            StartCoroutine(returnWarp());
        }
    }
    IEnumerator returnWarp()
    {
        yield return new WaitForSeconds(0.5f);
        if (anim.GetBool("isAppear"))
        {
            canMove = true;
            anim.SetBool("isAppear", false);
            whileSK2 = false;
            if (LevelControl.p1HP > 4)
            {
                sr.color = new Color(1f, 1f, 1f, 1f);
            }
            else if (LevelControl.p1HP <= 4)
            {
                sr.color = new Color(1f, 0.7f, 0.7f, 1f);
            }
        }
    }
    //====================================================character05================================================================//


    //====================================================character06================================================================//

    IEnumerator returnStunBall()
    {
        yield return new WaitForSeconds(0.4f);
        if (anim.GetBool("isSk1"))
        {
            anim.SetBool("isSk1", false);
            canMove = true;
            whileSK1 = false;
        }
    }
    IEnumerator spawnStunBall()
    {
        yield return new WaitForSeconds(0.2f);
        if (anim.GetBool("isSk1"))
        {
            Instantiate(stunBall, new Vector3(atkPos_down.transform.position.x, atkPos_down.transform.position.y - 1f, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_downLeft.transform.position.x - 0.7f, atkPos_downLeft.transform.position.y - 0.7f, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_downRight.transform.position.x + 0.7f, atkPos_downRight.transform.position.y - 0.7f, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_left.transform.position.x - 1f, atkPos_left.transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_right.transform.position.x + 1f, atkPos_right.transform.position.y, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_up.transform.position.x, atkPos_up.transform.position.y + 1f, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_upLeft.transform.position.x - 0.7f, atkPos_upLeft.transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
            Instantiate(stunBall, new Vector3(atkPos_upRight.transform.position.x + 0.7f, atkPos_upRight.transform.position.y + 0.7f, transform.position.z), Quaternion.identity);
        }
    }
    IEnumerator stunBallCooldown()
    {
        if(LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            canSK1 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown/2f);
            canSK1 = true;
        }
    }

    IEnumerator goDown()
    {
        yield return new WaitForSeconds(1.5f);
        if (anim.GetBool("isSk2"))
        {
            anim.SetBool("isSk2", false);
            anim.SetBool("isGoDown", true);
            StartCoroutine(returnGoDown());
        }
    }

    IEnumerator startSpawnLightningBall()
    {
        yield return new WaitForSeconds(0.6f);
        if (anim.GetBool("isSk2"))
        {
            StartCoroutine(spawnThunderBall());
        }
    }

    IEnumerator spawnThunderBall()
    {
        int hp = LevelControl.p1HP;
        yield return new WaitForSeconds(0.2f);
        if (hp == LevelControl.p1HP)
        {
            sk2_count++;
            float offsetX = Random.Range(-6.5f, 6.5f);
            float offsetY = Random.Range(-5.5f, 7.5f);
            Instantiate(lightningball, new Vector3(transform.position.x + offsetX, transform.position.y + offsetY, transform.position.z), Quaternion.identity);
            if (sk2_count < 8)
            {
                StartCoroutine(spawnThunderBall());
            }
        }
        
    }

    IEnumerator returnGoDown()
    {
        yield return new WaitForSeconds(0.8f);
        if (anim.GetBool("isGoDown"))
        {
            anim.SetBool("isGoDown",false);
            canMove = true;
            whileSK2 = false;
        }
    }

    IEnumerator lightningBallCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown);
            canSK2 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown / 2f);
            canSK2 = true;
        }
    }
    //====================================================character06================================================================//

    //====================================================character07================================================================//

    IEnumerator returnSpawnSpike()
    {
        yield return new WaitForSeconds(0.6f);
        if (anim.GetBool("isSk1"))
        {
            anim.SetBool("isSk1", false);
            whileSK1 = false;
            canMove = true;
        }
    }

    IEnumerator startSpawnSpike()
    {
        yield return new WaitForSeconds(0.4f);
        if (anim.GetBool("isSk1"))
        {
            StartCoroutine(spawnSpike());
        }
    }

    IEnumerator spawnSpike()
    {
        yield return new WaitForSeconds(0.2f);
        sk1_count++;
        if(sk1_count < 8)
        {
            Instantiate(spike, new Vector3(currentPos.x + (spikeOffsetX * sk1_count), currentPos.y + (spikeOffsetY * sk1_count), currentPos.z), Quaternion.identity);
            StartCoroutine(spawnSpike());
        }
    }

    IEnumerator spikeCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown);
            canSK1 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk1Cooldown / 2f);
            canSK1 = true;
        }
    }

    IEnumerator startSlowDown()
    {
        yield return new WaitForSeconds(0.8f);
        if (anim.GetBool("isSk2"))
        {
            Time.timeScale = slowMo*5f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            anim.SetBool("isSk2", false);
            canMove = true;
            StartCoroutine(returnSlowDown());
        }
    }
    IEnumerator returnSlowDown()
    {
        yield return new WaitForSecondsRealtime(3f);
        if(Time.timeScale != 1 && LevelControl.p1HP > 0 && LevelControl.p2HP > 0)
        {
            Time.timeScale = 1;
            Time.fixedDeltaTime = 0.02f;
            whileSK2 = false;
        }
    }

    IEnumerator slowDownCooldown()
    {
        if (LevelControl.p1HP > 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown);
            canSK2 = true;
        }
        else if (LevelControl.p1HP <= 4)
        {
            yield return new WaitForSeconds(Sk2Cooldown / 2f);
            canSK2 = true;
        }
    }

    //====================================================character07================================================================//
}
