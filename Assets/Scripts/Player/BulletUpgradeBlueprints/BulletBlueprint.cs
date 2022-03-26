using UnityEngine;

[CreateAssetMenu]
public class BulletBlueprint : ScriptableObject
{
    // Start is called before the first frame update
    public string displayName;
    public Sprite displayImgSprite;
    public GameObject prefab;
    public bool isStackable;
    public int maxStacks;
    [Range(0, 2)]
    public float dmgMultiplier;
    [Range(0, 2)]
    public float movementSpeedMultiplier;
    public float cooldown;

}
