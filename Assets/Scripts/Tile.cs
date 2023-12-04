using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public enum Type {Ground,Wall}

    [SerializeField]
    private Type type;

    public Type getType()
    {
        return type;
    }
}
