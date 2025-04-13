namespace L3508;

/// <summary>
/// https://leetcode.com/problems/implement-router/description/
/// 
/// Design a data structure that can efficiently manage data packets in a network router. 
/// Each data packet consists of the following attributes:
/// -     source: A unique identifier for the machine that generated the packet.
/// -     destination: A unique identifier for the target machine.
/// -     timestamp: The time at which the packet arrived at the router.
/// 
/// Approach: HashMap + Queue. O(log n) per query.
/// - Since we need FIFO, so store the packets in a Queue.
/// - We need to check for duplicates. Use HashSet< id >
/// - We also need GetCount. So, we use a HashMap< destination, List<packets> >, and then use binary search to search packets in interval [startTime, endTime]
/// - However, as older packets gets forwarded, we need to remove them from the list in the last in the last HashMap. But removal from list is O(n).
/// - So, we don't remove from the list. Instead we keep - int startIdx - and do binary search only from this index. Indicating that everything before has already been forwarded.
/// - And from time to time - we cleanup the list.
/// </summary>
public class Router {
    private readonly int LIMIT;

    private Queue<Packet> packets = new();              // packets yet to be forwarded
    private HashSet<string> hashSet = new();            // hash of packets in the Queue

    private Dictionary<int, PacketHistoryList> destToPackets = new();       // destination => list of ALL packets. NOTE = ALL packets. Even the forwarded ones. We don't want to remove from list frequently.

    public Router(int memoryLimit) {
        LIMIT = memoryLimit;
    }

    public bool AddPacket(int source, int destination, int timestamp) {
        // CHECK: if duplicate -> return false
        string hash = GetHash(source, destination, timestamp);
        if (hashSet.Contains(hash)) return false;
        hashSet.Add(hash);

        Packet p = new(source, destination, timestamp);

        // CHECK: if LIMIT reached -> remove oldest
        if (packets.Count == LIMIT) {
            Packet popped = packets.Dequeue();
            hashSet.Remove(GetHash(popped.source, popped.destination, popped.timestamp));
            destToPackets[popped.destination].MarkOneRemoved();
        }

        packets.Enqueue(p);
        if (!destToPackets.ContainsKey(destination)) destToPackets[destination] = new();
        destToPackets[destination].Add(p);
        return true;
    }

    public int[] ForwardPacket() {
        // CHECK: if nothing to forward
        if (packets.Count == 0) return [];

        Packet popped = packets.Dequeue();
        hashSet.Remove(GetHash(popped.source, popped.destination, popped.timestamp));
        destToPackets[popped.destination].MarkOneRemoved();

        return [popped.source, popped.destination, popped.timestamp];
    }

    public int GetCount(int destination, int startTime, int endTime) {
        // CHECK: if no packets for the destination
        if (!destToPackets.ContainsKey(destination)) return 0;

        // CHECK: if no pending packets for the destination
        if (destToPackets[destination].startIdx >= destToPackets[destination].allPackets.Count)
            return 0;

        int l = LowerBound(destToPackets[destination].allPackets, destToPackets[destination].startIdx, startTime);
        int e = UpperBound(destToPackets[destination].allPackets, destToPackets[destination].startIdx, endTime);

        return e - l;

    }

    private string GetHash(int source, int destination, int timestamp) => $"{source},{destination},{timestamp}";

    // Find index of first [i] >= KEY 
    private int LowerBound(List<Packet> allPackets, int startIdx, int startTime) {
        int left = startIdx;
        int right = allPackets.Count - 1;
        int idx = allPackets.Count;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (allPackets[mid].timestamp >= startTime) {
                idx = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }

        return idx;
    }

    // find index of first [i] > KEY
    private int UpperBound(List<Packet> allPackets, int startIdx, int endTime) {
        int left = startIdx;
        int right = allPackets.Count - 1;
        int idx = allPackets.Count;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            if (allPackets[mid].timestamp > endTime) {
                idx = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return idx;
    }


    // ========================= Utility classes =========================

    private class Packet {
        internal int source;
        internal int destination;
        internal int timestamp;

        internal Packet(int source, int destination, int timestamp) {
            this.source = source;
            this.destination = destination;
            this.timestamp = timestamp;
        }
    }

    private class PacketHistoryList {
        internal int startIdx = 0;              // consider this and right items
        internal List<Packet> allPackets = new();

        internal void Add(Packet p) => allPackets.Add(p);

        internal void MarkOneRemoved() {
            ++startIdx;
            CheckAndCleanup();
        }

        private void CheckAndCleanup() {
            if (startIdx >= 50) {
                allPackets = allPackets.GetRange(50, allPackets.Count - 50);
                startIdx = 0;
            }
        }
    }
}
