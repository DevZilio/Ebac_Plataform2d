using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
   public Action OnKill;
   
   public int startLife = 10;

   public bool destroyOnKill = false;
   public float delayToKill;

   private int _currentLife;
   private bool _isDead = false;

   public FlashColor flashColor;



   private void Awake() {
       Init();
       if(flashColor == null)
       {
           flashColor = GetComponent<FlashColor>();
       }
   }

   public void SetCurrentLife(int currentLife)
   {
       _currentLife = currentLife;
   }

   private void Init(){
       _isDead = false;
       _currentLife = startLife;

   }

   public void Damage(int damage)
   {
       if (_isDead) return;                 // se o personagem estiver morto, a funcao para por aqui e nem executa o resto

       _currentLife -= damage;

       if (_currentLife <= 0)
       {
           Kill();

       }

       if(flashColor != null)
       {
           flashColor.Flash();
       }

        ItemManager.Instance.LossHearts();
   }

   private void Kill()
   {
       _isDead = true;

       if(destroyOnKill)
       {
          Destroy(gameObject, delayToKill); 
       }
          OnKill?.Invoke();
          //Usar o ? é o mesmo que fazer if(Onkill != null)
   }

}
