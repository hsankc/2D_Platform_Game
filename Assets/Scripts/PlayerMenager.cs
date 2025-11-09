using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TigerForge;
using UnityEngine.XR;
using Unity.VisualScripting;

public class PlayerMenager : MonoBehaviour
{
    
    public float health, bulletSpeed;

    public bool dead = false;
    
    Transform muzzle;

    public Transform bullet, floatingText, bloodParticle;

    public Slider slider;
    bool mouseIsNotOverUI;


    // Start is called before the first frame update
    void Start()
    {
        muzzle = transform.GetChild(1);

        slider.maxValue = health;

        slider.value = health;

        
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;


     if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    } 

    public void GetDamage(float damage)
    {
        Instantiate(floatingText , transform.position , quaternion.identity ).GetComponent<TextMesh>().text = damage.ToString();

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
               Destroy (Instantiate(bloodParticle,transform.position, quaternion.identity), 3f);
                DataMenager.Instance.LoseProcess();
                dead = true;
                SceneManager.LoadScene(0);
                

            }
        }

    }

     void ShootBullet()
    {
        Transform tempBullet;
        tempBullet =  Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        DataMenager.Instance.ShotBullet++;

    }
}
