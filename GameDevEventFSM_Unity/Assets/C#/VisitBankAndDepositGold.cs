using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class VisitBankAndDepositGold : State
{
    private static VisitBankAndDepositGold instance = new VisitBankAndDepositGold();

    private SingletonMessage SMI = SingletonMessage.Instance();

    private VisitBankAndDepositGold() { }

    public static VisitBankAndDepositGold Instance()
    {
        return instance;
    }

    public override void Enter(Miner _Miner)
    {
        // on entry the miner makes sure he is located at the bank
        if (_Miner.Location() != Miner.EnumLocationType.BANK)
        {
            // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
            // cout << "\n"
            //      << GetNameOfEntity(pMiner->GetID()) << ": "
            //      << "Going to the bank";
            SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "( Going to the bank )");
            _Miner.ChangeLocation(Miner.EnumLocationType.BANK);
        }
    }

    public override void Execute(Miner _Miner)
    {
        // deposit the gold
        _Miner.AddToWealth(_Miner.GoldCarried());

        _Miner.SetGoldCarried(0);

        // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
        SMI.AddVal(
            BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " +
            "( Depositing gold. Total savings now: " + _Miner.Wealth() + " )");
        // cout << "\n" << GetNameOfEntity(pMiner->GetID()) << ": "
        //      << "Depositing gold. Total savings now: "<< pMiner->Wealth();
        // cout << "\n" << str;

        // wealthy enough to have a well earned rest?
        if (_Miner.Wealth() >= Miner.comfort_level)
        {
            // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
            // cout << "\n"
            //      << GetNameOfEntity(pMiner->GetID()) << ": "
            //      << "WooHoo! Rich enough for now. Back home to my lady!";
            SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " +
                        "WooHoo! Rich enough for now. Back home to my lady!");
            _Miner.ChangeState(GoHomeAndSleepTilRested.Instance());
        }

        // otherwise get more gold
        else
        {
            _Miner.ChangeState(EnterMineAndDigForNugget.Instance());
        }
    }

    public override void Exit(Miner _Miner)
    {
        // SetTextColor(FOREGROUND_RED| FOREGROUND_INTENSITY);
        // cout << "\n"
        //      << GetNameOfEntity(pMiner->GetID()) << ": "
        //      << "Leaving the bank";
        SMI.AddVal(BaseGameEntity.GetNameOfEntity(_Miner.GetID()) + ": " + "( Leaving the bank )");
    }
}
