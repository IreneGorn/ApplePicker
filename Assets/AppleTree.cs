using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    // Шаблон для создания яблок
    public GameObject applePrefab;

    // Скорость движения яблони
    public float speed = 1f;

    // Расстояние, на котором должно изменяться направление движения яблони
    public float leftAndRightEdge = 10f;

    // Вероятность случайного изменения направления движения
    public float changeToChangeDirections = 0.1f;

    // Частота создания экземпляров яблок
    public float secondBetweenAppleDrops = 1f;

    private void Start()    
    {
        // Сбрасывать яблоки раз в секунду
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);
    }

    private void Update()    
    {
        // Простое перемещение
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Изменение направления
        if(pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // движение вправо
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // движение влево
        }
    }

    private void FixedUpdate()
    {
        if (Random.value < changeToChangeDirections)
        {
            speed *= -1;
        }
    }
}
