using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpEffect : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;

    public IEnumerator DoubleJumpEffectCoroutine()
    {
        float radius = transform.parent.GetComponent<PlayerStatus>().Radius;
        Vector3 pos = transform.parent.position - new Vector3(0, radius + 0.1f, 0);

        SpriteRenderer doublejumpEffectRenderer = GetComponent<SpriteRenderer>();
        doublejumpEffectRenderer.enabled = true;
        foreach (var sprite in spriteArray)
        {
            doublejumpEffectRenderer.sprite = sprite;
            transform.SetPositionAndRotation(pos, Quaternion.identity);
            yield return 0;
            transform.SetPositionAndRotation(pos, Quaternion.identity);
            yield return 0;
        }
        doublejumpEffectRenderer.enabled = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
