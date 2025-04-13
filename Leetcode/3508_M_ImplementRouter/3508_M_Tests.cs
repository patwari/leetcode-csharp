namespace L3508;

public class Test {
    [Fact]
    public void SanityTest01() {
        Router router = new Router(3); // Initialize Router with memoryLimit of 3.
        Assert.True(router.AddPacket(1, 4, 90));    // Packet is added. Return True.
        Assert.True(router.AddPacket(2, 5, 90));    // Packet is added. Return True.
        Assert.False(router.AddPacket(1, 4, 90));   // This is a duplicate packet. Return False.
        Assert.True(router.AddPacket(3, 5, 95));    // Packet is added. Return True
        Assert.True(router.AddPacket(4, 5, 105));   // Packet is added, [1, 4, 90] is removed as number of packets exceeds memoryLimit. Return True.

        Assert.Equal([2, 5, 90], router.ForwardPacket());   // Return [2, 5, 90] and remove it from router.
        Assert.True(router.AddPacket(5, 2, 110));           // Packet is added. Return True.
        Assert.Equal(1, router.GetCount(5, 100, 110));      // The only packet with destination 5 and timestamp in the inclusive range [100, 110] is [4, 5, 105]. Return 1.
    }

    [Fact]
    public void SanityTest02() {
        Router router = new Router(2);                  // Initialize Router with memoryLimit of 2.
        Assert.True(router.AddPacket(7, 4, 90));        // Return True.
        Assert.Equal([7, 4, 90], router.ForwardPacket()); // Return [7, 4, 90].
        Assert.Equal([], router.ForwardPacket());       // There are no packets left, return [].
    }
}