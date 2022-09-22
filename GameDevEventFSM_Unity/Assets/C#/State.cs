using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public virtual void Enter(Miner _Miner) { }
    public virtual void Execute(Miner _Miner) { }
    public virtual void Exit(Miner _Miner) { }
}
