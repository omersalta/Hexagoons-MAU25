using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private Player _player;
    private void OnTriggerStay2D(Collider2D other)
    { 
        Collectable collectable = other.gameObject.GetComponent<Collectable>();
        Debug.Log("OnCollisionEnter2D");
        if (collectable != null)
        {
            collectable.OnCollect(_player);
        }
    }
}
