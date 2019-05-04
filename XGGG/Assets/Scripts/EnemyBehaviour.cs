using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(GunBehavior))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float Speed = 1.0f;
    [SerializeField] private float BulletRangeMin = 0.0f;
    [SerializeField] private float BulletRangeMax = 0.0f;
    [SerializeField] private float CooldownTime = 0.0f;
    [SerializeField] private Transform Target = null;

    private Quaternion lastRotation = new Quaternion();
    private float nextBullet = 0.0f;


    public bool starSeeker = false;

    private bool shooting;

    GunBehavior myGun;

    void Awake()
    {
        myGun = GetComponentInChildren<GunBehavior>();
    }

    void Update()
    {
        if (Target != null)
        {

            // TODO: Rotate it Properly
            Vector3 dir = Target.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + 270;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Movement

            if (!shooting)
            {
                if (Vector3.Distance(Target.position, transform.position) >= BulletRangeMin)
                {
                    transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
                }
                else
                {
                    shooting = true;
                }
            }
            else
            {
                if (Vector3.Distance(Target.position, transform.position) >= BulletRangeMax)
                {
                    shooting = false;
                }

                if (nextBullet <= Time.time)
                {
                    
                    myGun.Shoot();
                    nextBullet = Time.time + CooldownTime;
                }
            }

        }
        else
        {
            ChooseTarget();
        }

    }

    void ChooseTarget()
    {
        if (starSeeker)
        {
            Target = LevelController.Instance.star.transform;
        }
        else
        {
            float dist = float.PositiveInfinity;
            foreach (PlanetBehavior planet in LevelController.Instance.planets)
            {
                if (Vector3.Distance(transform.position, planet.transform.position) < dist)
                {
                    Target = planet.transform;
                    dist = Vector3.Distance(transform.position, planet.transform.position);
                }
            }
        }
    }



}
