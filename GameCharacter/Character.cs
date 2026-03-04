using System;
using System.Collections.Generic;
using System.Text;

class Character : IAttacker, IDefender
{
    private int _currentHp;
    public Character(string name)
    {
        Name = name;
        _currentHp = MaxHp;
    }
    public string Name { get; private set; }

    public int AttackPower { get; private set; } = 20;

    public int CurrentHp
    {
        get
        { return _currentHp; }
        set
        {
            _currentHp = value;
            if (_currentHp < 0)
            {
                _currentHp = 0;
                IsDead = true;
            }
            if (_currentHp > MaxHp)
                _currentHp = MaxHp;
        }
    }
    public int MaxHp { get; private set; } = 100;

    public bool IsDead { get; private set; } = false;

    public void Attack(IDefender target)
    {
        Console.Write($"{Name}(이/가) ");
        target.TakeDamage(AttackPower);
    }

    public void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        Console.WriteLine($"{Name}에게 {damage} 대미지! ({Name} HP: {CurrentHp}/{MaxHp})");
        if (IsDead)
        {
            Console.WriteLine($"{Name}(이/가) 쓰러졌습니다!");
        }
    }
}