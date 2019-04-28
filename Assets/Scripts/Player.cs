using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Animator)), RequireComponent(typeof(AudioSource))]
public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource source;

    public AudioClip hit;
    public AudioClip shoot;

    public float speed = 10;

     /**
     * 1 = Up
     * 3 = Down
     * 2 = Left
     * 0 = Right
     */
    private int direction = 1;

    public int health = 100;
    public static int maxHealth = 100;
    public Text textHealth;

    public GameObject blast;

    private float regenTime = 0;

    public Slider slider;

    public static float regen = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        regenTime += Time.deltaTime;

        if (regenTime >= regen)
        {
            if (health < maxHealth)
            {
                health += 1;
            }
            regenTime = 0; 
        }
        
        float speedX = 0;
        float speedY = 0;

        if (Input.GetKey(KeyCode.W))
        {
            speedY += 1;
            direction = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speedY += -1;
            direction = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            speedX += -1;
            direction = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            speedX += 1;
            direction = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            speedX = 0;
            speedY = 0;
            regenTime += 0.1f;
        }

        rb.velocity = new Vector2(speedX * speed, speedY * speed);

        animator.SetInteger("direction", direction);

        textHealth.text = "Health: " + health;

        slider.maxValue = maxHealth;
        slider.value = health;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            health -= 5;
            GameObject obj = Instantiate(blast);
            obj.transform.position = transform.position;
            obj.GetComponent<BloodBlast>().direction = direction;
            source.PlayOneShot(shoot);
        }

        if (health <= 0)
        {
            lose();
        }

    }

    public void lose()
    {
        SceneManager.LoadScene("Lose");
    }

    void onDamageTaken(int damage)
    {
        health -= damage;
        source.PlayOneShot(hit);
    }

}