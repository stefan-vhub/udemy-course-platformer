using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public enum FruitType { Apple, Banana, Cherry, Kiwi, Melon, Orange, Pinepple, Strawberry }

public class Fruit : MonoBehaviour
{
    private GameManager gameManager;
    private Animator anim;

    [SerializeField] private FruitType fruitType;
    [SerializeField] private GameObject pickupVfx;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        gameManager = GameManager.instance;
        SetRandomLookIfNeeded();
    }

    private void SetRandomLookIfNeeded()
    {
        if (gameManager.FruitsHaveRandomLook() == false) { UpdateFruitVisuals(); return; }
        int randomIndex = Random.Range(0, 8); // max value is exclusive, so it will give number from 0 tp 7
        anim.SetFloat("fruitIndex", randomIndex);
    }

    private void UpdateFruitVisuals() => anim.SetFloat("fruitIndex", (int)fruitType);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            gameManager.AddFruit();
            Destroy(gameObject);

            GameObject newFx = Instantiate(pickupVfx, transform.position, Quaternion.identity);
        }
    }
}