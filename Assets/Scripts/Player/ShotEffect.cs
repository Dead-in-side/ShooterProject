using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class ShotEffect : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites;

    private SpriteRenderer _spriteRenderer;
    private float _lifeTime = 5f;
    private float _lifeCounter = 0f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sprite = _sprites[Random.Range(0,_sprites.Length)];
    }

    private void Update()
    {
        _lifeCounter += Time.deltaTime;

        if ( _lifeCounter >= _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
