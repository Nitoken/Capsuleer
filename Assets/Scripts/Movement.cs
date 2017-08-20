using UnityEngine;

public class Movement : MonoBehaviour
{
    public float actualSpeed, baseSpeed;
    public float fallSpeed;
    public enum Status:byte {stay = 0, move = 1, attack = 2 };
    public Status actualStatus;
}
