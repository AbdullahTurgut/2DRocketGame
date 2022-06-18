using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : Racket
{
    //ball'ýn transform deðerleri lazým o yüzden 
    public Transform ball;
    //bu bizim yapay zeka kodumuz olucak 
    protected override void Movement()
    {
        //sað raket yapay zeka top belli bir mesafeye gelince hareketlenmesini istiyoruz bu yüzden 
        //bu kod bize sað raketle top arasýndaki dikey  mesafeyi vericektir.Abs Mutlak deðer
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
