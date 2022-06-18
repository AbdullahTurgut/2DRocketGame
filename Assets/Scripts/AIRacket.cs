using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : Racket
{
    //ball'�n transform de�erleri laz�m o y�zden 
    public Transform ball;
    //bu bizim yapay zeka kodumuz olucak 
    protected override void Movement()
    {
        //sa� raket yapay zeka top belli bir mesafeye gelince hareketlenmesini istiyoruz bu y�zden 
        //bu kod bize sa� raketle top aras�ndaki dikey  mesafeyi vericektir.Abs Mutlak de�er
        float distance = Mathf.Abs(ball.position.y - transform.position.y);

        if(distance > 2)
        {
            if (ball.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
        }

        
    }
}
