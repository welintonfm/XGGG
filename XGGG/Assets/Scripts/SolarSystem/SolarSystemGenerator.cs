using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class SolarSystemGenerator : MonoBehaviour
{

    static SolarSystemGenerator _instance;

    public static SolarSystemGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SolarSystemGenerator>();
                if (_instance == null)
                {
                    throw new Exception("Cannot find SolarSystemGenerator instance.");
                }
            }
            return _instance;
        }
    }

    [Header("Buckets")]
    public Transform planetBucket;
    public Transform orbitBucket;


    [Header("Planets Prefabs")]
    public GameObject[] hotPlanets;
    public GameObject[] middlePlanets;
    public GameObject[] coldPlanets;

    [Header("Orbit Prefabs")]
    public GameObject[] hotOrbits;
    public GameObject[] middleOrbits;
    public GameObject[] coldOrbits;

    [Header("Life Sliders")]
    public Slider[] sliders;


    public void GenerateLevel()
    {

        foreach (var planet in FindObjectsOfType<PlanetBehavior>())
        {
            Destroy(planet.gameObject);
        }

        foreach (var planet in FindObjectsOfType<EllipseRenderer>())
        {
            Destroy(planet.gameObject);
        }


        GameObject hotPlanet = hotPlanets[(int)UnityEngine.Random.Range(0, hotPlanets.Length)];
        GameObject middlePlanet = middlePlanets[(int)UnityEngine.Random.Range(0, middlePlanets.Length)];
        GameObject coldPlanet = coldPlanets[(int)UnityEngine.Random.Range(0, coldPlanets.Length)];

        GameObject hotOrbit = hotOrbits[(int)UnityEngine.Random.Range(0, hotOrbits.Length)];
        GameObject middleOrbit = middleOrbits[(int)UnityEngine.Random.Range(0, middleOrbits.Length)];
        GameObject coldOrbit = coldOrbits[(int)UnityEngine.Random.Range(0, coldOrbits.Length)];

        PlanetBehavior planetBehavior;
        EllipseRenderer ellipseRenderer;

        planetBehavior = Instantiate(hotPlanet, Vector3.zero, Quaternion.identity, planetBucket).GetComponent<PlanetBehavior>();
        ellipseRenderer = Instantiate(hotOrbit, Vector3.zero, Quaternion.identity, orbitBucket).GetComponent<EllipseRenderer>();
        planetBehavior.gameObject.name = "planet01";
        ellipseRenderer.gameObject.name = "orbit01";
        planetBehavior.orbit.xAxis = ellipseRenderer.ellipse.xAxis;
        planetBehavior.orbit.yAxis = ellipseRenderer.ellipse.yAxis;
        planetBehavior.Setup();
        planetBehavior.GetComponent<LifeBehaviour>().SetSlider(sliders[0]);

        planetBehavior = Instantiate(middlePlanet, Vector3.zero, Quaternion.identity, planetBucket).GetComponent<PlanetBehavior>();
        ellipseRenderer = Instantiate(middleOrbit, Vector3.zero, Quaternion.identity, orbitBucket).GetComponent<EllipseRenderer>();
        planetBehavior.gameObject.name = "planet02";
        ellipseRenderer.gameObject.name = "orbit02";
        planetBehavior.orbit.xAxis = ellipseRenderer.ellipse.xAxis;
        planetBehavior.orbit.yAxis = ellipseRenderer.ellipse.yAxis;
        planetBehavior.Setup();
        planetBehavior.GetComponent<LifeBehaviour>().SetSlider(sliders[1]);

        planetBehavior = Instantiate(coldPlanet, Vector3.zero, Quaternion.identity, planetBucket).GetComponent<PlanetBehavior>();
        ellipseRenderer = Instantiate(coldOrbit, Vector3.zero, Quaternion.identity, orbitBucket).GetComponent<EllipseRenderer>();
        planetBehavior.gameObject.name = "planet03";
        ellipseRenderer.gameObject.name = "orbit03";
        planetBehavior.orbit.xAxis = ellipseRenderer.ellipse.xAxis;
        planetBehavior.orbit.yAxis = ellipseRenderer.ellipse.yAxis;
        planetBehavior.Setup();
        planetBehavior.GetComponent<LifeBehaviour>().SetSlider(sliders[2]);



    }

}
