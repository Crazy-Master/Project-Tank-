using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
   public GameObject brokenBoxWood;
   private void OnTriggerEnter2D(Collider2D other)
   {
      TankConlrollerIlya controller = other.GetComponent<TankConlrollerIlya>();

      if ( controller != null)
      {
         Instantiate(brokenBoxWood, transform.position, Quaternion.identity);
         Destroy(gameObject);
      }
   }
   
}
