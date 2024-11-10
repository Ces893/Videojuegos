using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    [SerializeField] private Transform controldorGolpe;

    [SerializeField] private float radioGolpe;

    [SerializeField] private int daño;

    [SerializeField] private float tiemporAtaque;

    [SerializeField] private float tiempoSiguenteAtaque;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (tiempoSiguenteAtaque > 0) { 
            tiempoSiguenteAtaque -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && tiempoSiguenteAtaque <=0)
        {
            Golpe();
            tiempoSiguenteAtaque = tiemporAtaque;
        }
    }
    private void Golpe() {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controldorGolpe.position, radioGolpe);

        foreach (Collider2D collisionador in objetos) {
            if (collisionador.CompareTag("Enemigo")) {
                EnemigoSlime slime = collisionador.transform.GetComponent<EnemigoSlime>();
                if (slime != null)
                {
                    slime.TomarDaño(daño);
                }

                Enemigo2D enemigo2D = collisionador.transform.GetComponent<Enemigo2D>();
                if (enemigo2D != null)
                {
                    enemigo2D.TomarDaño(daño);
                }
            }
        }
    }

   private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controldorGolpe.position, radioGolpe);
   }

}
