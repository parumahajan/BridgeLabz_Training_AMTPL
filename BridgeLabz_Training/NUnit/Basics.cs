/*
----------------------------------------------------------
** NUnit **
----------------------------------------------------------
-> It is a unit testing framework through which we can write the code, with which, we can test our code.

-> It is an open-source unit testing framework.
----------------------------------------------------------
1. ATTRIBUTES:
----------------------------------------------------------
1) [Test] → marks a method as a test

2) [TestFixture] → marks a class as a container which contains test cases

3) [SetUp] → runs before each test 
(used to initialize the objects)

4) [TearDown] → runs after each test to close costly resources (for cleanup purpose)

5) [TestCase(...)] → creates parameterized tests

6) [OneTimeTearDown] -> 
----------------------------------------------------------
2. ASSERTIONS (E-N-T)
----------------------------------------------------------
1) Assert.AreEqual(expected, actual)
2) Assert.AreNotEqual(expected, actual)

3) Assert.IsNull(obj)
4) Assert.IsNotNull(obj)

5) Assert.IsTrue(condition)
6) Assert.IsFalse(condition)

7) Assert.Throw <ExceptionType>( () => Code);
----------------------------------------------------------
3. TEST RUNNER
----------------------------------------------------------
-> Integrates with Visual Studio, and shows the test results in a nice UI, telling:

- Which tests passed
- Which tests failed
- Error messages and stack traces
----------------------------------------------------------
4. ADVANTAGES:
----------------------------------------------------------
1. Automation
-> One click runs hundreds of tests.

2. Better code quality
-> Makes the code more testable and modular.

3. Documentation
-> Tests show how methods are supposed to behave.

4. Fast feedback

-> No need to run the whole app. We can do it in parts.
-> Tests run within seconds, and we can see what's broken.
----------------------------------------------------------
5. DISADVANTAGES:
----------------------------------------------------------
1. It takes extra time to write tests for each thing.
2. Its packages are not built in. We need to download the NUnit package (via NuGet) to use it.
----------------------------------------------------------
HOW TO ESTABLISH CONNECTION: 
----------------------------------------------------------
1. Right-click on Testing (its Project)
2. Click Add → Project Reference
3. Tick: BridgeLabz_Training

Through this, our Testing project can see our Main Project, which needs to be tested out.
----------------------------------------------------------








*/