namespace L1865;

public class Test {
    [Fact]
    public void SanityTest() {
        FindSumPairs findSumPairs = new([1, 1, 2, 2, 2, 3], [1, 4, 5, 2, 5, 4]);
        Assert.Equal(8, findSumPairs.Count(7));         // return 8; pairs (2,2), (3,2), (4,2), (2,4), (3,4), (4,4) make 2 + 5 and pairs (5,1), (5,5) make 3 + 4
        findSumPairs.Add(3, 2);                         // now nums2 = [1,4,5,4,5,4]
        Assert.Equal(2, findSumPairs.Count(8));         // return 2; pairs (5,2), (5,4) make 3 + 5
        Assert.Equal(1, findSumPairs.Count(4));         // return 1; pair (5,0) makes 3 + 1
        findSumPairs.Add(0, 1);                         // now nums2 = [2,4,5,4,5,4]
        findSumPairs.Add(1, 1);                         // now nums2 = [2,5,5,4,5,4]
        Assert.Equal(11, findSumPairs.Count(7));         // return 11; pairs (2,1), (2,2), (2,4), (3,1), (3,2), (3,4), (4,1), (4,2), (4,4) make 2 + 5 and pairs (5,3), (5,5) make 3 + 4
    }
}