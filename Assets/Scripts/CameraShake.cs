using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    Vector2 snapPos;
    float t;
    float shakeAmt;


	void Start () {
        
	}
	

    public void shakeCam(float shakeLength, float amt)
    {
        shakeAmt = amt;

        InvokeRepeating("doShake", 0, 0.01f);
        Invoke("stopShake", shakeLength);
    }

    void doShake()
    {
        if (t >= 1)
        {
            snapPos = Random.insideUnitCircle;
            t = 0;
        }
        else
            t += Time.deltaTime * shakeAmt;

        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(snapPos.x, snapPos.y, 0), t);  
    }

    void stopShake()
    {
        CancelInvoke("doShake");
        transform.localPosition = Vector3.zero;
    }
}
