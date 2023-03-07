using UnityEngine;

public class HpObject : MonoBehaviour, IHpObject
{
    protected float _currentHpObject;
    [SerializeField]  protected float _maxHp = 100;
    [SerializeField] protected GameObject _gameObject;


    public void Start()
    {
        _currentHpObject = _maxHp;
    }

    public float CurrentHpObject()
    {
        return _currentHpObject;
    }

    public virtual void SetDamage(float damage)
    {
        _currentHpObject -= damage;
        if (_currentHpObject <= 0)
        {
            Destroy(_gameObject);
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
