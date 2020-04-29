using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wispflame : MonoBehaviour
{
    ParticleSystem ps;
    public float min;
    public float max;
    public float rate;
    float start = 0;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float size = Mathf.Lerp(min, max, start);
        start += rate * Time.deltaTime;
        var main = ps.main;
        main.startSize = size;
    }
}
