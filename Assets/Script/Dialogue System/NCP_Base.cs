using UnityEngine;
using UnityEngine.InputSystem;

public abstract class NCP_Base : MonoBehaviour, Iinteractable
{
    [Header("SerializedVar")]
    [SerializeField] private SpriteRenderer _interactSprite;
    [SerializeField] private float _InteractDistance = 5f;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame && IsWithinInteractDistance())
        {
            Interact();
        }
        if (_interactSprite.gameObject.activeSelf && !IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(false);
        }
        else if (!_interactSprite.gameObject.activeSelf && IsWithinInteractDistance())
        {
            _interactSprite.gameObject.SetActive(!false);
        }
    }

    public abstract void Interact();

    private bool IsWithinInteractDistance()
    {
        if (Vector2.Distance(_playerTransform.position, transform.position) < _InteractDistance) return true; else return false;
    }
}
