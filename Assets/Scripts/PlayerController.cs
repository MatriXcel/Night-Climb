using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {

    int oppositeTree;

    public float switchSpeed;
    float vertSpeed;

    Animator anim;
   
    public bool switchit;
    bool isGrounded;

	void Start () {
        MilestoneManager.Instance.mileStoneReached += onMileStoneReached;

        oppositeTree = -1;
 
        anim = GetComponent<Animator>();
        isGrounded = true;
    }
	
    void onMileStoneReached(Difficulty diff)
    {
        vertSpeed = diff.playerSpeed;
    }

	void Update() {

        
        if(Input.GetButtonDown("Jump") || switchit)
        {
            isGrounded = false;
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            isGrounded = false;

        if (!isGrounded)
            switchSide(oppositeTree);
        else    
            transform.Translate(Vector3.up * vertSpeed * Time.deltaTime, Space.World);
    }

    /// <summary>
    /// moves the player based on which side he's on, speed and angle
    /// </summary>
    /// <param name="oppositeTree">the tree on the other side, opposite to the player</param>
    /// 
    void switchSide(int oppositeTree)
    {
        Vector2 vel = new Vector2(oppositeTree * switchSpeed, vertSpeed);
        transform.Translate(vel  * Time.deltaTime, Space.World);

        anim.SetBool("Jump", true);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "rightTree")
            oppositeTree = -1;
        else if (other.gameObject.tag == "leftTree")
            oppositeTree = 1;

  
        transform.localScale= new Vector3(transform.localScale.x, -Mathf.Abs(transform.localScale.y) * oppositeTree, transform.localScale.z);

       anim.SetBool("Jump", false);
        isGrounded = true;
    }
}
