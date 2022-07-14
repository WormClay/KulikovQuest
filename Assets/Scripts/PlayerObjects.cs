using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjects : MonoBehaviour
{

    public bool IsKey { get; set; }
    public bool IsGun { get; set; }

    public PlayerObjects() 
    {
        IsKey = false;
        IsGun = false;
    }

}
