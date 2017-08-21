using UnityEngine;

public class Movement : MonoBehaviour
{
    public float actualSpeed, baseSpeed;
    public float fallSpeed;

    protected Attack atk;
    protected Health health;

    public enum Status:byte {stay = 0, move = 1, attack = 2 };
    public Status actualStatus;

    protected Animator anim;
    public enum AnimStatus : byte { idle = 0, move = 1, attack = 2}
    public AnimStatus actualAnimStatus;

    public virtual void Awake()
    {
        health = GetComponent<Health>();
        atk = GetComponent<Attack>();
        anim = GetComponent<Animator>();
        actualSpeed = baseSpeed;
    }
}
