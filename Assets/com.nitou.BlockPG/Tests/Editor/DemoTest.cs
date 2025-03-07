using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace EditorTests {

    public class DemoTest {

        /// ----------------------------------------------------------------------------
        // 

        [SetUp]
        public void SetUp() {
            Debug.Log("Set up");
        }

        [TearDown]
        public void TearDown() {
            Debug.Log("Tear down");
        }


        /// ----------------------------------------------------------------------------
        // 

        [Test]
        public void Test1() {
            // Arrange
            
            // Act
            
            // Assert

            Debug.Log("Test 1");
        }


        [Test]
        public void Test2() {
            // Arrange

            // Act

            // Assert

            Debug.Log("Test 2");
        }
    }
}