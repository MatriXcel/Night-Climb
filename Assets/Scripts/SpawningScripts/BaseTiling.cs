using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTiling : MonoBehaviour {


    protected static Camera cam;
    protected static float camVerticalExtend;

    public float offsetY;
    protected float spriteHeight;

    bool hasUpBuddy;

    public delegate void OnTileDisabled();
    public event OnTileDisabled tileDisabled;

    public ObjectPooler theObjectPool;

    protected virtual void Start () {
        cam = Camera.main;
        camVerticalExtend = Mathf.Abs(cam.transform.position.z) * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad);
        hasUpBuddy = false;
    }
	
	
	protected void Update () {
        float topGenPoint = (transform.position.y + spriteHeight / 2) - camVerticalExtend;
        float deactivationPoint = transform.position.y + (spriteHeight * 2) + offsetY;

        float camPosY = cam.transform.position.y;

        if ((camPosY > topGenPoint - offsetY) && !hasUpBuddy)
        {
            makeTile();
            hasUpBuddy = true;
        }

        if (camPosY > deactivationPoint)
        {
            if(tileDisabled != null)
                tileDisabled();

            gameObject.SetActive(false);
        }
    }

    void SetActiveRecursively(GameObject rootObject, bool active)
    {
        rootObject.SetActive(active);

        foreach (Transform childTransform in rootObject.transform)
        {
            SetActiveRecursively(childTransform.gameObject, active);
        }
    }

    protected  void makeTile()
    {
        Vector3 newPosition = transform.position + new Vector3(0, spriteHeight, 0);
        GameObject tile = theObjectPool.getPooledObject();

        tile.transform.position = newPosition;
        tile.transform.parent = transform.parent;

        tile.SetActive(true);
        tile.GetComponent<BaseTiling>().hasUpBuddy = false;
    }
}
