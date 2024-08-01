using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovment : MonoBehaviour
{

    public GameOverScreen gameOverScreen;
    private GameplayController a;
    int kill = 0;

    [SerializeField]
    private float movespeed = 3.5f;
    [SerializeField]
    private float minBound_X = -71f, maxBound_X = 71f, minBound_Y = -3.3f, maxBound_Y  = 0f;
    private Vector3 tempPos;
    private float xAxis, yAxis;
    private PlayerAnimation playerAnimation;
    [SerializeField]
    private float shootWaitTime = 0.5f;
    private float waitBeforeShooting;
    [SerializeField]
    private float moveWaitTime = 0.3f;
    private float waitBeforeMoving;
    private bool canMove = true;
    private PlayerShootingManager playerShootingManager;

    private bool playerDied;


   

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        playerShootingManager = GetComponent<PlayerShootingManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerDied)
            return;

        HndleMovment();
        HandleAnimation();
        HandleFacingDirection();
        HandleShooting();
        CheckIfCanMove();

    }
    void HndleMovment()

    {
        xAxis = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);        
        yAxis = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);

        if (!canMove)
            return;

        tempPos = transform.position;

        tempPos.x += xAxis * movespeed * Time.deltaTime;
        tempPos.y += yAxis * movespeed * Time.deltaTime;

        if (tempPos.x < minBound_X)
            tempPos.x = minBound_X;

        if (tempPos.x > maxBound_X)
            tempPos.x = maxBound_X;

        if (tempPos.y < minBound_Y)
            tempPos.y = minBound_Y;

        if (tempPos.y > maxBound_Y)
            tempPos.y = maxBound_Y;

        transform.position = tempPos;

    }

    void HandleAnimation()
    {
        if (!canMove)
            return;


        if (Mathf.Abs(xAxis) > 0 || Mathf.Abs(yAxis) > 0)
            playerAnimation.PlayAnimation(TagManager.WALK_ANIMATION_NAME);
        else
            playerAnimation.PlayAnimation(TagManager.IDLE_ANIMATION_NAME);
    }
    void HandleFacingDirection()
    {
        if (xAxis > 0)
            playerAnimation.SetFacingDirection(true);
        else if(xAxis<0)
            playerAnimation.SetFacingDirection(false);
    }
    void StopMovment()
    {
        canMove = false;
        waitBeforeMoving = Time.time + moveWaitTime;
    }
    void Shoot()
    {
        waitBeforeShooting = Time.time + shootWaitTime;
        StopMovment();
        playerAnimation.PlayAnimation(TagManager.SHOOT_ANIMATION_NAME);
        playerShootingManager.Shoot(transform.localScale.x);
    }
    void CheckIfCanMove()
    {
        if (Time.time > waitBeforeMoving)
            canMove = true;
    }
    void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Time.time > waitBeforeShooting)
                Shoot();
        }
    }
    public void PlayerDied()
    {
        playerDied = true;
        playerAnimation.PlayAnimation(TagManager.DEATH_ANIMATION_NAME);
        Invoke("DestroyPlayerAfterDelay", 2f);
       // gameOver();


    }

    void DestroyPlayerAfterDelay()
    {
        Destroy(gameObject);
        gameOver();
        //Debug.Log("a");
    }
    public void gameOver()
    {
        gameOverScreen.Setup();
    }
    
}
