using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;

public class TestScript
{
    [Test]
    public static void Move_Left_On_X()
    {
        var player = new GameObject().AddComponent<PlayerBehaviour>();

        Vector3 _orginGoalPos = player.goalPos;

        player.MoveLeft();
        player.MoveLeft();

        Vector3 _expectedGoalPos = new Vector3(_orginGoalPos.x - 4, _orginGoalPos.y, _orginGoalPos.z);

        //yield return null;

        Assert.AreEqual(player.goalPos, _expectedGoalPos);
    }

    //test

    [Test]
    public static void Move_Right_On_X()
    {
        var player = new GameObject().AddComponent<PlayerBehaviour>();

        Vector3 _orginGoalPos = player.goalPos;

        player.MoveRight();
        player.MoveRight();

        Vector3 _expectedGoalPos = new Vector3(_orginGoalPos.x + 4, _orginGoalPos.y, _orginGoalPos.z);

       // yield return null;

        Assert.AreEqual(player.goalPos, _expectedGoalPos);
    }

    public IEnumerator TestRunner()
    {
        GameObject player = new GameObject();
        GameObject spawner = new GameObject();

        player.AddComponent(typeof(PlayerBehaviour));
        spawner.AddComponent(typeof(ObjectSpawner));

        PlayerBehaviour play = player.GetComponent<PlayerBehaviour>();
        ObjectSpawner spawn = spawner.GetComponent<ObjectSpawner>();

        play.Init();
        spawn.Init();

        bool _left = true;

        for (int i = 0; i < 20; i++)
        {
            if (_left)
            {
                _left = !_left;
                play.MoveLeft();
                // yield return new WaitForSeconds(2.5f);
            }
            else
            {
                _left = !_left;
                play.MoveRight();
                //yield return new WaitForSeconds(2.5f);
            }
        }

        Assert.IsTrue(play.playerHit);

        yield return null;
    }
}
