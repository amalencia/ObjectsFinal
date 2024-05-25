using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputFinal : MonoBehaviour
{
    private ShipPlayerParent myPlayer;
    private Vector2 direction;
    private float angleToRotate;

    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<ShipPlayerParent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myPlayer.Attack();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        angleToRotate = Mathf.Atan2(direction.y - transform.position.y, direction.x - transform.position.x) * Mathf.Rad2Deg;


        myPlayer.Move(new Vector2(horizontalInput, verticalInput), angleToRotate-90);
    }
}
