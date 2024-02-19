using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : GameMonoBehaviour
{
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    [SerializeField] protected PlayerMovement playerMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadPlayerMove();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
        Debug.LogWarning(transform.name + "||LoadAnimator||", gameObject);
    } 
    protected virtual void LoadPlayerMove()
    {
        if (this.playerMove != null) return;
        this.playerMove = transform.parent.GetComponentInChildren<PlayerMovement>();
        Debug.Log(transform.name + "||LoadPlayerMove||", gameObject);
    }

    public virtual void WalkAnim()
    {
        animator.SetFloat("Move", playerMove.MoveInput.sqrMagnitude);
    }
    public virtual void RollAnim(bool canRoll)
    {
        animator.SetBool("Roll", canRoll);
    }
}
