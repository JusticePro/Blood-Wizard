using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseSpawner : MonoBehaviour
{

    public Transform target;

    public float interval;
    public float delay = 0;

    public GameObject obj;

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
                GameObject ob = Instantiate(obj);
                ob.GetComponent<FollowTarget>().target = target;
                ob.transform.position = transform.position;
                time = 0;
            }
        }

    }

}
