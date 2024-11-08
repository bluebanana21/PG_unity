using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public Vector3 playePosition;
    // Start is called before the first frame update
    public GameData()
    {
        playePosition = Vector3.zero;
    }
}
