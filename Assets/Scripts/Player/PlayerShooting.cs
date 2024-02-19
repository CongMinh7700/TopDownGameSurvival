using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : ObjectShooting
{
    [SerializeField] protected AudioSource shootingSound;
    protected override void ResetValue()
    {
        this.shootDelay = 0.65f;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAudioSource();
    }
    //DM-GCS-07
    protected virtual void LoadAudioSource()
    {
        if (this.shootingSound != null ) return;
        this.shootingSound = GetComponent<AudioSource>();
        Debug.LogWarning(transform.name + "||LoadAudioSouce||", gameObject);
    }
    protected override void Shooting()
    {
        shootTimer += Time.deltaTime;
        if (!this.isShooting) return;
        if (this.shootTimer < shootDelay) return;
        shootTimer = 0;
        shootingSound.Play();
        Vector3 position = transform.position;
        Quaternion rotation = transform.parent.rotation;
        string prefabName = BulletSpawner.Instance.bulletOne;
        Transform newBullet = BulletSpawner.Instance.Spawn(prefabName, position, rotation);
        if (newBullet == null) return;
        //
        newBullet.gameObject.SetActive(true);
        //Them vao de de debug
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFire == 1;
        return this.isShooting;
    }
   
}
