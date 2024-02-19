using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectShooting : GameMonoBehaviour
{
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected bool isShooting =false;
 

    protected virtual void Update()
    {
        this.IsShooting();
    }
    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer < shootDelay) return;
        shootTimer = 0;
      
        Vector3 position = transform.position;
        Quaternion rotation = transform.parent.rotation;
        string prefabName = BulletSpawner.Instance.bulletTwo;
        Transform newBullet = BulletSpawner.Instance.Spawn(prefabName, position, rotation);
        if (newBullet == null) return;
        //
        newBullet.gameObject.SetActive(true);  
        //Them vao de de debug
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);


    }

    protected abstract bool IsShooting();

}
