using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
    
{
    private GameObject[] multiEnemys;
    public Transform closestEnemy;
    public bool enemyContact;
    public GameObject bulletPrefab;
    public GameObject player;
    public float shootingSpeed;
    public Vector3 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        closestEnemy = null;
        enemyContact = false;
        playerPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        closestEnemy = GetClosestEnemy();
        closestEnemy.gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1, 0.7f, 0.1f);
        bulletPrefab.transform.position = closestEnemy.position - player.transform.position;
        if(Input.anyKeyDown)
        {
            ButtonToShoot();
        }
    }

    Vector3 BulletPostion()
    {
        Vector3 shootingToward= closestEnemy.position - player.transform.position;
        return shootingToward;
    }
    public Transform GetClosestEnemy()
    {
        multiEnemys = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDisntance = Mathf.Infinity;
        Transform trans = null;

        foreach(GameObject go in multiEnemys)
        {
            float currentDistance;
            currentDistance = Vector3.Distance(transform.position, go.transform.position);
            if(currentDistance<closestDisntance)
            {
                closestDisntance = currentDistance;
                trans = go.transform;
            }
        }
        return trans;
    }

    public void ButtonToShoot()
    {
        Instantiate<GameObject>(bulletPrefab,playerPos,bulletPrefab.transform.rotation);
        bulletPrefab.transform.Translate(BulletPostion() * shootingSpeed * Time.deltaTime);
        
            
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colliteWith = collision.gameObject;
        if(colliteWith.tag=="Enemy")
        {
            Destroy(colliteWith);
        }
    }
}
