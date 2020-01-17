using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Values:")]
    public Vector3 goalPos;
    public float movementSpeed;

    [Header("JumpValues")]
    public AnimationCurve jumpCurve;

    public bool playerHit;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        goalPos = Vector3.zero;
        transform.position = Vector3.zero;

        if (movementSpeed == 0)
            movementSpeed = 1;

        playerHit = false;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, goalPos, Time.deltaTime * movementSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    public void MoveLeft()
    {
        if (goalPos.x > -4)
        {
            Vector3 _newGoal = new Vector3(goalPos.x - 4, goalPos.y, goalPos.z);
            goalPos = _newGoal;
        }
    }

    public void MoveRight()
    {
        if (goalPos.x < 4)
        {
            Vector3 _newGoal = new Vector3(goalPos.x + 4, goalPos.y, goalPos.z);
            goalPos = _newGoal;
        }
    }

    public void Jump()
    {
        if (goalPos.y == 0)
        {
            StartCoroutine(JumpCoroutine());
        }
    }

    private IEnumerator JumpCoroutine()
    {
        float tweenValue;
        float duration = 0.5f;
        float timeTweenKey = 0;
        Vector3 _newGoal;

        while (timeTweenKey < 1)
        {
            timeTweenKey += Time.deltaTime / duration;

            tweenValue = jumpCurve.Evaluate(timeTweenKey);

            _newGoal = new Vector3(goalPos.x, goalPos.y + tweenValue, goalPos.z);

            goalPos = _newGoal;

            yield return null;
        }

        _newGoal = new Vector3(goalPos.x, 0, goalPos.z);

        goalPos = _newGoal;
        //transform.position = goalPos;

    }

    private void OnTriggerEnter(Collider other)
    {
        EvadeObjectBehaviour _evade = other.gameObject.GetComponent<EvadeObjectBehaviour>();
        if (_evade != null)
        {
            playerHit = true;
        }
    }

}
