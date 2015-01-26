using UnityEngine;
using System.Collections;

[System.Serializable]
public class DikDik : MonoBehaviour
{
    Renderer _renderer;

    public Texture2D _enslaved;
    public Texture2D _free;

    DikDikAI _ai;

    public enum SpriteType
    {
        enslaved,
        free
    }

    void Awake()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _ai = GetComponent<DikDikAI>();

        _ai.Init(this);
    }

    public void SetSprite(SpriteType spriteType)
    {
        switch (spriteType)
        {
            case SpriteType.enslaved:
                _renderer.material.SetTexture("_Texture", _enslaved);
                break;

            case SpriteType.free:
                _renderer.material.SetTexture("_Texture", _free);
                break;
        }
    }

    public void OnBeingLiberated()
    {
        _ai.OnBeingLiberated();
    }
}
