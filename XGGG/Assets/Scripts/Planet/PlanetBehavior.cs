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

    // Start is called before the first frame update
    void Start()
    {
        cTime = orbitProgress*orbitPeriod;
    }

    // Update is called once per frame
    void Update()
    {
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
}
