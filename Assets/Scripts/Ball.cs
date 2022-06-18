using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed=5;

    //Racket adl� scriptteki sol ve sa� racketlere ula�mak i�in
    public Racket lRacket, rRacket;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(1, 0) * moveSpeed;
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagManager tagManager = collision.gameObject.GetComponent<TagManager>();
        //duvara �arpmadan hemen �nce ses ��kmas� i�in
        GetComponent<AudioSource>().Play();
        
        if (tagManager == null) return;
        Tag tag = tagManager.myTag;

        if(tag.Equals(Tag.left_wall))
        {
            //right racket scored
            rRacket.scored();
        }
        else if(tag.Equals(Tag.right_wall))
        {
            //left racket scored
            lRacket.scored();
        }

        if (tag.Equals(Tag.left_racket))
        {
            // a de�i�keni i�in topun pozisyonunun y'sinden sol rakete �arp�t�� yerdeki y'yi ��kard�k.

            //float a = transform.position.y - collision.gameObject.transform.position.y;
            // b i�inde sol raketin y�ksekli�ini almam�z gerekicek oda 
            //collisin topun �arpt��� sol raket anlam�na geliyordu colliderinin size'�n�n y'si y�ksekli�ini vericek
            //float b = collision.collider.bounds.size.y;

            //float y = a / b;

            //float x = 1; // x = 1 dedi�imiz asl�nda Sol rakete �arpan topun x'in +1 y�n�nde gitmesi laz�m oldu�u i�in 
            // bu sa� rakette -1 olucak.

            //rb.velocity = new Vector2(x, y);
            //bu kodlar� bir fonksiyon yap�p �a��r�caz 
            DonusYonHesapla(collision, 1);
        }
        else if (tag.Equals(Tag.right_racket))
        {
            DonusYonHesapla(collision,-1);
        }
    }

    private void DonusYonHesapla(Collision2D collision, int x)
    {
        float a = transform.position.y - collision.gameObject.transform.position.y;
        float b = collision.collider.bounds.size.y;
        float y = a / b;
        rb.velocity = new Vector2(x, y) * moveSpeed;
    }
}
