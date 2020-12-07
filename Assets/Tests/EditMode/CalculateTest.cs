using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

namespace Tests
{
    public class CalculateTest
    {
        // Test case 1. // ID: TC_01
        [Test]
        public void ValidateNegativeValuesInInputField()
        {
            try{
                Debug.Log("Test started: ");
                Assert.That(CalculateBMI.negativeValueCheckTS("-"),Is.False);
            }
            catch (Exception ex){
                
                Assert.Fail("Negative values are not allowed");
                Debug.Log("Assert failed");
            }
        }

        // Test case 2. // ID: TC_02
        [Test]
        public void ValidateWeightInputFieldIsEmpty()
        {
            try{
                Debug.Log("Test started: ");
                Assert.AreEqual(CalculateBMI.checkWeightInputFieldsTS(""),"weight input field is empty");
            }
            catch (Exception ex){
                
                Assert.Fail("Please enter valid weight in kg");
                Debug.Log("Assert failed");
            }
        }

        // Test case 3. // ID: TC_03
        [Test]
        public void ValidateHeightInputFieldIsEmpty()
        {
            try{
                Debug.Log("Test started: ");
                Assert.AreEqual(CalculateBMI.checkHeightInputFieldsTS(""),"height input field is empty");
            }
            catch (Exception ex){
                
                Assert.Fail("Please enter valid height in cm");
                Debug.Log("Assert failed");
            }
        }

        // Test case 4. // ID: TC_04
        [Test]
        public void ValidateHeightInputFieldIsNotEmpty()
        {
            try{
                Debug.Log("Test started: ");
                Assert.AreEqual(CalculateBMI.checkHeightInputFieldsTS("185"),"height field is valid");
            }
            catch (Exception ex){
                
                Assert.Fail("height field is not valid");
                Debug.Log("Assert failed");
            }
        }

        // Test case 5. // ID: TC_05
        [Test]
        public void ValidateWeightInputFieldIsNotEmpty()
        {
            try{
                Debug.Log("Test started: ");
                Assert.AreEqual(CalculateBMI.checkWeightInputFieldsTS("75"),"weight field is valid");
            }
            catch (Exception ex){
                
                Assert.Fail("weight field is not valid");
                Debug.Log("Assert failed");
            }
        }

        

        // Test case 6. // ID: TC_06
        [Test]
        public void ValidateBMICalculation()
        {
            try{
                var bmiVal = CalculateBMI.calculateBMI(185,75);
                Assert.AreEqual(bmiVal,0.0022);
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
        }

        // Test case 7. // ID: TC_07
        [Test]
        public void ValidateBMIOverWeight()
        {
            try{
                var bmiVal = CalculateBMI.getBMIResultsTS(0.0026);
                Assert.AreEqual(bmiVal,"overweight");
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
        }

        // Test case 8. // ID: TC_08
        [Test]
        public void ValidateBMIUnderWeight()
        {
            try{
                var bmiVal = CalculateBMI.getBMIResultsTS(0.0018);
                Assert.AreEqual(bmiVal,"underweight");
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
        }

        // Test case 9. // ID: TC_09
        [Test]
        public void ValidateBMINormalWeight()
        {
            try{
                var bmiVal = CalculateBMI.getBMIResultsTS(0.0022);
                Assert.AreEqual(bmiVal,"normal");
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
        }

        // Test case 10. // ID: TC_10
        [Test]
        public void ValidateWeightNotExceed3digits()
        {
            try{
                var value = CalculateBMI.checkValueDigits(185);
                Assert.AreEqual(value,true);
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
            
        }

        // Test case 11. // ID: TC_11
        [Test]
        public void ValidateWeightNotExceedsMore3digits()
        {
            try{
                var value = CalculateBMI.checkValueDigits(1850);
                Assert.AreEqual(value,false);
            }
            catch (Exception ex){
                
                Assert.Fail("No exception was thrown");
                Debug.Log("Assert failed");
            }
            
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator CalculateTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        // Not yet in the game
        /*
        [UnityTest]
        public IEnumerator TestForTwoObjectsCollied()
        {
            GameObject gameGameObject = 
            MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
            Game game = gameGameObject.GetComponent<Game>();
            GameObject obj1 = game.GetObject1();
            obj1.transform.position = game.GetObject2().transform.position;
            yield return new WaitForSeconds(0.1f);
            Assert.True(game.isCollided);
            Object.Destroy(game.gameObject);
        }*/
        
    }
}
