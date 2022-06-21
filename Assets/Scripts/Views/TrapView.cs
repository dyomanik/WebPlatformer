using System;
using UnityEngine;

public class TrapView : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    [SerializeField]
    private Collider2D _collider;
    [SerializeField]
    private Rigidbody2D _rigidbody;

    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    public Collider2D Collider => _collider;
    public Rigidbody2D Rigidbody => _rigidbody;

    public Action<TrapView> TrapViewContact { get; set; }

}
