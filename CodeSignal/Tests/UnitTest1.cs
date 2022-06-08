namespace Tests;

public class ProgramTests
{
    [Fact]
    public void should_return_occurrences_in_order()
    {
        var sut = new Program();
        var expected = new int[] { 2, 3, 5 };
        var testCase = new int[] { 25, 2, 3, 57, 38, 41 };

        var actual = sut.Solution(testCase);

        Assert.Equal(expected, actual);
    }
}