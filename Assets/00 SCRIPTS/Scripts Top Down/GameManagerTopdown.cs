using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTopdown : SingleTon<GameManagerTopdown>
{
    [SerializeField] Transform _Player;
    public Transform Player => _Player;
}
