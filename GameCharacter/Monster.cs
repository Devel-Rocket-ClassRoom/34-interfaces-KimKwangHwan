using System;
using System.Collections.Generic;
using System.Text;

class Monster : IAttacker, IDefender
{
    private int _currentHp;
    public Monster(string name, int maxHp, int attackPower)
    {
        Name = name;
        AttackPower = attackPower;
        MaxHp = maxHp;
        _currentHp = MaxHp;
    }
    public string Name { get; private set; }

    public int AttackPower { get; private set; }

    public int CurrentHp
    {
        get
        { return _currentHp; }
        set
        {
            _currentHp = value;
            if (_currentHp <= 0)
            {
                _currentHp = 0;
                IsDead = true;
            }
            if (_currentHp > MaxHp)
                _currentHp = MaxHp;
        }
    }
    public int MaxHp { get; private set; }

    public bool IsDead { get; private set; } = false;

    public void Attack(IDefender target)
    {
        Console.Write($"{Name}(이/가) {target}에게 {AttackPower} 대미지! ");
        target.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        Console.WriteLine($"({Name} HP: {CurrentHp}/{MaxHp})");
        if (IsDead)
        {
            Console.WriteLine($"{Name}(이/가) 쓰러졌습니다!");
        }
    }

    public override string ToString()
    {
        return Name;
    }
}