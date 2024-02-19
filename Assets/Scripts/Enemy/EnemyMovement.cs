using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : GameMonoBehaviour
{
    [Header("Enemy Movement")]
    [SerializeField] protected float moveSpeed = 5f;
    public float MoveSpeed => moveSpeed;

    [SerializeField] protected Transform player;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();

    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
        Debug.LogWarning(transform.name + "||LoadPlayer||", gameObject);
    }
    protected virtual void FixedUpdate()
    {
        this.MoveToPlayer();
    }
 


    protected virtual void MoveToPlayer()
    {

        Vector2 distance = player.position - transform.position;
        Vector2 force = distance * moveSpeed * Time.deltaTime;

        transform.parent.position += (Vector3)force;
        if (force.x != 0)
        {
            if (force.x < 0) transform.parent.localScale = new Vector3(-1, 1, 0);
            else transform.parent.localScale = new Vector3(1, 1, 0);
        }
    }

    public virtual void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

}
