using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour 
{

    [SerializeField] private float _sensivity;
    [SerializeField] private float _speed;
    [SerializeField] private int minX_Position;
	[SerializeField] private int maxX_Position;


	private Rigidbody _rigidbody;
	private Vector2 _firstTouch;
	private Vector2 _currentTouch;
	private float _finalTouch;
	private float _deltaThreshold;
	
	// получаем ригидбоди
	void Start () 
	{
		
		_rigidbody = GetComponent<Rigidbody>();
		ResetValues();
	
	}
	
	//двигаемся по x влево-вправо
	void Update () 
	{
	
		HandleMovmentSlide();
		
	}

	//просто движемся прямо
    private void FixedUpdate()
    {
		
		MoveToForward();

	}
    
	//движемся вперёд
	private void MoveToForward()
	{
		
		_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speed * Time.fixedDeltaTime);
	
	}
	
	
	
	
	//движение по x с помощью слайда 
	private void HandleMovmentSlide()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_firstTouch = Input.mousePosition;

		}
		if (Input.GetMouseButton(0))
		{
			_currentTouch = Input.mousePosition;
			Vector2 touchDelta = (_currentTouch - _firstTouch);

			if (_firstTouch == _currentTouch)
			{
				_rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _rigidbody.velocity.z);
			}

			_finalTouch = transform.position.x;

			if (Mathf.Abs(touchDelta.x) >= _deltaThreshold)
			{
				_finalTouch = (transform.position.x + (touchDelta.x * _sensivity));
			}

			_rigidbody.position = new Vector3(_finalTouch, transform.position.y, transform.position.z);
			_rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, minX_Position, maxX_Position), _rigidbody.position.y, _rigidbody.position.z);

		}
		if (Input.GetMouseButtonUp(0))
        {
			ResetValues();
        }
	}
	
	//перезагрузка значений
	private void ResetValues() 
	{ 
		_rigidbody.velocity = new Vector3(0f,_rigidbody.velocity.y, _rigidbody.velocity.z);
		_firstTouch = Vector2.zero;
		_finalTouch = 0f;
		_currentTouch = Vector2.zero;
	}
}
