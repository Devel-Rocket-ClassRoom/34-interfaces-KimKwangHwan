using System;
using System.Collections.Generic;
using System.Text;

interface IAttacker
{
    int AttackPower { get; }
    void Attack(IDefender target);
}