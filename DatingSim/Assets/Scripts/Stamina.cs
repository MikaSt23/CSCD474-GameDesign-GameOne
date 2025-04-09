using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public int curStamina = 0;
    public int maxStamina = 100;

    public StaminaBar staminaBar;

    void Start()
    {
        curStamina = maxStamina;
    }

    void Update()
    {
        if( Input.GetKeyDown( KeyCode.Space ) )
        {
            DrainStam(10);
        }
    }

    public void DrainStam( int damage )
    {
        curStamina -= damage;

        staminaBar.SetStam( curStamina );
    }
}
