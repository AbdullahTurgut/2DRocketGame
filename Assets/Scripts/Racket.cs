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
    //Miras verice�i i�in private olamaz Protected olabilir ve abstract yap�caz
    protected abstract void Movement();

    public void scored()
    {
        //score de�erini artt�rd�k.
        Score++;
        //skoru textimizde g�sterdik.
        scoreText.text = Score.ToString();
    }
}
