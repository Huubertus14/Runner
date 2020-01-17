using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class IntegrationTests
    {
        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator IntegrationTestsWithEnumeratorPasses()
        {
            SceneManager.LoadScene("SampleScene");

            yield return new WaitForSeconds(3f);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            var player = GameObject.Find("Player");

            yield return null;
        }
    }
}
