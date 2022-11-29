using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public  int damage;
    public float attackDuration;
    public float attackStartTime;

    private Animator anime;
    private PolygonCollider2D hitBox;
    // Start is called before the first frame update
    void Start()
    {   
        anime = GetComponentInParent<Animator>();
        hitBox = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        
    }
    void Attack()
    {
        if (GameController.playerIsAlive==true)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                
                anime.SetTrigger("Attack");
                StartCoroutine(StartAttack());
            }
        }

    }
    IEnumerator StartAttack()
        
    {
        yield return new WaitForSeconds(attackStartTime);
        hitBox.enabled = true;
        
        StartCoroutine(DisableHitBox());
    }
    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(attackDuration);
        hitBox.enabled = false;
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakenDamage(damage);
        }
    }

}
