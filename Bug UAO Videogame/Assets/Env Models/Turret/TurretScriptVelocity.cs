using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScriptVelocity : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float howClose;
    public Transform head, barrel;
    public GameObject _projectile;
    public float fireRate, nextFire;
    public float force = 1500;

    public Animator turretAnimator;
    [SerializeField] Animator TurretAnimVelo;
    [SerializeField, Range(0.1f, 2f)] float animSpeedControl = 2f;

    public float lastShootTime;

    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        //turretAnimator.SetFloat("TurretAnimVelo", animSpeedControl);
        turretAnimator.speed = animSpeedControl;

    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose)
        {
            turretAnimator.SetBool("Waked", true);
            head.LookAt(_Player);
            if (Time.time > lastShootTime + fireRate)
            {
                lastShootTime = Time.time;
                turretAnimator.SetTrigger("Shoot");
            }
        }
        else
        {
            turretAnimator.SetBool("Waked", false);
        }

    }
    void shoot()
    {
        if (turretAnimator.GetBool("Waked") == false)
            return;
        GameObject clone = Instantiate(_projectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * force);
        Destroy(clone, 5);
    }

}
