using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BaseGameEntity : MonoBehaviour
{
    private int entity_id;
    private static int next_valid_id = 0;

    public BaseGameEntity(int id)
    {
        SetID(id);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public int GetID()
    {
        return entity_id;
    }

    private void SetID(int id)
    {
        // make sure the id is equal to or greater than the next available ID
        Assert.IsFalse(id >= next_valid_id, "<BaseGameEntity::SetID>: invalid ID");

        entity_id = id;
        next_valid_id = entity_id + 1;
    }
}
