using System;

public interface IDamageable
{ 
  public event Action DamageRecived;
  public event Action<int> HealthChanged;
  
  void TakeDamage(int damage);
}
