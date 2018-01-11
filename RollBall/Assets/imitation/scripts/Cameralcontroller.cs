using UnityEngine;
using System.Collections;

public class Cameralcontroller : MonoBehaviour
{
    public GameObject players;
    private Vector3 offset;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - players.transform.position;

    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
