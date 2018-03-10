using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public GameObject capsule;

    private FloatVariable capsuleHP;
    private FloatVariable maxHP;
    //private Slider slider;
    FloatingBarVariableController controller;
    FloatingBarController healthBar;
    private float hp = 0;
    bool acsend = true;


    // Use this for initialization
    void Start ()
    {        
        healthBar = capsule.GetComponent<FloatingBarController>();
        controller = capsule.GetComponent<FloatingBarVariableController>();

        capsuleHP = controller.currentValue; // capsule.GetComponent<FloatingBarVariableController>().currentValue;
        healthBar.Max.Value = 700;

        capsuleHP.SetValue(25);
        maxHP = controller.startingValue;

        // maxHP = capsule.GetComponent<FloatingBarVariableController>().startingValue;
        //slider = GetComponent<Slider>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log("maxHP: " + maxHP.Value);

        if (hp > maxHP.Value)
        {
            acsend = false;
        }
        else if (hp <= 0)
        {
            acsend = true;
        }

        if (acsend)
        {
            hp++;
        }
        else
        {
            hp--;
        }
        // capsuleHP.SetValue(slider.value * maxHP.Value);
        capsuleHP.SetValue(hp);
        Debug.Log("HP: " + hp);
    }
}


