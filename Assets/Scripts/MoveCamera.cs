using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;
    public float OffsetY;
    
    void Update()
    {
        transform.position = new Vector3(transform.position.x, player.position.y + OffsetY , transform.position.z);
    }
}
