using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIfDisabled : MonoBehaviour
{
   public bool SelfDestructionEnabled { get; set; } = false; //зачем { get; set; }

   private void OnDisable()
   {
      if (SelfDestructionEnabled)
      {
         Destroy((gameObject));
      }
   }
}
