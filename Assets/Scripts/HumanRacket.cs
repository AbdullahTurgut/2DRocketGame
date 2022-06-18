using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//HumanRacket clasýný Racket'den türettik
public class HumanRacket : Racket
{
    Rigidbody2D rb;

    public string axisName = "Vertical1";

    //hareket etme kodumuz buydu Bu kod racket içinde fixedUpdate'de çalýþtýrýlcaðý için sorun olmuycak
    protected override void Movement()
    {
        float moveAxis = Input.GetAxis(axisName) * moveSpeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, moveAxis);
    }
}
