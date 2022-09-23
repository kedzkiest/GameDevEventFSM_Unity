using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class GoHomeAndSleepTilRested : State
{
    public static GoHomeAndSleepTilRested instance;

    private SingletonMessage SMI = SingletonMessage.Instance();

    private GoHomeAndSleepTilRested() { }

    public static GoHomeAndSleepTilRested Instance()
    {
        return instance;
    }

    public override void Enter(Miner _Miner)
    {
        if(_Miner.Location() != Miner.EnumLocationType.SHACK)
        {
            Debug.Log(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "( Walking home )");
        }

        _Miner.ChangeLocation(Miner.EnumLocationType.SHACK);
    }

    public override void Execute(Miner _Miner)
    {
        // if miner is not fatigued start to dig for nuggets again.
        if (_Miner.Fatigued())
        {
            // send a string to the setter of SingletonMessage
            SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " +
                        "What a fantastic nap! Time to find more gold");
            // cout << "\n" << str;

            // switch to next state
            _Miner.ChangeState(EnterMineAndDigForNugget.Instance());
        }

        else
        {
            // sleep
            _Miner.DecreaseFatigue();

            // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
            // send a string to the setter of SingletonMessage
            SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "ZZZZ... ");
            // cout << "\n" << str;
        }
    }

    public override void Exit(Miner _Miner)
    {
        SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "( Leaving the house )");
    }
}
