using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using WaterKatLLC.Ships;
using WaterKatLLC.Ships.Segments;
using WaterKatLLC.Ships.SaveSystems;

public class ShipsTest
{
    /*
    // A Test behaves as an ordinary method
    [Test]
    public void ShipTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }
    */

    [Test]
    public void SaveSystemTest()
    {
        string testSaveName = "ShipUnitTest";

        Segment testSegment = new Segment();
        string testSegmentKey = ShipsConstants.SegmentLocations.Front;
        testSegment.type = SegmentsConstants.Types.Blaster;

        Ship testShip = new Ship();
        testShip.experience = 60;

        testShip.segments = new Dictionary<string, WaterKatLLC.Ships.Segments.Segment>() 
        { 
            { testSegmentKey, testSegment } 
        };

        SaveSystem.SaveShipData(testShip, testSaveName);
        Ship loadedShip = new Ship();
        loadedShip.AssignInterfaceValues(SaveSystem.LoadShipData(testSaveName));

        if (loadedShip.experience != testShip.experience)
        {
            Assert.Fail("Experience values do not match!");
        }

        if (!loadedShip.segments.ContainsKey(testSegmentKey))
        {
            Assert.Fail("Segments does not contain a segment at key location!");
        }

        if (testShip.segments[testSegmentKey].type != testSegment.type)
        {
            Assert.Fail("Segment Type does not match!");
        }

        Assert.Pass();
    }
    /*
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator ShipTestWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
    */
}
