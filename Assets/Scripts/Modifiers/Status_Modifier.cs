using UnityEngine;

[CreateAssetMenu(fileName = "Status_Modifier", menuName = "SunnyLand/Status_Modifier", order = 0)]
public class Status_Modifier : ScriptableObject {
    public float Speed_Mod = 1;
    public float Gravity_Mod = 1;
    public string Name="";
    public float Modifier_Timer = 0;
    public bool using_mod;
    private void OnEnable() {
        using_mod = false;
    }
}