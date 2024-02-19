using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : GameMonoBehaviour
{
    [Header("Playe Movement")]
    [SerializeField] protected float moveSpeed;
    [HideInInspector]
    [SerializeField] protected Vector3 moveInput;
    public Vector3 MoveInput => moveInput;
    [Header("Player Roll")]
    [SerializeField] protected float rollTime = 0.5f;
    [SerializeField] protected float rollDelay = 2f;
    [SerializeField] protected float rollBoost = 20f;
    [SerializeField] protected bool isRoll = false;
    [SerializeField] protected PlayerAnim playerAnim;
    [SerializeField] protected Transform model;
    //Test cooldown
    [SerializeField] Image abilityImage;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerAnim();
        this.LoadModel();
        this.LoadAbilityImage();
    }
    protected virtual void LoadPlayerAnim()
    {
        if (this.playerAnim != null) return;
        this.playerAnim = transform.parent.GetComponentInChildren<PlayerAnim>();
        Debug.Log(transform.name + "||LoadPlayerAnim||", gameObject);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.parent.Find("Model");
        Debug.Log(transform.name + "||LoadModel||", gameObject);
    }
    protected virtual void LoadAbilityImage()
    {
        if (this.abilityImage != null) return;
        this.abilityImage = FindObjectOfType<Canvas>().transform.Find("UIBottomLeft").Find("BackGround").GetComponent<Image>();
    }

    protected virtual void Update()
    {
        this.Moving();
        this.Rolling();
    }
    protected virtual void Moving()
    {
        this.moveInput.x = Input.GetAxis("Horizontal");
        this.moveInput.y = Input.GetAxis("Vertical");
        transform.parent.position += moveInput * moveSpeed * Time.deltaTime;
        playerAnim.WalkAnim();
        if (moveInput.x != 0)
        {
            if (moveInput.x < 0) model.transform.localScale = new Vector3(-1, 1, 0);
            if (moveInput.x > 0) model.transform.localScale = new Vector3(1, 1, 0);
        }
    }
    protected virtual void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rollDelay <= 0)
        {
            playerAnim.RollAnim(true);
            isRoll = true;
            this.rollDelay = 2f;
            this.moveSpeed += rollBoost;
            
        }
        this.RollCoolDown();
    }
    protected virtual void RollCoolDown()
    {
        rollDelay -= Time.deltaTime;
       
        if (rollDelay <= 0)
        {
            abilityImage.fillAmount = 0f;
            rollDelay = 0f;
            rollTime = 0.5f;
        }
        if (isRoll == true)
        {
            this.rollTime -= Time.deltaTime;
            if (rollTime <= 0)
            {
                this.moveSpeed -= rollBoost;
                isRoll = false;
                playerAnim.RollAnim(false);
            }
        }
        this.abilityImage.fillAmount = this.rollDelay / 2f;
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 2f;
    }
}
