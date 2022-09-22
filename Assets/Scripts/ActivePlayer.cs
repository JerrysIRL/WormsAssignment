using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class ActivePlayer : MonoBehaviour
{
    private ActivePlayerMannager manager;

    public void AssignManager(ActivePlayerMannager theManager)
    {
        manager = theManager;
    }
}
