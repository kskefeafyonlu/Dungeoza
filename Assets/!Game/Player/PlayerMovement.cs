using System;
using UnityEngine;

////////////////////////////////////////AGAM, ilkokul çocuğuna anlatırmış gibi yazdım kusuruma bakma <3/////////////////////////////////////////////
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;  //The base modifier for the players movement speed. -ksk
    private Vector2 inputDirection; //variable left for calculating the direction of the movement. -ksk (localize ettim ki optimize olsun)
    private Rigidbody2D playerRB; //fizik işlemleri için
    
//a

    private void Start() 
    {
        playerRB = GetComponent<Rigidbody2D>();  //burda şu anki objenin içinde Rigidbody2D arıyo ve bulduğunu playerRBye kaydediyo
    }


    private void FixedUpdate() 
    {
        Move();
    }


    private void Move()
    {
        inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            //Raw aldım çünkü movementta 
            //force ve sürtünme sistemi kullanıcam o yüzden zaten yumuşak olucak hareket

        playerRB.AddForce(inputDirection.normalized * movementSpeed);  
            //burda .normalized kullanınca o vektör 
            //birim vektör oluyo yani aslında sadece yön belirtiyo.. sonra da hız ile çarptım ki istediğimiz hızda gitsin
            //böylece hem vektörün büyüklüğü hızı etkilememiş de oldu yani <3
    }
}
