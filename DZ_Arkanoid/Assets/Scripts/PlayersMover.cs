using System;
using UnityEngine;

public class PlayersMover : MonoBehaviour
{
    [SerializeField] private Player _player1;
    [SerializeField] private Player _player2;

    private void Update()
    {
        if (_player1.IsActive)
        {
            PlayerInputChecker();
        }
    }

    private void PlayerInputChecker()
    {
        //Rigidbody.Drag не должно быть равно 0
        if (Input.GetKey(KeyCode.A))
        {
            PlayerMoving(_player1, Vector3.left, -1, true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerMoving(_player1, Vector3.right, 1, true);
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            PlayerMoving(_player1, Vector3.up, 1, false);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            PlayerMoving(_player1, Vector3.down, -1, false);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMoving(_player2, Vector3.left, 1, true);
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMoving(_player2, Vector3.right, -1, true);
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMoving(_player2, Vector3.up, 1, false);
        }
        
        if (Input.GetKey(KeyCode.DownArrow))
        {
            PlayerMoving(_player2, Vector3.down, -1 , false);
        }
    }

    private void PlayerMoving(Player player, Vector3 direction, int slideABS, bool isHorizontal)
    {
        var rigidbody = player.Rigidbody;
        var slide = player.Slide;
        player.transform.Translate(direction * Time.deltaTime);
        rigidbody.velocity = isHorizontal ? new Vector3(slide * slideABS, 0, 0) : new Vector3(0, slide * slideABS, 0);
    }
}