using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;

    public int currentHealth;
    public int maxHealth;

    public HealthBar healthbar;


    public float invicibleLength; 
    private float invincibleCounter;

    private SpriteRenderer sr;

    //new
    Vector2 checkPoint;
      
   
   

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        sr = GetComponent<SpriteRenderer>();

        checkPoint = transform.position; //new
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if (invincibleCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.b, sr.color.g, 1f);
            }
           
        }

    }

   public void DealDamage()
    {

        if (invincibleCounter <= 0)
        {






            //currentHealth = currentHealth - 1;
            currentHealth--;
            healthbar.SetHealth(currentHealth);


            if (currentHealth <= 0)
            {
                // gameObject.SetActive(false);
                Die();
               

            }
            else
            {
                invincibleCounter = invicibleLength;
                sr.color = new Color(sr.color.r, sr.color.b, sr.color.g, 0.5f);
                
            }

        }
    }

   public void UpdateCheckPoint(Vector2 pos)
    {
        checkPoint = pos;
    }


   void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        
        
        transform.position = checkPoint;
    }
   
}
