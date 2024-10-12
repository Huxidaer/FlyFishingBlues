using UnityEngine;

public class InstructionGamePauser : MonoBehaviour
{
    private bool isPaused = false; // ���ڼ����Ϸ�Ƿ�����ͣ

    void OnTriggerEnter(Collider other)
    {
        // ����⵽��������ײʱ����ͣ��Ϸ
        if (!isPaused)  // �����Ϸ��δ��ͣ
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        // ������Ϸ��ͣ
        Time.timeScale = 0f; // ��ͣ��Ϸ��0Ϊ��ͣ��1Ϊ�����ٶ�
        isPaused = true;
        Debug.Log("Game Paused");
    }

    void ResumeGame()
    {
        // �ָ���Ϸ
        Time.timeScale = 1f; // �ָ���Ϸ
        isPaused = false;
        Debug.Log("Game Resumed");
    }

    void Update()
    {
        // �����Ұ��¿ո񲢰���D�Իָ���Ϸ
        if (isPaused && Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.D))
        {
            ResumeGame();
        }
    }
}
