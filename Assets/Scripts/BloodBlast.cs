using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BloodBlast : MonoBehaviour
{
     /**
     * 1 = Up
     * 3 = Down
     * 2 = Left
     * 0 = Right
     */
    public int direction = 1;

    public float speed = 8;

    private Rigidbody2D rb;

    public static int power = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (direction == 1)
        {
            rb.velocity = (new Vector3(0, speed));
        }

        if (direction == 3)
        {
            rb.velocity = (new Vector3(0, -speed));
        }

        if (direction == 2)
        {
            rb.velocity = (new Vector3(-speed, 0));
        }

        if (direction == 0)
        {
            rb.velocity = (new Vector3(speed, 0));
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Player") && !collision.tag.Equals("BloodBlast"))
        {
            for (int i = 0; i < power; i++)
            {
                collision.gameObject.BroadcastMessage("onDamageTaken", SendMessageOptions.DontRequireReceiver);
            }
            Destroy(gameObject);
        }
    }

}
