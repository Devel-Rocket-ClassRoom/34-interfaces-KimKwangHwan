using System;

{
    Car car = new Car();
    car.Go();
}
{
    Person person = new Person();
    person.Work();
    person.Rest();
}

{
    Car2 car1 = new Car2(new GoodBattery());
    car1.Run();

    Car2 car2 = new Car2(new NormalBattery());
    car2.Run();
}

{
    Dog dog = new Dog();
    dog.Eat();
    dog.Bark();
}

{
    Bird bird = new Bird(); 
    bird.Breathe();
    bird.Fly();
}

{
    Pet pet = new Pet();

    ((IDog)pet).Eat();
    ((ICat)pet).Eat();

    IDog dog = new Pet();
    dog.Eat();

    ICat cat = new Pet();
    cat.Eat();
}

{
    Example ex = new Example();

    IExample iex = ex;
    iex.DoWork();
}

{
    TextEditor editor = new TextEditor();
    editor.Undo();
    editor.Redo();
}

{
    Car3 car = new Car3();
    car.Run();
    car.Left();
    car.Back();
}

{
    Player player = new Player();
    Enemy enemy = new Enemy();  
    Building building = new Building();

    Attack(player, 20);
    Attack(enemy, 30);
    Attack(building, 100);
}

{
    Hero hero = new Hero();
    hero.Move();
    hero.Attack();

    Turret turret = new Turret();
    turret.Attack();
}

void Attack(IDamageable target, int damage)
{
    target.TakeDamage(damage);
}

interface ICar
{
    void Go();
}

class Car : ICar
{
    public void Go()
    {
        Console.WriteLine("자동차가 달립니다.");
    }
}

interface IRepository
{
    void Get();
}

class Repository : IRepository
{
    public void Get()
    {
        Console.WriteLine("데이터를 가져옵니다.");
    }
}

interface IPerson
{
    void Work();
    void Rest();
}

class Person : IPerson
{
    public void Work()
    {
        Console.WriteLine("일을 합니다.");
    }

    public void Rest()
    {
        Console.WriteLine("휴식을 취합니다.");
    }
}

interface IBattery
{
    string GetName();
}

class GoodBattery : IBattery
{
    public string GetName()
    {
        return "고급 배터리";
    }
}

class NormalBattery : IBattery
{
    public string GetName()
    {
        return "일반 배터리";
    }
}

class Car2
{
    private IBattery _battery;
    public Car2(IBattery battery)
    {
        _battery = battery;
    }

    public void Run()
    {
        Console.WriteLine($"{_battery.GetName()}를 장착한 자동차가 달립니다.");
    }
}

interface IAnimal
{
    void Eat();
}

interface IDog2
{
    void Bark();
}

class Dog : IAnimal, IDog2
{
    public void Eat()
    {
        Console.WriteLine("먹습니다.");
    }

    public void Bark()
    {
        Console.WriteLine("짖습니다.");
    }
}

interface IFlyable
{
    void Fly();
}

class Animal
{
    public void Breathe()
    {
        Console.WriteLine("숨을 쉽니다.");
    }
}

class Bird : Animal, IFlyable
{
    public void Fly()
    {
        Console.WriteLine("날아갑니다.");
    }
}

interface IDog
{
    void Eat();
}

interface ICat
{
    void Eat();
}

class Pet : IDog, ICat
{
    void IDog.Eat()
    {
        Console.WriteLine("개처럼 먹습니다.");
    }

    void ICat.Eat()
    {
        Console.WriteLine("고양이처럼 먹습니다.");
    }
}

interface IExample
{
    void DoWork();
}

class Example : IExample
{
    void IExample.DoWork()
    {
        Console.WriteLine("작업 수행");
    }
}

interface IUndoable
{
    void Undo();
}

interface IRedoable : IUndoable
{
    void Redo();
}

class TextEditor : IRedoable
{
    public void Undo()
    {
        Console.WriteLine("실행 취소");
    }

    public void Redo()
    {
        Console.WriteLine("다시 실행");
    }
}

interface IStandard
{
    void Run();
}

abstract class Vehicle
{
    public abstract void Back();

    public void Left()
    {
        Console.WriteLine("좌회전");
    }
}

class Car3 : Vehicle, IStandard
{
    public override void Back()
    {
        Console.WriteLine("후진");
    }

    public void Run()
    {
        Console.WriteLine("전진");
    }
}

interface IDamageable
{
    int Health { get; }
    void TakeDamage(int damage);
}

class Player : IDamageable
{
    public int Health { get; private set; } = 100;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"플레이어가 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

class Enemy : IDamageable
{
    public int Health { get; private set; } = 50;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"적이 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

class Building : IDamageable
{
    public int Health { get; private set; } = 500;
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"건물이 {damage} 대미지를 받음. 남은 체력: {Health}");
    }
}

interface IMovable
{
    void Move();
}

interface IAttackable
{
    void Attack();
}

class Hero : IMovable, IAttackable
{
    public void Move()
    {
        Console.WriteLine("영웅이 이동합니다.");
    }

    public void Attack()
    {
        Console.WriteLine("영웅이 공격합니다.");
    }
}

class Turret : IAttackable
{
    public void Attack()
    {
        Console.WriteLine("포탑이 발사합니다.");
    }
}