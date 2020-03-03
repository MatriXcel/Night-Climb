using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour {

    public float speed;
    Vector3 dir;
 
    
    void Start()
    {
        dir = Vector3.left;
    }

    void OnEnable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if(LayerMask.LayerToName(other.gameObject.layer) == "Trees")
        {
            dir *= -1;
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    void Update () {
       transform.Translate(dir * Time.deltaTime  * speed);

    }
}
