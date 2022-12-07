using System;

namespace CardWeaponBattle;

internal abstract class WeaponDamage
{
    public const int BASE_DAMAGE = 3;
    public const int FLAME_DAMAGE = 2;

    public WeaponDamage(int startingRoll)
    {
        roll = startingRoll;
        CalculateDamage();
    }

    private int roll;
    private bool flaming;
    private bool magic;

    public int Roll
    {
        get { return roll; }
        set
        {
            roll = value;
            CalculateDamage();
        }
    }

    /// <summary>
    /// true - если оружие огненное, false - в противном случае
    /// </summary>
    public bool Flaming
    {
        get { return flaming; }
        set
        {
            flaming = value;
            CalculateDamage();
        }
    }

    /// <summary>
    /// true - если оружие огненное, false - в противном случае
    /// </summary>
    public bool Magic
    {
        get { return magic; }
        set
        {
            magic = value;
            CalculateDamage();
        }
    }

    /// <summary>
    /// Содержит суммированный урон
    /// </summary>
    public int Damage { get; protected set; }

    public abstract void CalculateDamage();

}
