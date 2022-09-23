using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnterMineAndDigForNugget : State
{
    public static EnterMineAndDigForNugget instance;

    private SingletonMessage SMI = SingletonMessage.Instance();

    private EnterMineAndDigForNugget() { }

    public static EnterMineAndDigForNugget Instance()
    {
        return instance;
    }

    public override void Enter(Miner _Miner)
    {
        // if the miner is not already located at the goldmine, he must
        // change location to the gold mine
        if (_Miner.Location() != Miner.EnumLocationType.GOLDMINE)
        {
            // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
            // cout << "\n"
            //      << GetNameOfEntity(pMiner->GetID()) << ": "
            //      << "Walking to the goldmine";
            SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " +
                        "( Walking to the goldmine )");
            _Miner.ChangeLocation(Miner.EnumLocationType.GOLDMINE);
        }
    }

    public override void Execute(Miner _Miner)
    {
        // the miner digs for gold until he is carrying in excess of max_nuggets.
        // If he gets thirsty during his digging he packs up work for a while and
        // changes state to go to the saloon for a whiskey.
        _Miner.AddToGoldCarried(1);

        _Miner.IncreaseFatigue();

        // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
        SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "( Picking up a nugget )");
        // cout << "\n" << GetNameOfEntity(pMiner->GetID()) << ": " << "Pickin' up a
        // nugget";
        // cout << "\n" << str;

        // if enough gold mined, go and put it in the bank
        if (_Miner.PocketsFull())
        {
            _Miner.ChangeState(VisitBankAndDepositGold.Instance());
        }

        // if (pMiner->Thirsty()) {
        //   pMiner->ChangeState(QuenchThirst::Instance());
        // }
    }

    public override void Exit(Miner _Miner)
    {
        // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
        // cout << "\n"
        //      << GetNameOfEntity(pMiner->GetID()) << ": "
        //      << "Leaving the goldmine with full of sweet gold!";
        SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " +
                    "Leaving the goldmine with full of sweet gold!");
    }
}
