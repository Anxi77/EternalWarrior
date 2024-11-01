using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    #region Members
   
    private static GameManager instance;

    public static GameManager Instance => instance;

    internal List<Enemy> enemies = new List<Enemy>(); //���� �����ϴ� ��ü �� List

    internal Player player;

    #endregion
    
    #region Unity Message Methods
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        //PlayerStatusCheck();
    }

    #endregion

    #region Unit Related Methods
    private void PlayerStatusCheck()
    {
        switch (player.playerStatus)
        {
            case Player.Status.Alive:
                break;
            case Player.Status.Dead:
                Time.timeScale = 0;
                break;
        }
    }

    public void Resume() 
    {
        Time.timeScale = 1;
    }

    #endregion

}

#region Tutorials

/*MyClass myClass = MyClass.GetMyClass();//��ü ����
        //�⺻ �����ڰ� private�̹Ƿ� GetMyClass�θ� �ν��Ͻ��� �����Ҽ� �ִ�.                                
        //�ʿ������� �̱����� ����Ҷ��� ����ƽ ������ �ϳ� ����� �����Ϳ����� �ξ� ������ ���� �ʵ���
        //���� myClass�� �ʿ� �������� null�� �����ϴ� �� ������ ������
        //GC�� ���� ��ü�� �����ȴ�.
*/

/*�������� C#�� �̱��� ��ü ����
public class DefaultSingleton
{
    //���� ���μ��� ���� ���� å���� �� �ν��Ͻ��� ������ ����
    private static DefaultSingleton instance;

    private DefaultSingleton() { } //�ܺο��� �����ڸ� ȣ���� �� ������ �⺻ ������ ������ ���´�.

    //�ܺο����� ���� ������ �ν��Ͻ��� �����Ͽ� ���� ������ ���� ����(�ٸ� ������ ���� �Ұ�)
    public static DefaultSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DefaultSingleton();
                return instance;
            }
            return instance;
        }
    }
    /*
    //���� ���μ��� ���� ���� å���� �� �ν��Ͻ��� ������ ����
    private static DefaultSingleton _Instance;

    private DefaultSingleton() {}

    public DefaultSingleton Instance 
    { 
        get 
        { 
            if (_Instance == null) 
            { 
                _Instance = new DefaultSingleton(); 
                return _Instance;
            }
            return _Instance;
        }
    }
}
    */

/*�⺻���� ��ü������ ���� �̱��� ��ü�� ����� ���
public class MyClass
{
    private static MyClass nonCollectableMyClass; //������ ������ �ȵǴ� myclass �ν��Ͻ��� ����.

    private MyClass() { }

    public int processCount;//��������(non-static)

    public static MyClass GetMyClass()
    {
        if (nonCollectableMyClass == null)//GetMyClass�� ���� ȣ����� ��쿡�� True 
        {
            nonCollectableMyClass = new MyClass();
            return nonCollectableMyClass;
        }
        else
        {
            return nonCollectableMyClass;
        }
    }
}
*/

#region EventHandler
//private void HandleBombExploded()
//{
//    Bomb.OnBombExploded += HandleBombExploded;
//    Enemy.OnEnemyKilled += HandleEnemyKilled;
//    if (player != null && enemies != null)
//    {
//        foreach (Enemy enemy in enemies)
//        {
//            Destroy(enemy.gameObject);
//        }
//        enemies.Clear();
//    }
//}

//private void HandleEnemyKilled(Enemy enemy, float exp) 
//{
//    player.GainExperience(exp);
//    player.killCount++;
//    enemies.Remove(enemy);
//    Destroy(enemy.gameObject);
//}
#endregion

#endregion
