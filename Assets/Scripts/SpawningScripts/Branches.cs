using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branches : MonoBehaviour {

    float BranchScaleY;
    int direction;
    Vector3 transScale;
    void Awake()
    {
        BranchScaleY = transform.localScale.y;
         transScale = transform.localScale;
        
    }


    void OnEnable()
    {
        direction = (transform.parent.tag == "rightTree") ? 1 : -1;
        RandomizeBranch();
    }

    void RandomizeBranch()
    {
        if (Random.Range(0, 10) <= 7)
        {
            
            Vector3 transRot = transform.rotation.eulerAngles;

            transform.localScale = new Vector3(direction * transScale.x, transScale.y, transScale.z);
           // transform.localScale = new Vector3(direction, Random.Range(BranchScaleY, BranchScaleY + 1.5f), transScale.z);
           //transform.eulerAngles = new Vector3(transRot.x, transRot.y, Random.Range(BranchScaleY - 30, BranchScaleY + 30));

            transform.localPosition = new Vector3(-0.05f, Random.Range(0.8f, -0.8f), 0);
        }
        else
            transform.gameObject.SetActive(false);

    }
}
