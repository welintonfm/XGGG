using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{

    enum GunState
    {
        idle,
        movingLeft,
        movingRight
    }
    [Header("Gun Settings")]
    [SerializeField]
    [Range(0, 10)]
    float rotateSpeed = 0;

    [SerializeField]
    [Range(0, 10)]
    float fireRate = 0;

    [Header("Bullet Settings")]

    public GameObject bulletPrefab;

    [SerializeField]
    [Range(0, 10)]
    float firePower = 0;

    [SerializeField]
    [Range(0, 10)]
    float bulletSpeed = 0;
    [SerializeField]
    [Range(0, 10)]
    float lifeTime = 5;

    Transform planetTransform;
    GunState state;
    float nextFire;

    Transform bulletBucket;

    void Start()
    {
        planetTransform = transform.parent;
        state = GunState.idle;
        nextFire = Time.time;

        bulletBucket = GameObject.FindGameObjectWithTag("BulletBucket").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (state != GunState.idle)
        {
            if (state == GunState.movingLeft)
            {
                Rotate(rotateSpeed);
            }

            if (state == GunState.movingRight)
            {
                Rotate(-rotateSpeed);
            }
        }
    }

    void Rotate(float speed)
    {
        transform.RotateAround(planetTransform.transform.position, new Vector3(0, 0, 1), speed);
    }

    public void MoveToLeft()
    {
        state = GunState.movingLeft;
    }

    public void MoveToRight()
    {
        state = GunState.movingRight;
    }

    public void Stop()
    {
        state = GunState.idle;
    }

    public void Shoot()
    {
        if (nextFire < Time.time)
        {
            BulletBehavior b = Instantiate(bulletPrefab, transform.position, Quaternion.identity, bulletBucket).GetComponent<BulletBehavior>();
            b.Setup(transform.up, bulletSpeed, firePower, lifeTime);
            nextFire = Time.time + fireRate;
        }
    }


}
