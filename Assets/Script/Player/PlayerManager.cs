using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int hp = 0;
    public static int stage = 1;    //1�ܰ���� �����̴ϱ� 

    public AudioSource[] playerSound; // �÷��̾�� ���õ� ���� �ҽ� ������ 
    public GameManager gamemanager;
    Rigidbody rigid;
    Renderer myRenderer;

    Color hp1 = Color.yellow;
    Color hp2 = Color.red;


    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        playerSound = GetComponents<AudioSource>(); // ����� ���� �������ϱ� GetComponents 
        myRenderer = GetComponent<Renderer>(); //hp ���� ������ ������ 
        Debug.Log("�׽�Ʈ �޼���");
        playerSound[0].Play();
    }
    private void Update()
    {
        if (playerSound[0] == false) playerSound[1].Play();
        Debug.Log("���� HP:" + hp); //hp ������ �����ϸ� �ɰ� ���� �ݶ��̴��� �ȳֱ�

        if (transform.position.y <= -10 || Input.GetKeyDown(KeyCode.Escape))
        {
            gamemanager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other) //������Trap�� isTriggerŲ ���� 
    {
        Debug.Log("�浹����");  //�׽�Ʈ ������ ������ 
        playerSound[1].Play();  //�浹 �Ͼ�� Player_Hurt ���� ��� 
        if (other.tag == "Trap")
        {
            hp++;
            if (hp == 1) myRenderer.material.color = hp1;
            if (hp == 2) myRenderer.material.color = hp2;
            Debug.Log("�浹�� �Ͼ���ϴ�. ���� HP: " + hp);
            if (hp >= 3) //3���̻� �浹�� �Ͼ��
            {
                Debug.Log("HP�� 3 �Ʒ��Դϴ�.:" + hp);
                gamemanager.GameOver();
                //GameRestart(); //���� ó������ �ٽ� 
                //Destroy_Player(); ���Ŀ� ���� 
                hp = 0;

            }
        }
        if (other.tag == "Goal_In") //���� �ϴ� ���� ���� �Ծ��� �� 
        {
            Debug.Log("���� stage = " + stage);
            if (stage == 3) gamemanager.AllClear();
            gamemanager.GameClear();
            // ���� ���� â ���� �������� �Ѿ�� ����ȭ�� ������ ȭ��â 
        }
    }

    void GameRestart() //�÷��̾ �׾��� �� ���� �Ⱦ��� �̰� 
    {
        Debug.Log("���ӿ��� �Լ� ����");
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            SceneManager.LoadScene(1);
        }
        else if (SceneManager.GetActiveScene().name == "Stage2")
        {
            SceneManager.LoadScene(2);
        }
        else if (SceneManager.GetActiveScene().name == "Stage3")
        {
            SceneManager.LoadScene(3);
        }
    }

    /*IEnumerator Destroy_Player()
{
    Debug.Log("destroy �Լ��� ����˴ϴ�.");
    Destroy(gameObject, 1f);
    yield return new WaitForSeconds(3f);
    GameRestart(); //���� ó������ �ٽ� 
}*/

}
