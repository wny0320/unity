using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour, IMove
{
    GameObject player;
    Vector3 PlayerPos;
    IMove move;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        PlayerPos = this.transform.position;
        move = GetComponent<IMove>();
    }
    void IMove.Move(Vector3 PlayerPos_)
    {
        PlayerPos_ = this.player.transform.position;
        transform.position = new Vector3 (PlayerPos_.x, PlayerPos_.y, transform.position.z);
    }
    // Update is called once per frame
    void Update()
    {
        move.Move(PlayerPos);
    }
}
