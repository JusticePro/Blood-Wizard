using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AudioSource))]
public class Monster : MonoBehaviour
{

    public int health;
    public int damage;

    private AudioSource source;

    public AudioClip hit;

    private NavMeshAgent agent;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (GetComponent<NavMeshAgent>() != null)
        {
            agent = GetComponent<NavMeshAgent>();

        }

    }

    // Update is called once per frame
    void Update()
    {
        
        if (agent != null)
        {
            agent.steeringTarget.Set(player.position.x, player.position.y, player.position.z);
        }

    }

    void onDamageTaken()
    {
        health--;
        source.PlayOneShot(hit);
        if (health <= 0)
        {
            Destroy(gameObject);
        }else
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("Player"))
        {
            collision.gameObject.BroadcastMessage("onDamageTaken", damage, SendMessageOptions.DontRequireReceiver);
        }
    }

}