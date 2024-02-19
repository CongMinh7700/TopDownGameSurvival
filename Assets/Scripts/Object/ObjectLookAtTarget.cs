using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtTarget : GameMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float rotSpeed = 3f;


    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
    }
    protected virtual void SetRotSpeed(float speed)
    {
        this.rotSpeed = speed;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        float timeSpeed = this.rotSpeed * Time.fixedDeltaTime;

        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);

        transform.parent.rotation = currentEuler;
        if (transform.parent.eulerAngles.z > 90 && transform.parent.eulerAngles.z < 270) transform.parent.localScale = new Vector3(1, -1, 0);
        else transform.parent.localScale = new Vector3(1, 1, 0);
    }

}
