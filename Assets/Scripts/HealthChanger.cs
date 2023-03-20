using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthChanger : MonoBehaviour
{
    public Player player;
    public Slider slider;
    public Button buttonTreatment;
    public Button buttonDamage;
    private float _minHealth = 0;
    private float _maxHealth = 100;
    private float _amountOfChangePerClick = 10;
    private float _timeForChange = 0.001f;

    public void Start()
    {
        slider.value = player.GetHealth();
    }

    public void SynchronizeInterface(int directionOfChange) 
    { 
        StartCoroutine(SetSliderValue(directionOfChange));
        DefineButtonActivity(buttonTreatment, _maxHealth);
        DefineButtonActivity(buttonDamage, _minHealth);
    }

    private void DefineButtonActivity(Button button, float limitValue) 
    {
        button.interactable = true;
        float playerHealth = player.GetHealth();

        if(playerHealth == limitValue)
        {
            button.interactable = false;
        }
    }

    private IEnumerator SetSliderValue(int directionOfChange) 
    {
        float currentValue = slider.value;
        float targetValue = player.GetHealth();
        var waightForSomeSeconds = new WaitForSeconds(_timeForChange);
        float time = 0;

        while(slider.value != player.GetHealth()) 
        {
            slider.value = Mathf.MoveTowards(currentValue, targetValue, _amountOfChangePerClick * time);
            time += Time.deltaTime;

            yield return waightForSomeSeconds;
        }
    }
}   


