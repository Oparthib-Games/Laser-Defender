﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionScript : MonoBehaviour {

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.7f);
    }

}
