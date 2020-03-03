using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandleCollisions : MonoBehaviour {


    Camera mainCamera;

    public LayerMask coinlayer;

    float coinSpeed = 80;

    float powerCounter;

    bool Magnet;

    float powerMagnet;
    float powerShield;

    bool Mortal = true;
    

    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {

        //used for shaking , to enhance code later after presentation
       
        //used for couting powerup duration
        if(powerCounter > 0)
            powerCounter -= Time.deltaTime;
        else
            PowerGrape(false);

        if (powerMagnet > 0)
        {
            powerMagnet -= Time.deltaTime;
            PowerLanternHelper();
        }

        if (powerShield > 0)
        {
            powerShield -= Time.deltaTime;
            //PowerShieldHelper();
        }
        else
        {
            transform.Find("Player Shield").gameObject.SetActive(false);
            Mortal = true;
        }
        
            


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject entity = other.gameObject;

        if (entity.tag == "Lizard" || entity.tag == "HoleCreature" || entity.tag == "SpikesSpinner" || entity.tag == "Spider")
            DecideEnemy(entity);
        else
        {
            if (entity.tag == "Coin")
            {
                Coin(entity);
                return;
            }
            else if (entity.tag == "Mushroom")
                Mushroom();
            else if (entity.tag == "Lantern")
                PowerLantern();
            else if (entity.tag == "Shield")
                PowerShield();
            else if (entity.tag == "Grape")
                PowerGrape(true);

             GameEntityManager.Instance.returnToPool(entity);
        }
    }




    public void DecideEnemy(GameObject entity)
    {
        if (Mortal)
            GameOver();
        else
            KillEnemy(entity);
    }

    public void GameOver()
    {
       GManager.instance.GameOver();
    }

    public void KillEnemy(GameObject entity)
    {
        //Kill Enemy;
        if (entity.tag == "Spider")
            entity.GetComponent<Renderer>().enabled = false;
        else
            GameEntityManager.Instance.returnToPool(entity);
        //Debug.Log("BE GONE ENEMY!");
    }

    public void Coin(GameObject coin)
    {
        coin.GetComponent<SpriteRenderer>().enabled = false;
        coin.GetComponent<PlaySFX>().playSound();
        GManager.instance.AddCoins();
    }

    public void Mushroom()
    {
        mainCamera.GetComponent<CameraShake>().shakeCam(shakeLength: 3.0f, amt: 10f);
    }

    public void PowerGrape(bool setPower)
    {
        if (setPower)
        {
            GManager.instance.ScoreMultiplier = 3;
            powerCounter = GManager.instance.PowerDuration;
        }
        else
            GManager.instance.ScoreMultiplier = 1;
    }

    public void PowerLantern()
    {
            powerMagnet = GManager.instance.PowerDuration;
    }
    
    public void PowerShield()
    {
        transform.Find("Player Shield").gameObject.SetActive(true);
        Mortal = false;
        powerShield = GManager.instance.PowerDuration;
    }

    public void PowerLanternHelper()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y),30,coinlayer);

        for(int i=0; i< cols.Length ; i++)
        {
            float magnetPower = 1 / (transform.position - cols[i].transform.position).magnitude;
            cols[i].gameObject.GetComponent<Transform>().position = Vector3.MoveTowards(cols[i].gameObject.GetComponent<Transform>().position, transform.position, Time.deltaTime * coinSpeed * magnetPower);
       }
         
    }


    public void PowerShieldHelper()
    {
        
    }

    public void Powerup()
    {
        Debug.Log("Powerup");
    }

}
