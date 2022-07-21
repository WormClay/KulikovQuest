using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjects : MonoBehaviour
{

    //public bool IsKey { get; set; }
    //public bool IsGun { get; set; }
    //public bool IsBomb { get; set; }
    [SerializeField] private int helth;
    private int frags = 0;
    private int maxHelth = 100;
    private Text text;
    private Text text2;
    private GameObject enemysGO;
    [SerializeField] private int countEnemys = 2;

    public PlayerObjects() 
    {
        //IsKey = false;
        //IsGun = false;
        //IsBomb = false;
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

    public void AddFrag() 
    {
        frags ++;
        text2.text = $"Frags {frags}";
        countEnemys = enemysGO.transform.childCount;
        if (countEnemys <= 2) 
        {
            text.text = "WIN";
            text2.text = "WIN";
            Time.timeScale = 0;
        }
    }

    private void Start()
    {
        helth = maxHelth;
        text = GameObject.Find("TextUI").GetComponent<Text>();
        text.text = $"Helth {helth}";
        text2 = GameObject.Find("TextUIFrags").GetComponent<Text>();
        text2.text = $"Frags {frags}";
        enemysGO = GameObject.Find("Enemys");
        countEnemys = enemysGO.transform.childCount;
    }

}
