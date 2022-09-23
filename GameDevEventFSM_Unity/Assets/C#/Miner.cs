using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

public class Miner : BaseGameEntity
{
    public static readonly int comfort_level = 5;
    public static readonly int max_nuggets = 3;
    public static readonly int tiredness_threshold = 5;

    public enum EnumLocationType
    {
        SHACK,
        GOLDMINE,
        BANK,
        SALOON
    };

    private State CurrentState;
    private EnumLocationType enum_location;
    private int carried_gold_amount;
    private int money_in_bank;
    private int fatigue;


    public Miner(int id) : base(id)
    {
        enum_location = EnumLocationType.SHACK;
        carried_gold_amount = 0;
        money_in_bank = 0;
        fatigue = 0;
        CurrentState = GoHomeAndSleepTilRested.Instance();
    }

    public override void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Execute(this);
        }
    }

    public void ChangeState(State NewState)
    {
        // make sure both states are both valid before attempting to
        // call their methods
        Assert.IsFalse(CurrentState != null && NewState != null, "current state or new state is invalid.");

        // call the exit method of the existing state
        CurrentState.Exit(this);

        // change state to the new state
        CurrentState = NewState;

        // call the entry method of the new state
        CurrentState.Enter(this);
    }

    public EnumLocationType Location()
    {
        return enum_location;
    }

    public void ChangeLocation(EnumLocationType loc)
    {
        enum_location = loc;
    }

    public int GoldCarried()
    {
        return carried_gold_amount;
    }

    public void SetGoldCarried(int val)
    {
        carried_gold_amount = val;
    }

    public void AddToGoldCarried(int val)
    {
        carried_gold_amount += val;

        if (carried_gold_amount < 0)
        {
            carried_gold_amount = 0;
        }
    }

    public bool PocketsFull()
    {
        return carried_gold_amount >= max_nuggets;
    }

    public bool Fatigued()
    {
        if(fatigue > tiredness_threshold)
        {
            return true;
        }

        return false;
    }

    public void DecreaseFatigue()
    {
        fatigue -= 1;
    }

    public void IncreaseFatigue()
    {
        fatigue += 1;
    }

    public int Wealth()
    {
        return money_in_bank;
    }

    public void SetWealth(int val)
    {
        money_in_bank = val;
    }

    public void AddToWealth(int val)
    {
        money_in_bank += val;

        if (money_in_bank < 0)
        {
            money_in_bank = 0;
        }
    }
}
