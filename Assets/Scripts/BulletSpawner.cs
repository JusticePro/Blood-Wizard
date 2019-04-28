using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public float interval;
    public float delay = 0;
    public int direction = 1;

    public GameObject blast;

    private float time = 0;

    private float delayTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delayTime += Time.deltaTime;

        if (delayTime >= delay)
        {
            time += Time.deltaTime;

            if (time >= interval)
            {
                GameObject obj = Instantiate(blast);
                obj.transform.position = transform.position;
                obj.GetComponent<EvilBlast>().direction = direction;
                time = 0;
            }
        }

    }

}
