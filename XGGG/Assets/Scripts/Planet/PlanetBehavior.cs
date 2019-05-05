using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehavior : MonoBehaviour
{
    public GameObject selectIndicator;

    public Ellipse orbit;

    [Range(0f, 1f)]
    public float orbitProgress;
    public float orbitPeriod = 3;


    float cTime;

    public void Setup()
    {
        cTime = orbitProgress*orbitPeriod;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelController.Instance.GameRunnig)
            return;
        UpdatePosition();
    }


    public void Select(bool b)
    {
        selectIndicator.SetActive(b);
    }


    void UpdatePosition()
    {
        if(orbit == null) return;

        float progress = (cTime / orbitPeriod)%1f;
        
        transform.localPosition = orbit.Evaluate(progress);
        cTime += Time.deltaTime;
    }


    public void DestroyPlanet(){
        ShakeController.GreateShake();
        Invoke("DestroyGameObject", 2f);
    }

    public void DestroyGameObject(){
        Destroy(gameObject);
    }

}
