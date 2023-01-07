using System.Collections;
using UnityEngine;

class MouseAnimator : MonoBehaviour
{
    public string direction;
    [SerializeField] private float animationInterval = 0.2f;
    [SerializeField] private Sprite appearance1;
    [SerializeField] private Sprite appearance2;

    private SpriteRenderer _renderer;

    private void Start()
    {
        direction = "left";
        _renderer = GetComponent<SpriteRenderer>();
        StartCoroutine("Animate");
    }

    private IEnumerator Animate()
    {
        while (true)
        {
            yield return new WaitForSeconds(animationInterval);
            _renderer.sprite = appearance1;
            yield return new WaitForSeconds(animationInterval);
            _renderer.sprite = appearance2;
        }
    }

    private void Update()
    {
        _renderer.flipX = (direction == "right");
    }
}
