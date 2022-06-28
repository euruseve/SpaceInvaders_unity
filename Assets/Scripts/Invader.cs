using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime;

    private SpriteRenderer _spriteRenderer;
    private int _animationFrame;

    public System.Action killed;


    private void Awake() 
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start() 
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);    
    }

    private void AnimateSprite()
    {
        _animationFrame++;

        if(_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            killed.Invoke();
            gameObject.SetActive(false);
            
        }
    }

}
