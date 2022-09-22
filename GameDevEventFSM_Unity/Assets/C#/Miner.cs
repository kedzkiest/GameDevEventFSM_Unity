using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : BaseGameEntity
{
    public enum EnumLocationType
    {
        SHACK,
        GOLDMINE,
        BANK,
        SALOON
    };

    public Miner(int id): base(id) { }

    private State pCurrentState;
    private EnumLocationType enum_location;
    private int carried_gold_amount;
    private int money_in_bank;
    private int fatigue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
