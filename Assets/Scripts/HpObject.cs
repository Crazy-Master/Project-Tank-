using UnityEngine;

public class HpObject : MonoBehaviour
{
    protected float _currentHpObject;
    [SerializeField]  protected float _maxHp = 100;
    [SerializeField] protected GameObject tankObject;

    public float HpObjectManager => _currentHpObject;
    

    public void Start()
    {
        _currentHpObject = _maxHp;
    }

    public virtual void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            Destroy(tankObject);
        }
    }
    public virtual void SetHeal(float heal)
        {
            _currentHpObject += heal;
            if (_currentHpObject > _maxHp)
            {
                _currentHpObject = _maxHp;
            }
        }
}
