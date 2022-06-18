using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float moveSpeed=5;

    //Racket adlý scriptteki sol ve sað racketlere ulaþmak için
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
        //duvara çarpmadan hemen önce ses çýkmasý için
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
            // a deðiþkeni için topun pozisyonunun y'sinden sol rakete çarpýtðý yerdeki y'yi çýkardýk.

            //float a = transform.position.y - collision.gameObject.transform.position.y;
            // b içinde sol raketin yüksekliðini almamýz gerekicek oda 
            //collisin topun çarptýðý sol raket anlamýna geliyordu colliderinin size'ýnýn y'si yüksekliðini vericek
            //float b = collision.collider.bounds.size.y;

            //float y = a / b;

            //float x = 1; // x = 1 dediðimiz aslýnda Sol rakete çarpan topun x'in +1 yönünde gitmesi lazým olduðu için 
            // bu sað rakette -1 olucak.

            //rb.velocity = new Vector2(x, y);
            //bu kodlarý bir fonksiyon yapýp çaðýrýcaz 
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
