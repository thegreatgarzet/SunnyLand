using UnityEngine;

[CreateAssetMenu(fileName = "AnimHitBox", menuName = "AnimHitBox")]
public class AnimHitBox : ScriptableObject
{
    public HitBox[] HitBoxes;
    public string AnimationName;
}
[System.Serializable]
public struct HitBox{
    public Vector2 offset;
    public Vector2 size;
    public int frame;
    //DAMAGE WILL BE ADDED LATER, AS AN EXTRA SCRIPTABLE OBJECT
}