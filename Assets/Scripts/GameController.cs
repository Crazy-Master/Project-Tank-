using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController Instance;
    
    void Start()
    {
        if (Instance == null) {                 // Экземпляр менеджера был найден
            Instance = this;                    // Задаем ссылку на экземпляр объекта
        } else if(Instance == this){            // Экземпляр объекта уже существует на сцене
            Destroy(gameObject);                // Удаляем объект
        }
                                                // Теперь нам нужно указать, чтобы объект не уничтожался
                                                // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);
        
                                                // И запускаем собственно инициализатор
        InitializeManager();
    }

    private void InitializeManager()
    {
        // Здесь мы загружаем и конвертируем настройки из PlayerPrefs
    }

}
