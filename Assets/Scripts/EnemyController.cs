using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    public int totalHealth = 3;
    public int health;
    public float interval = 1f;

    private SpriteRenderer renderer;
    

    public static UnityEvent enemyKilled = new UnityEvent();
    public static UnityEvent enemyLived = new UnityEvent();

    void Start()
    {
        health = totalHealth;
        renderer = GetComponent<SpriteRenderer>();
    }

  
    void Update()
    {
        if (health <= 0)
        {
            gameObject.SetActive(false);
        } 
    }

    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Attack2"))
        {
            AddDamage();
            enemyLived.Invoke();

        } else if (collision.CompareTag("Attack1"))
        {
            gameObject.SetActive(false);
            enemyKilled.Invoke();
        }
    }

    public void AddDamage()
    {
        health--;

        StartCoroutine("VisualFeedback");
    }

    private IEnumerator VisualFeedback()
    {
        renderer.color = Color.blue;

        yield return new WaitForSeconds(0.5f);

        renderer.color = Color.white;
    }
    

  
    

    

    
}
