using UnityEngine;

public class ObstacleMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    
    private float _speed;

    private bool _canMove;
    
    public void SetSpeed(float speed)
    {   
        if (speed < 0)
        {   
            _speed = 0;
            return;
        }
       
        _speed = speed;
        _canMove = true;
    }


    private void FixedUpdate()
    {
        if (!_canMove)
        {
            return;
        }
        
        Move();
    }

    public void Move()
    {
        var nextPosition = transform.position + Vector3.down * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(nextPosition);
    }
}
