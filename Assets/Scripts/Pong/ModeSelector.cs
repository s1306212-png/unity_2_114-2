using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeSelector : MonoBehaviour
{
    [SerializeField] private Ball ball;

    public void SetGameMode(int modeIndex)
    {
        switch (modeIndex)
        {
            case 0:
                if (ball != null)
                {
                    // 重設並給予初速
                    ball.RunTaskA();
                }

                SceneManager.LoadScene("Pong");
                break;

            case 1:
                if (ball != null)
                {
                    // 重設並給予初速
                    ball.RunTaskA();
                }

                SceneManager.LoadScene("Pong");

                break;
            case 2:
                if (ball != null)
                {
                    // 重設並給予初速
                    ball.RunTaskA();
                }

                SceneManager.LoadScene("Pong");
                break;
            case 3:
                if (ball != null)
                {
                    // 重設並給予初速
                    ball.RunTaskA();
                }
                SceneManager.LoadScene("Pong");
                break;
        }
    }
}