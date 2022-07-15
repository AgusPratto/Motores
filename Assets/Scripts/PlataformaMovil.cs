using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
   public GameObject ObjetoAmover;

   public Transform StartPoint;
   public Transform EndPoint;

   public float Velocidad;

   private Vector3 MoverHacia;


   //Plataforma Movil: Comienza en el StartPoint y avanza hasta EndPoint, cuando llega al final vuelve al punto anterior en forma de bucle
   
   void Start()
   {
    MoverHacia = EndPoint.position;
   }

   void Update()
   {
    ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, MoverHacia, Velocidad * Time.deltaTime);

    if(ObjetoAmover.transform.position == EndPoint.position)
   {
         MoverHacia = StartPoint.position;
   }

   if (ObjetoAmover.transform.position == StartPoint.position)
   {
         MoverHacia = EndPoint.position;
   }

   }
   
}
