using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public static Rigidbody2D _rigidbody2D;
    public static SpriteRenderer _spriteRenderer;
    public static PlayerStats _playerStats;

    public float moveSpeed = 120; //Скорость передвижения.

    public float jumpPower = 360; //Сила прыжка.

    void Start()
    {
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _playerStats = this.GetComponent<PlayerStats>();
    }

    
}
