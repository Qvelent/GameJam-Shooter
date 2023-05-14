using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimator : MonoBehaviour
{
    private const string isWalking = "isWalking";


    private Animator _animator;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _animator.SetBool(isWalking, _player.IsWalking());
        if (_player.IsUse())
        {
            _animator.SetTrigger("isUse");
        }
        if (_player.IsFire())
        {
            _animator.SetTrigger("isFire");
        }
        
    }
}
