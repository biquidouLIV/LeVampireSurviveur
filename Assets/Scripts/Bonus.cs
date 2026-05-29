using System;
using UnityEngine;

public abstract class Bonus : MonoBehaviour
{
    public Spell spellToGive;

    public PlayerController player;

    public void Selection()
    {
        if (true  /*le player il a le spell la*/)
        {
            /*niveau du spell +1*/
        }
        else
        {
            /*le joueur obtient le spell*/
        }
    }
}
