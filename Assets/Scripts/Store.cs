using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{

    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyIncreasedPower()
    {
        Player.maxHealth -= 20;
        player.health -= 20;
        BloodBlast.power++;
    }

    public void buyIncreasedRegen()
    {
        Player.regen -= 0.2f;
        Player.maxHealth -= 40;
        player.health -= 40;
        BloodBlast.power++;
    }

}