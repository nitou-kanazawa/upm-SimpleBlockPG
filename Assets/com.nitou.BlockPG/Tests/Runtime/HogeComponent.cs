using UnityEngine;

public class HogeComponent : MonoBehaviour
{
    public int count { get; private set; }

    void Start() {
        this.count = 1;
    }
}
