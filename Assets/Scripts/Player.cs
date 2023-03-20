using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float _health = 60;
    private float _amountOfChangePerClick = 10;

    public float GetHealth()
    {
        return _health;
    }

    public void HealPlayer() 
    {
        _health += _amountOfChangePerClick;
    }

    public void MakeDamage()
    {
        _health -= _amountOfChangePerClick;
    }
}
