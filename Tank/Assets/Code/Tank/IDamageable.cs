interface IDamageable
{
    int Armor { get; }
    void ReceiveDamage(int Damage);
    void Die();
}
