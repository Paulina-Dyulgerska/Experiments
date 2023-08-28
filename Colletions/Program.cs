using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var the4CallsToBeForwardedProbably = new List<Call>
            {
                new Call {Id = 1, RoomId = 1, WardId = 1, ClusterId = 1},
                new Call {Id = 2, RoomId = 2, WardId = 2, ClusterId = 2},
                new Call {Id = 3, RoomId = 3, WardId = 3, ClusterId = 3},
                new Call {Id = 4, RoomId = 4, WardId = 1, ClusterId = 4},
                new Call {Id = 5, RoomId = 1, WardId = 1, ClusterId = 5},
                new Call {Id = 6, RoomId = 2, WardId = 2, ClusterId = 6},
                new Call {Id = 7, RoomId = 3, WardId = 3, ClusterId = 7},
                new Call {Id = 8, RoomId = 4, WardId = 1, ClusterId = 8},
            };

            var memoryStoredSentEnrichedCallForwardingLists = new ConcurrentDictionary<long, HashSet<Call>>();

            foreach (var call in the4CallsToBeForwardedProbably)
            {
                var hasCallsForTheCurrentWard = memoryStoredSentEnrichedCallForwardingLists
                    .TryGetValue(call.WardId, out HashSet<Call> callsForTheCurrentWard);

                if (hasCallsForTheCurrentWard)
                {
                    var hasNewCallInTheCurrentWard = callsForTheCurrentWard.Add(call);

                    if (hasNewCallInTheCurrentWard)
                    {
                        //forward calls because this is a new call
                        Console.WriteLine($"forward calls because this is a new call: id - {call.Id}, roomid: {call.RoomId}, wardid: {call.WardId}");
                    }
                    else
                    {
                        Console.WriteLine($"Dublicate call: id - {call.Id}, roomid: {call.RoomId}, wardid: {call.WardId}");
                    }
                }

                else
                {
                    var callsForCurrentWardNew = new HashSet<Call>(new CallComparer());
                    callsForCurrentWardNew.Add(call);
                    memoryStoredSentEnrichedCallForwardingLists.TryAdd(call.WardId, callsForCurrentWardNew);

                    //forward calls because this is a new call
                    Console.WriteLine($"forward calls because this is a new call: id - {call.Id}, roomid: {call.RoomId}, wardid: {call.WardId}");
                }
            }

            foreach (var item in memoryStoredSentEnrichedCallForwardingLists.Keys)
            {
                Console.WriteLine($"For key {item} we have the following values added:");

                foreach (var call in memoryStoredSentEnrichedCallForwardingLists[item])
                {
                    Console.WriteLine($"---Value: {call.Id}, {call.RoomId}, {call.WardId}, {call.Timestamp}");
                }
            }
        }
    }
}
