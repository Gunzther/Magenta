using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light[] lights;
    public GameObject particle;
    public bool isOn = true;

    void Awake()
    {
        lights = FindObjectsOfType<Light>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Light light in lights)
        {
            light.enabled = isOn;
            particle.SetActive(isOn);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        foreach(Light light in lights)
        {
            light.enabled = !light.enabled;
            particle.SetActive(light.enabled);
        }
    }

    //check that another GO is enter to the area: no bounce
    void OnTriggerEnter(Collider other)
    {
        print("trigger: " + other.gameObject.name);
    }

    //check that another GO is collish this GO: bounce
    void OnCollisionEnter(Collision collision)
    {
        print("collision: " + collision.gameObject.name);
    }
}
