namespace L2410;

/// <summary>
/// https://leetcode.com/problems/maximum-matching-of-players-with-trainers/?envType=daily-question&envId=2025-07-13
/// 
/// You are given a 0-indexed integer array players, where players[i] represents the ability of the ith player. 
/// You are also given a 0-indexed integer array trainers, where trainers[j] represents the training capacity of the jth trainer.
/// The ith player can match with the jth trainer if the player's ability is less than or equal to the trainer's training capacity. 
/// Additionally, the ith player can be matched with at most one trainer, and the jth trainer can be matched with at most one 
/// Return the maximum number of matchings between players and trainers that satisfy these conditions.
/// 
/// Approach: Greedy. O(n log n + m log m)
/// </summary>
public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        Array.Sort(players);
        Array.Sort(trainers);

        int matched = 0;
        int i = 0;      // for player
        int j = 0;      // for trainer

        while (i < players.Length && j < trainers.Length) {
            // if trainer is weaker. Remove this trainer
            if (trainers[j] < players[i]) {
                ++j;
                continue;
            }

            // use this trainer to this player
            ++matched;
            ++i;
            ++j;
        }

        return matched;
    }
}