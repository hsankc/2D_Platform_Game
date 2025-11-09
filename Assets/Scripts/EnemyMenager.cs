using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMenager : MonoBehaviour

{

    public float health;
    public float damage;


    bool ColliderBusy=false; 

    public Slider slider;




    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D othher)
    {
        if (othher.tag == "Player" && !ColliderBusy)
        {
            ColliderBusy = true;
            othher.GetComponent<PlayerMenager>().GetDamage(damage);
        }

        else if (othher.tag == "Bullet")
        {
            GetDamage(othher.GetComponent<BulletMenager>().bulletDamage);
            Destroy(othher.gameObject);
        }
        
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag== "Player")
        {
            ColliderBusy = false;
        }
    }
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;
        }

        else
        {
            health = 0;
        }

        slider.value = health;

        AmIDead();

        

        void AmIDead()
        {
            if (health <= 0)
            {
                DataMenager.Instance.EnemyKilled++;
                Destroy(gameObject);
            }
        }

    }

   


}
