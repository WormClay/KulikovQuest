using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjects : MonoBehaviour
{

    public bool IsKey { get; set; }
    public bool IsGun { get; set; }
    public bool IsBomb { get; set; }
    [SerializeField] private int helth;
    private int maxHelth = 100;
    private Text text;

    public PlayerObjects() 
    {
        IsKey = false;
        IsGun = false;
        IsBomb = false;
    }

    public void Hit(int damage) 
    {
        if (helth >= 0)
        {
            helth -= damage;
            text.text = $"Helth {helth}";
            if (helth <= 0) 
            {
                Time.timeScale = 0;
                Debug.Log("Game Over");
            }
        }
    }

    public void Med(int med)
    {
        
        helth += med;
        if (helth > maxHelth) helth = maxHelth;
        text.text = $"Helth {helth}";
    }

    private void Start()
    {
        text = GameObject.Find("TextUI").GetComponent<Text>();
        text.text = $"Helth {helth}";
        helth = maxHelth;
    }

}
