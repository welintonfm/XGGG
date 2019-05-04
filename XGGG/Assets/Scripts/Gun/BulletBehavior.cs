using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletBehavior : MonoBehaviour
{
    Transform father;
    float power;
    Vector3 direction;
    float speed;

    bool setup;
    void Update()
    {
        if (setup)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void Setup(Vector3 direction, float speed, float power, float lifeTime, Transform father)
    {
        this.direction = direction;
        this.speed = speed;
        this.power = power;
        this.father = father;

        setup = true;
        Invoke("Vanish", lifeTime);
    }

    private void Vanish()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform != father)
        {
            LifeBehaviour f = other.gameObject.GetComponent<LifeBehaviour>();
            if (f != null)
            {
                f.OnLifeLoss((int)this.power);
            }
            Vanish();
        }

    }
}
