using System;

Character hero = new Character("용사");
Monster slime = new Monster("슬라임", 30, 5);

Console.WriteLine($"=== 전투 시작 ===\n");

while(!hero.IsDead && !slime.IsDead)
{
    ProcessBattle(hero, slime);
    if (!slime.IsDead)
    {
        ProcessBattle(slime, hero);
    }
}

Console.WriteLine($"\n=== 고블린 등장 ===\n");

Monster goblin = new Monster("고블린", 50, 10);

while (!hero.IsDead && !goblin.IsDead)
{
    ProcessBattle(hero, goblin);
    if (!goblin.IsDead)
    {
        ProcessBattle(goblin, hero);
    }
}

void ProcessBattle(IAttacker attacker, IDefender defender)
{
    attacker.Attack(defender);
}