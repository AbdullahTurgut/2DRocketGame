using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Racket : MonoBehaviour
{
   

   
    public float moveSpeed = 10;
    public Text scoreText;
    public int Score { get; private set; }

    void Start()
    {
       
    }

    //rigidbody ile alakali isler yaptigimiz icin fixedupdate en iyi secim
    void FixedUpdate()
    {
        Movement();
    }
    //Miras vericeði için private olamaz Protected olabilir ve abstract yapýcaz
    protected abstract void Movement();

    public void scored()
    {
        //score deðerini arttýrdýk.
        Score++;
        //skoru textimizde gösterdik.
        scoreText.text = Score.ToString();
    }
}
