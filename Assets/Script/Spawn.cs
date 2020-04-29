using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float timer;
    float timerStart;
    public float MinRange;
    public float MaxRange;
    public float NullRangeMin;
    public float NullRangeMax;
    public Transform slime;
    public Transform wisp;
    // Start is called before the first frame update
    void Start()
    {
        timerStart = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float x = Random.Range(MinRange, MaxRange);
            float z = Random.Range(MinRange, MaxRange);
            if (x > NullRangeMax || x < NullRangeMin && z > NullRangeMin || z < NullRangeMax)
            {
                float enemy = Random.Range(0, 2);
                if(enemy == 1)
                {
                    Instantiate(slime, new Vector3(x, 0, z), Quaternion.identity);
                }
                if(enemy == 0)
                {
                    Instantiate(wisp, new Vector3(x, 0, z), Quaternion.identity);
                }
                timer = timerStart;
            }
        }
    }
}
