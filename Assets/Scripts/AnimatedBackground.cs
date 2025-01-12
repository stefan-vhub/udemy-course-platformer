using System.Xml.Serialization;
using UnityEngine;

public enum BackgroundType { Blue, Brown, Gray, Green, Pink, Purple, Yellow }

public class AnimatedBackground : MonoBehaviour
{
    [SerializeField] private Vector2 movementDirection;
    private MeshRenderer mash;

    [Header("Color")]
    [SerializeField] private BackgroundType backgroundType;
    [SerializeField] private Texture2D[] texture;

    private void Awake()
    {
        mash = GetComponent<MeshRenderer>();
        UpdateBackgorundTexture();
    }

    private void Update()
    {
        mash.material.mainTextureOffset += movementDirection * Time.deltaTime;
    }

    [ContextMenu("Update background")]
    private void UpdateBackgorundTexture()
    {
        if (mash == null) mash = GetComponent<MeshRenderer>();
        mash.sharedMaterial.mainTexture = texture[(int)backgroundType];
    }
}