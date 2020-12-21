using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
	public Transform Target; 
	public List<Transform> Waypoints;

	public float MovementSpeed = 5.0f;

	private int _currentWaypointIndex = 0;
	public float WaitAtWaypointTime = 2.5f;

	public bool ShouldLoop = true;

	private float _timer = 0.0f;

	[SerializeField] private bool _shouldMove = true;

	private void Awake()
	{
		//javna varijabla za index pocetne pozicije ako zelimo mijenjati u inspectoru
		Target.position = Waypoints[0].position;
	}

	private void Update()
	{
		if (Target == null)
			return;

		if ((_shouldMove) && (Time.time >= _timer))
			MovePlatformTowardsCurrentWaypoint();
	}

	private void MovePlatformTowardsCurrentWaypoint()
	{
		Target.position = Vector3.MoveTowards(Target.position, Waypoints[_currentWaypointIndex].position, MovementSpeed * Time.deltaTime);

		float distance = Vector3.Distance(Target.position, Waypoints[_currentWaypointIndex].position);

		if (distance <= 0.0f)
		{
			_currentWaypointIndex++;
			_timer = Time.time + WaitAtWaypointTime;

			//index ide od 0 (N-1), a count vraća N
			if (_currentWaypointIndex >= Waypoints.Count)
			{
				if (ShouldLoop)
					_currentWaypointIndex = 0;
				else
					_shouldMove = false;

			}


		}

	}


}
