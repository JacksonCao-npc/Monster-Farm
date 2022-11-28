using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : Enemy
{
    public float speed;
    public float startWaitTime;
    public float waitTime;
    public Transform movePos;
    public Transform leftDownPos;
    public Transform rightUpPos;
   

   

    public void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, movePos.position) < 0.1f)
        {

            if (waitTime <= 0)
            {
                movePos.position = GetRandomPos();
                waitTime = startWaitTime;
                
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    

    Vector2 GetRandomPos()
    {
        Vector2 randomPos = new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            leftDownPos.position.y);

        return randomPos;
    }
}
