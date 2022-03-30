using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPower : MonoBehaviour {

    public float laserDamage = 100f;

    public float performDamage()
    {
        return laserDamage;
    }

    public void Hit()
    {
        //destroy the laser object after a hit.
        Destroy(gameObject);
    }
}
