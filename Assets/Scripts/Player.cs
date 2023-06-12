using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CircleCollider2D))]
public class Player : MonoBehaviour
{
    public static event UnityAction Died;

    private void Die()
    {
        Died?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Pipe>(out Pipe pipe))
        {
            Die();
        }
    }
}
