using System;
using Koans.Utils;
using Xunit;
using CurrentLesson = Koans.Lessons.Lesson4Time;

namespace Koans.Tests
{

    public class Lesson4TimeTest
    {
        [Fact]
        public void TestAllQuestions()
        {
            //KoanUtils.Verify<CurrentLesson>(l => l.LaunchingAnActionInTheFuture(), 0);
            //KoanUtils.Verify<CurrentLesson>(l => l.LaunchingAnEventInTheFuture(), 0);
            KoanUtils.Verify<CurrentLesson>(l => l.YouCanPlaceATimelimitOnHowLongAnEventShouldTake(), 2100);
            KoanUtils.Verify<CurrentLesson>(l => l.Throttling(), "from scott");
            KoanUtils.Verify<CurrentLesson>(l => l.Buffering(), "Scott Reed");
            KoanUtils.Verify<CurrentLesson>(l => l.TimeBetweenCalls(), "slow down");
        }
    }
}