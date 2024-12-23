using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("Fruits Management")]
    public bool fruitsHaveRandomLook;
    public int fruitsCollected;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
    }

    public void AddFruit() => fruitsCollected++;
    public bool FruitsHaveRandomLook() => fruitsHaveRandomLook;
}