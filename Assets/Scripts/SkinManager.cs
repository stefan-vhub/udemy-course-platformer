using System.Xml.Serialization;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public static SkinManager instance;
    public int choosenSkinId;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null) instance = this;
        else Destroy(instance);
    }

    public void SetSkinId(int id) => choosenSkinId = id;

    public int GetSkinId() => choosenSkinId;
}